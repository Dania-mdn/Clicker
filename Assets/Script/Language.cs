using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.HasKey("Lanqaqe") == false)
        {
            if(Application.systemLanguage == SystemLanguage.Russian)
            {
                PlayerPrefs.SetInt("Lanqaqe", 1);
            }
            else if(Application.systemLanguage == SystemLanguage.Ukrainian)
            {

                PlayerPrefs.SetInt("Lanqaqe", 2);
            }
            else
            {
                PlayerPrefs.SetInt("Lanqaqe", 0);
            }
        }
        translator.Select_Language(PlayerPrefs.GetInt("Lanqaqe"));
    }
    public void Language_change(int LanguageID)
    {
        PlayerPrefs.SetInt("Lanqaqe", LanguageID);
        translator.Select_Language(PlayerPrefs.GetInt("Lanqaqe"));
    }
}
