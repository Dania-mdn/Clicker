using UnityEngine;
using TMPro;

public class RaycastHandler : MonoBehaviour
{
    public AdsManager AdsManager;
    public GameObject PrizeForClick;
    private GameObject _newPrizeForClick;
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
                    //dolfy
                    EventManager.DoNewAchive(_achiveName);
                }
                else if (hit.transform.GetComponent<PriezeObject>().IsRightBorder)
                {
                    CreatePrizeForClick(hit);
                }
            }
        }
        if(_newPrizeForClick != null)
        {
            _newPrizeForClick.transform.position = _newPrizeForClick.transform.position + new Vector3(-0.01f, +0.03f);
            Destroy(_newPrizeForClick, 1.5f);
        }
    }
    private void CreatePrizeForClick(RaycastHit2D hit)
    {
        AdsManager.PlayAudio();
        //MonneyHandler.singleton.gift();
        _newPrizeForClick = Instantiate(PrizeForClick, hit.transform.position, Quaternion.identity);
        _newPrizeForClick.transform.SetParent(MonneyHandler.singleton.transform);
        _newPrizeForClick.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Gift").ToString("0");
        hit.transform.GetComponent<PriezeObject>().Pooled();
    }
}
