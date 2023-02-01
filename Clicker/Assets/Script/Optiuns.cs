using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Optiuns : MonoBehaviour
{
    private readonly int _on = 0;
    private readonly int _off = -80;

    public AudioMixerGroup Mixer;
    public Toggle Music;
    public Toggle Sound;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("musika"))
        {
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
            if (PlayerPrefs.GetInt("musika") == _off)
            {
                Music.isOn = true;
            }
        }
        if (PlayerPrefs.HasKey("zvuki"))
        {
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
            if (PlayerPrefs.GetInt("zvuki") == _off)
            {
                Sound.isOn = true;
            }
        }
    }
    public void MusicEnable()
    {
        if (Music.isOn == true)
        {
            PlayerPrefs.SetInt("musika", _off);
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
        }
        else
        {
            PlayerPrefs.SetInt("musika", _on);
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
        }
    }
    public void SounfEnable()
    {
        if (Sound.isOn == true)
        {
            PlayerPrefs.SetInt("zvuki", _off);
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
        }
        else
        {
            PlayerPrefs.SetInt("zvuki", _on);
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
        }
    }

    public void URLInstagramm()
    {
        Application.OpenURL("https://www.instagram.com/gamesdmurdok/?hl=ru");
    }
}
