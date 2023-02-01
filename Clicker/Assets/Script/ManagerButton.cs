using UnityEngine;
using TMPro;

public class ManagerButton : MonoBehaviour
{
    public GameObject imj_Achiwment;
    public GameObject imj_ship;
    public GameObject imj_engine;
    public GameObject imj_korpus;
    public GameObject imj_crew;
    public TextMeshProUGUI num_Achiwment;
    public TextMeshProUGUI num_ship;
    public TextMeshProUGUI num_engine;
    public TextMeshProUGUI num_korpus;
    public TextMeshProUGUI num_crew;
    public GameObject[] Button;
    public GameObject[] Button_upgrade;
    public void clous_button(GameObject button)
    {
        PlayerPrefs.SetInt("Color", 1);
        button.SetActive(false);
    }
    public void open_button(GameObject button)
    {
        clous_all();
        PlayerPrefs.DeleteKey("Color");
        for (int i = 0; i < Button.Length; i++)
        {
            if(Button[i].name == button.name)
            {
                Button[i].SetActive(true);
            }
        }
    }
    public void chenge_button(GameObject button)
    {
        clous_all();
        PlayerPrefs.DeleteKey("Color");
        for (int i = 0; i < Button_upgrade.Length; i++)
        {
            if (Button_upgrade[i].name == button.name)
            {
                Button_upgrade[i].transform.position = new Vector3(0.1f, 0.07f, 0);
            }
        }
    }
    public void clous_all()
    {
        PlayerPrefs.SetInt("Color", 1);
        for (int i = 0; i < Button_upgrade.Length; i++)
        {
            Button_upgrade[i].transform.position = new Vector3(-10, Button_upgrade[i].transform.position.y, Button_upgrade[i].transform.position.z);
        }
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("Achiwment") == 0)
        {
            imj_Achiwment.SetActive(false);
        }
        else
        {
            imj_Achiwment.SetActive(true);
            num_Achiwment.text = PlayerPrefs.GetInt("Achiwment").ToString("0");
        }

        if (PlayerPrefs.GetInt("0") == 0)
        {
            imj_ship.SetActive(false);
        }
        else
        {
            imj_ship.SetActive(true);
            num_ship.text = PlayerPrefs.GetInt("0").ToString("0");
        }

        if (PlayerPrefs.GetInt("1") == 0)
        {
            imj_engine.SetActive(false);
        }
        else
        {
            imj_engine.SetActive(true);
            num_engine.text = PlayerPrefs.GetInt("1").ToString("0");
        }


        if (PlayerPrefs.GetInt("2") == 0)
        {
            imj_korpus.SetActive(false);
        }
        else
        {
            imj_korpus.SetActive(true);
            num_korpus.text = PlayerPrefs.GetInt("2").ToString("0");
        }


        if (PlayerPrefs.GetInt("3") == 0)
        {
            imj_crew.SetActive(false);
        }
        else
        {
            imj_crew.SetActive(true);
            num_crew.text = PlayerPrefs.GetInt("3").ToString("0");
        }
    }
}
