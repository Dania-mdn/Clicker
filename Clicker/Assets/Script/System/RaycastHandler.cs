using UnityEngine;
using TMPro;
using System.Collections;

public class RaycastHandler : MonoBehaviour
{
    public GameManager GameManager;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private GameObject _prizeForClick;
    [SerializeField] private EventManager.AchiveName _achiveName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 border = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(border, Vector2.zero);

            if(hit.collider != null)
            {
                if(hit.transform.GetComponent<PriezeObject>().IsLeftBorder)
                {
                    CreatePrizeForClick(hit);
                    EventManager.DoNewAchive(_achiveName);
                }
                else if (hit.transform.GetComponent<PriezeObject>().IsRightBorder)
                {
                    CreatePrizeForClick(hit);
                }
            }
        }
    }
    private void CreatePrizeForClick(RaycastHit2D hit)
    {
        GameManager.ShowAd();
        GameObject _newPrizeForClick;
        AudioSource.Play();
        MonneyHandler.singleton.TakeGift();
        _newPrizeForClick = Instantiate(_prizeForClick, hit.transform.position, Quaternion.identity);
        _newPrizeForClick.transform.SetParent(MonneyHandler.singleton.transform);
        _newPrizeForClick.GetComponent<TextMeshProUGUI>().text = MonneyHandler.singleton.PrizeMonney.ToString("0");
        hit.transform.GetComponent<PriezeObject>().Pooled();
        StartCoroutine(MovePrize(_newPrizeForClick));
    }
    IEnumerator MovePrize(GameObject _newPrizeForClick)
    {
        float duration = 3;
        float elapsedTime = 0.0f;

        Vector2 _starPosition = _newPrizeForClick.transform.position;
        Vector2 _endPosition = _starPosition + new Vector2(-3, 3);

        while (elapsedTime < duration)
        {
            _newPrizeForClick.transform.position = Vector2.Lerp(_starPosition, _endPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(_newPrizeForClick);
    }
}
