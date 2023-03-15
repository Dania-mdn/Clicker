using UnityEngine;

public class Language : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.HasKey("Lanqaqe") == false)
        {
            if(Application.systemLanguage == SystemLanguage.Russian)
                PlayerPrefs.SetInt("Lanqaqe", 1);
            else if(Application.systemLanguage == SystemLanguage.Ukrainian)
                PlayerPrefs.SetInt("Lanqaqe", 2);
            else
                PlayerPrefs.SetInt("Lanqaqe", 0);
        }
        Translator.SelectLanguage(PlayerPrefs.GetInt("Lanqaqe"));
    }
    public void LanguageChange(int LanguageID)
    {
        PlayerPrefs.SetInt("Lanqaqe", LanguageID);
        Translator.SelectLanguage(PlayerPrefs.GetInt("Lanqaqe"));
    }
}
