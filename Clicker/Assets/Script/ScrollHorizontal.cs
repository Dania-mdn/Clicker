using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollHorizontal : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;
    [Range(0, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 10f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Header("Other Objects")]
    public GameObject[] panPrefab;
    public ScrollRect scrollRect;

    public ManagerButton MB;
    private GameObject[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;
    public int[] price_ship;
    public TextMeshProUGUI price_button;
    private int index;
    public GameObject[] Ship;
    private GameObject Ship_Scene;
    public Image sprite;

    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedPanID;
    private bool isScrolling;
    public Toggle togl1;
    public Toggle togl2;
    public Toggle togl3;

    private void Start()
    {
        PlayerPrefs.DeleteKey("0");
        for (int i = 0; i < panCount; i++)
        {
            PlayerPrefs.DeleteKey("0_" + i);
        }
        //обновление цен кораблей
        for (int i = 0; i < panCount; i++)
        {
            if(PlayerPrefs.HasKey("price_ship" + i))
            {
                price_ship[i] = PlayerPrefs.GetInt("price_ship" + i);
            }
        }
        //добавление корабля
        Ship_Scene = Instantiate(Ship[1/*SaveAndLoad.Singleton.item.ShipNumber*/], new Vector3(0.43f, -0.98f, 0), Quaternion.identity);
        //скролл
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefab[i], transform, false);
            if (PlayerPrefs.HasKey("price_ship" + i))
            {
                for (int c = 0; c < instPans[i].transform.childCount; c++)
                {
                    Image[] img = instPans[i].GetComponentsInChildren<Image>();
                    img[c].color = new Color(1, 1, 1);
                }
            }
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + panPrefab[i].GetComponent<RectTransform>().sizeDelta.x + panOffset,
                instPans[i].transform.localPosition.y);
            pansPos[i] = -instPans[i].transform.localPosition;
        }
    }
    private void Update()
    {
        //количество доступных кораблей
        for (int i = 0; i < panCount; i++)
        {
            if (price_ship[i] > 0 && price_ship[i] <= PlayerPrefs.GetFloat("Money_box"))
            {
                if (PlayerPrefs.HasKey("Unloc " + 1) && PlayerPrefs.HasKey("Unloc " + 6) && PlayerPrefs.HasKey("Unloc " + 7))
                {
                    PlayerPrefs.SetInt("0", 1);
                    break;
                }
                else
                {
                    PlayerPrefs.DeleteKey("0");
                }
            }
            else
            {
                PlayerPrefs.DeleteKey("0");
            }
        }
        if (PlayerPrefs.HasKey("Unloc " + 1))
        {
            togl1.isOn = true;
        }
        else
        {
            togl1.isOn = false;
        }
        if (PlayerPrefs.HasKey("Unloc " + 6))
        {
            togl2.isOn = true;
        }
        else
        {
            togl2.isOn = false;
        }
        if (PlayerPrefs.HasKey("Unloc " + 7))
        {
            togl3.isOn = true;
        }
        else
        {
            togl3.isOn = false;
        }
    }

    private void FixedUpdate()
    {
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
        scrollRect.inertia = false;
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            if (price_ship[i] > 0)
            {
                PlayerPrefs.SetFloat("Gift", price_ship[i] / 30);
                break;
            }
        }
        for (int i = 0; i < panCount; i++)
        {
            
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
                if(price_ship[i] != 0)
                {
                    price_button.text = price_ship[i].ToString("0"); 
                    if (price_ship[i] <= PlayerPrefs.GetFloat("Money_box"))
                    {
                        if (PlayerPrefs.HasKey("Unloc " + 1) && PlayerPrefs.HasKey("Unloc " + 6) && PlayerPrefs.HasKey("Unloc " + 7))
                        {
                            sprite.color = new Color(0f, 1f, 0.168f);
                        }
                        else
                        {
                            sprite.color = new Color(1f, 1f, 1f);
                        }
                    }
                    else
                    {
                        sprite.color = new Color(1f, 1f, 1f);
                    }
                }
                else
                {
                    sprite.color = new Color(0f, 1f, 0.168f);
                    if (PlayerPrefs.GetInt("Lanqaqe") == 2)
                    {
                        price_button.text = "куплений";
                    }
                    else if(PlayerPrefs.GetInt("Lanqaqe") == 1)
                    {
                        price_button.text = "куплен";
                    }
                    else if (PlayerPrefs.GetInt("Lanqaqe") == 0)
                    {
                        price_button.text = "bought";
                    }
                }
                index = i;
            }
            float scale = Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, 0.5f, 1f);
            pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            instPans[i].transform.localScale = pansScale[i];
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
        if (isScrolling || scrollVelocity > 400) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
    public void Buy_ship()
    {
        PlayerPrefs.DeleteKey("0");
        for (int i = 0; i < panCount; i++)
        {
            PlayerPrefs.DeleteKey("0_" + i);
        }
        if(price_ship[index] > 0)
        {
            if (PlayerPrefs.HasKey("Unloc " + 1) && PlayerPrefs.HasKey("Unloc " + 6) && PlayerPrefs.HasKey("Unloc " + 7))
            {
                if (PlayerPrefs.GetFloat("Money_box") - price_ship[index] >= 0)
                {
                    MB.CloseAllButton();
                    PlayerPrefs.SetInt("Ship_Trigger", 1);
                    for (int c = 0; c < instPans[index].transform.childCount; c++)
                    {
                        Image[] img = instPans[index].GetComponentsInChildren<Image>();
                        img[c].color = new Color(1, 1, 1);
                    }
                    //вычитание стоимости корабля, обнуление его стоимости и сохранение корабля
                    PlayerPrefs.DeleteKey("Unloc " + 1);
                    PlayerPrefs.DeleteKey("Unloc " + 6);
                    PlayerPrefs.DeleteKey("Unloc " + 7);
                    PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") - price_ship[index]);
                    PlayerPrefs.SetInt("price_ship" + index, 0);
                    price_ship[index] = 0;
                    //SaveAndLoad.Singleton.item.ShipNumber = index;
                    //удаление старого добавление нового корабля
                    Destroy(Ship_Scene);
                    Ship_Scene = Instantiate(Ship[index], new Vector3(0.43f, -0.98f, 0), Quaternion.identity);
                }
            }
        }
        else
        {
            MB.CloseAllButton();
            for (int c = 0; c < instPans[index].transform.childCount; c++)
            {
                Image[] img = instPans[index].GetComponentsInChildren<Image>();
                img[c].color = new Color(1, 1, 1);
            }
            price_ship[index] = 0; 
            //SaveAndLoad.Singleton.item.ShipNumber = index;
            //удаление старого добавление нового корабля
            Destroy(Ship_Scene);
            Ship_Scene = Instantiate(Ship[index], new Vector3(0.43f, -0.98f, 0), Quaternion.identity);
        }
    }
}
