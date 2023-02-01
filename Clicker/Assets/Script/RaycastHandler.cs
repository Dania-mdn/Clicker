using UnityEngine;
using TMPro;

public class RaycastHandler : MonoBehaviour
{
    public AdsManager AdsManager;
    public GameManager GameManager;
    public GameObject PrizeForClick;
    private GameObject _newPrizeForClick;
    private readonly string _dolphin = "Dolphin(Clone)";
    private readonly string _bottle = "Bottle(Clone)";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 border = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(border, Vector2.zero);

            if(hit.collider != null)
            {
                if(hit.collider.name == _dolphin)
                {
                    CreatePrizeForClick(hit);
                    PlayerPrefs.SetInt("dolfi_trigger", 1);
                }
                else if (hit.collider.name == _bottle)
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
        AdsManager.aud_Play();
        GameManager.gift();
        _newPrizeForClick = Instantiate(PrizeForClick, hit.transform.position, Quaternion.identity);
        _newPrizeForClick.transform.SetParent(GameManager.transform);
        _newPrizeForClick.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Gift").ToString("0");
        Destroy(hit.transform.gameObject);
    }
}
