using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dolfi : MonoBehaviour
{
    public Ads_Manager ads;
    public GameManager GameManager;
    public GameObject dolfi_spawn;
    public GameObject dol;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(p, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.name == "Fish1_B(Clone)")
                {
                    ads.aud_Play();
                    GameManager.gift();
                    dol = Instantiate(dolfi_spawn, hit.transform.position, Quaternion.identity);
                    dol.transform.SetParent(GameManager.transform);
                    dol.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Gift").ToString("0");
                    Destroy(hit.transform.gameObject);
                    PlayerPrefs.SetInt("dolfi_trigger", 1);
                }
                else if (hit.collider.name == "Fish1_C(Clone)")
                {
                    ads.aud_Play();
                    GameManager.gift();
                    dol = Instantiate(dolfi_spawn, hit.transform.position, Quaternion.identity);
                    dol.transform.SetParent(GameManager.transform);
                    dol.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("Gift").ToString("0");
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        if(dol != null)
        {
            dol.transform.position = new Vector3(dol.transform.position.x - 0.01f, dol.transform.position.y + 0.03f, dol.transform.position.z);
            Destroy(dol, 1.5f);
        }
    }
}
