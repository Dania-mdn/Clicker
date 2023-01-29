using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achiwment : MonoBehaviour
{
    public GameObject canvas;
    public string[] chto_sdelal;
    public string[] chto_sdelal_ru;
    public string[] chto_sdelal_eu;
    public string[] chto_sdelal_en;
    public int[] Skolko_poluchil_dolfi;
    public int[] Skolko_poluchil_ship;
    public int[] Skolko_poluchil_adss_pass;
    public int[] Skolko_poluchil_adss_tap;
    public int[] Skolko_poluchil_adss_Gift;
    public int[] Skolko_poluchil_adss_x10;
    public int[] Skolko_poluchil_Gift;

    public GameObject[] achiw_count;
    public GameObject achiw;
    private void Start()
    {
        PlayerPrefs.DeleteKey("Achiwment");
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("Lanqaqe") == 2)
        {
            chto_sdelal = chto_sdelal_eu;
}
        else if (PlayerPrefs.GetInt("Lanqaqe") == 1)
        {
            chto_sdelal = chto_sdelal_ru;
        }
        else if (PlayerPrefs.GetInt("Lanqaqe") == 0)
        {
            chto_sdelal = chto_sdelal_en;
        }
        //дельфин
        if (PlayerPrefs.HasKey("dolfi_trigger"))
        {
            PlayerPrefs.SetInt("dolfi", PlayerPrefs.GetInt("dolfi") + 1);
            if (PlayerPrefs.GetInt("dolfi") == 1)
            {
                trigger();
                achiw_count[0] = Instantiate(achiw);
                achiw_count[0].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 1.ToString("0");
                achiw_count[0].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[0].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if(PlayerPrefs.GetInt("dolfi") == 5)
            {
                trigger();
                achiw_count[1] = Instantiate(achiw);
                achiw_count[1].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 5.ToString("0");
                achiw_count[1].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[1].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("dolfi") == 10)
            {
                trigger();
                achiw_count[2] = Instantiate(achiw);
                achiw_count[2].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 10.ToString("0");
                achiw_count[2].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[2].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("dolfi") == 20)
            {
                trigger();
                achiw_count[3] = Instantiate(achiw);
                achiw_count[3].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 20.ToString("0");
                achiw_count[3].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[3].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("dolfi") == 30)
            {
                trigger();
                achiw_count[4] = Instantiate(achiw);
                achiw_count[4].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 30.ToString("0");
                achiw_count[4].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[4].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("dolfi") == 40)
            {
                trigger();
                achiw_count[5] = Instantiate(achiw);
                achiw_count[5].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[0] + " " + 40.ToString("0");
                achiw_count[5].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[5].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("dolfi_trigger");
        }
        //корабль
        if (PlayerPrefs.HasKey("Ship_Trigger"))
        {
            PlayerPrefs.SetInt("Ship", PlayerPrefs.GetInt("Ship") + 1);
            if (PlayerPrefs.GetInt("Ship") == 1)
            {
                trigger();
                achiw_count[6] = Instantiate(achiw);
                achiw_count[6].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 1.ToString("0");
                achiw_count[6].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[6].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("Ship") == 2)
            {
                trigger();
                achiw_count[7] = Instantiate(achiw);
                achiw_count[7].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 2.ToString("0");
                achiw_count[7].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[7].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("Ship") == 3)
            {
                trigger();
                achiw_count[8] = Instantiate(achiw);
                achiw_count[8].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 3.ToString("0");
                achiw_count[8].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[8].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("Ship") == 4)
            {
                trigger();
                achiw_count[9] = Instantiate(achiw);
                achiw_count[9].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 4.ToString("0");
                achiw_count[9].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[9].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("Ship") == 5)
            {
                trigger();
                achiw_count[10] = Instantiate(achiw);
                achiw_count[10].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 5.ToString("0");
                achiw_count[10].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[10].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("Ship") == 6)
            {
                trigger();
                achiw_count[11] = Instantiate(achiw);
                achiw_count[11].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[1] + " " + 6.ToString("0");
                achiw_count[11].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[11].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("Ship_Trigger");
        }
        //х2 пасивный
        if (PlayerPrefs.HasKey("adss_pass"))
        {
            PlayerPrefs.SetInt("adss_p", PlayerPrefs.GetInt("adss_p") + 1);
            if (PlayerPrefs.GetInt("adss_p") == 1)
            {
                trigger();
                achiw_count[12] = Instantiate(achiw);
                achiw_count[12].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 1.ToString("0");
                achiw_count[12].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[12].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_p") == 3)
            {
                trigger();
                achiw_count[13] = Instantiate(achiw);
                achiw_count[13].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 3.ToString("0");
                achiw_count[13].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[13].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_p") == 6)
            {
                trigger();
                achiw_count[14] = Instantiate(achiw);
                achiw_count[14].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 6.ToString("0");
                achiw_count[14].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[14].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_p") == 12)
            {
                trigger();
                achiw_count[14] = Instantiate(achiw);
                achiw_count[14].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 12.ToString("0");
                achiw_count[14].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[14].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_p") == 20)
            {
                trigger();
                achiw_count[15] = Instantiate(achiw);
                achiw_count[15].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 20.ToString("0");
                achiw_count[15].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[15].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_p") == 30)
            {
                trigger();
                achiw_count[16] = Instantiate(achiw);
                achiw_count[16].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[2] + " " + 30.ToString("0");
                achiw_count[16].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[16].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("adss_pass");
        } 
        //х2 за тап
        if (PlayerPrefs.HasKey("adss_tap"))
        {
            PlayerPrefs.SetInt("adss_t", PlayerPrefs.GetInt("adss_t") + 1);
            if (PlayerPrefs.GetInt("adss_t") == 1)
            {
                trigger();
                achiw_count[17] = Instantiate(achiw);
                achiw_count[17].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 1.ToString("0");
                achiw_count[17].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[17].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_t") == 3)
            {
                trigger();
                achiw_count[18] = Instantiate(achiw);
                achiw_count[18].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 3.ToString("0");
                achiw_count[18].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[18].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_t") == 6)
            {
                trigger();
                achiw_count[19] = Instantiate(achiw);
                achiw_count[19].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 6.ToString("0");
                achiw_count[19].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[19].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_t") == 12)
            {
                trigger();
                achiw_count[20] = Instantiate(achiw);
                achiw_count[20].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 12.ToString("0");
                achiw_count[20].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[20].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_t") == 20)
            {
                trigger();
                achiw_count[21] = Instantiate(achiw);
                achiw_count[21].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 20.ToString("0");
                achiw_count[21].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[21].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_t") == 30)
            {
                trigger();
                achiw_count[22] = Instantiate(achiw);
                achiw_count[22].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[3] + " " + 30.ToString("0");
                achiw_count[22].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[22].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("adss_tap");
        }
        //подарок за рекламу
        if (PlayerPrefs.HasKey("adss_Gift"))
        {
            PlayerPrefs.SetInt("adss_G", PlayerPrefs.GetInt("adss_G") + 1);
            if (PlayerPrefs.GetInt("adss_G") == 1)
            {
                trigger();
                achiw_count[23] = Instantiate(achiw);
                achiw_count[23].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 1.ToString("0");
                achiw_count[23].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[23].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_G") == 3)
            {
                trigger();
                achiw_count[24] = Instantiate(achiw);
                achiw_count[24].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 3.ToString("0");
                achiw_count[24].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[24].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_G") == 6)
            {
                trigger();
                achiw_count[25] = Instantiate(achiw);
                achiw_count[25].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 6.ToString("0");
                achiw_count[25].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[25].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_G") == 12)
            {
                trigger();
                achiw_count[26] = Instantiate(achiw);
                achiw_count[26].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 12.ToString("0");
                achiw_count[26].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[26].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_G") == 20)
            {
                trigger();
                achiw_count[27] = Instantiate(achiw);
                achiw_count[27].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 20.ToString("0");
                achiw_count[27].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[27].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("adss_G") == 30)
            {
                trigger();
                achiw_count[28] = Instantiate(achiw);
                achiw_count[28].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[4] + " " + 30.ToString("0");
                achiw_count[28].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[28].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("adss_Gift");
        }
        //х10
        if (PlayerPrefs.HasKey("adss_x10"))
        {
            PlayerPrefs.SetInt("x10", PlayerPrefs.GetInt("x10") + 1);
            if (PlayerPrefs.GetInt("x10") == 1)
            {
                trigger();
                achiw_count[29] = Instantiate(achiw);
                achiw_count[29].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 1.ToString("0");
                achiw_count[29].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[29].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("x10") == 3)
            {
                trigger();
                achiw_count[30] = Instantiate(achiw);
                achiw_count[30].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 3.ToString("0");
                achiw_count[30].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[30].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("x10") == 6)
            {
                trigger();
                achiw_count[31] = Instantiate(achiw);
                achiw_count[31].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 6.ToString("0");
                achiw_count[31].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[31].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("x10") == 12)
            {
                trigger();
                achiw_count[32] = Instantiate(achiw);
                achiw_count[32].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 12.ToString("0");
                achiw_count[32].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[32].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("x10") == 20)
            {
                trigger();
                achiw_count[33] = Instantiate(achiw);
                achiw_count[33].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 20.ToString("0");
                achiw_count[33].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[33].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("x10") == 30)
            {
                trigger();
                achiw_count[34] = Instantiate(achiw);
                achiw_count[34].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[5] + " " + 30.ToString("0");
                achiw_count[34].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[34].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("adss_x10");
        }
        //подарок
        if (PlayerPrefs.HasKey("Gift1"))
        {
            PlayerPrefs.SetInt("G", PlayerPrefs.GetInt("G") + 1);
            if (PlayerPrefs.GetInt("G") == 1)
            {
                trigger();
                achiw_count[35] = Instantiate(achiw);
                achiw_count[35].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 1.ToString("0");
                achiw_count[35].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[35].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("G") == 3)
            {
                trigger();
                achiw_count[36] = Instantiate(achiw);
                achiw_count[36].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 3.ToString("0");
                achiw_count[36].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[36].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("G") == 6)
            {
                trigger();
                achiw_count[37] = Instantiate(achiw);
                achiw_count[37].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 6.ToString("0");
                achiw_count[37].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[37].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("G") == 12)
            {
                trigger();
                achiw_count[38] = Instantiate(achiw);
                achiw_count[38].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 12.ToString("0");
                achiw_count[38].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[38].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("G") == 20)
            {
                trigger();
                achiw_count[39] = Instantiate(achiw);
                achiw_count[39].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 20.ToString("0");
                achiw_count[39].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[39].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            else if (PlayerPrefs.GetInt("G") == 30)
            {
                trigger();
                achiw_count[40] = Instantiate(achiw);
                achiw_count[40].GetComponent<new_achiw>().chto_sdelal_txt.text = chto_sdelal[6] + " " + 30.ToString("0");
                achiw_count[40].GetComponent<new_achiw>().Skolko_poluchil.text = PlayerPrefs.GetFloat("Gift").ToString("0");
                achiw_count[40].GetComponent<new_achiw>().i = PlayerPrefs.GetFloat("Gift");
            }
            PlayerPrefs.DeleteKey("Gift1");
        }
    }
    public void actiw()
    {
        for (int i = 0; i <= achiw_count.Length; i++)
        {
            if(achiw_count[i] != null)
            {
                Instantiate(achiw_count[i], canvas.transform.parent);
                achiw_count[i] = null;
                break;
            }
        }
    }
    public void trigger()
    {
        PlayerPrefs.SetInt("Achiwment", PlayerPrefs.GetInt("Achiwment") + 1);
    }
}
