using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class new_achiw : MonoBehaviour
{
    private GameObject tap;

    public TextMeshProUGUI chto_sdelal_txt;
    public TextMeshProUGUI Skolko_poluchil;
    public float i;
    float ii = 1;

    private void Start()
    {
        tap = GameObject.FindWithTag("Respawn");
    }
    public void clik()
    {
        tap.GetComponent<GameManager>().achivment(i);
        PlayerPrefs.SetInt("Achiwment", PlayerPrefs.GetInt("Achiwment") - 1);
        Destroy(this.gameObject);
    }
}
