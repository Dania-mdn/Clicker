using UnityEngine;
using UnityEngine.UI;

public class Snapscrolling : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(1f, 20f)]
    [Header("Other Objects")]
    public GameObject[] panPrefab;
    public ScrollRect scrollRect;

    private GameObject[] instPans;
    private Vector2[] pansPos;

    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedPanID;
    private bool isScrolling;

    private void Start()
    {
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = panPrefab[i];
            instPans[i].transform.localPosition = panPrefab[i].transform.localPosition;
            pansPos[i] = -instPans[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        if (contentRect.anchoredPosition.y <= pansPos[0].y && !isScrolling || contentRect.anchoredPosition.y >= pansPos[pansPos.Length - 3].y && !isScrolling)
        {
            scrollRect.inertia = false;
            float nearestPos = float.MaxValue;

            for (int i = 0; i < panCount; i++)
            {
                float distance = Mathf.Abs(contentRect.anchoredPosition.y - pansPos[i].y);
                if (distance > nearestPos)
                {
                    nearestPos = distance;
                    selectedPanID = i;
                }
            }
            float scrollVelocity = Mathf.Abs(scrollRect.velocity.y);
            if (scrollVelocity < 0 && !isScrolling) scrollRect.inertia = false;
            if (isScrolling || scrollVelocity > 0) return;
            contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, pansPos[selectedPanID].y - 320, snapSpeed * Time.fixedDeltaTime);
            contentRect.anchoredPosition = contentVector;
        }
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
}
