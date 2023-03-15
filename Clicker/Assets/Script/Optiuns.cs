using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Optiuns : MonoBehaviour
{
    private readonly int _on = 0;
    private readonly int _off = -80;

    public AudioMixerGroup Mixer;
    public AudioMixerGroup Music;
    public AudioMixerGroup Sound;
    public Toggle ToggleMusic;
    public Toggle ToggleSound;
    private Func<string, float, bool> _mixerSetVolume;

    private void Start()
    {
        _mixerSetVolume = Mixer.audioMixer.SetFloat;

        if (PlayerPrefs.HasKey(Music.name))
            LoadVoice(Music, ToggleMusic);
        if (PlayerPrefs.HasKey(Sound.name))
            LoadVoice(Sound, ToggleSound);
    }
    public void Enable(Toggle Toggle)
    {
        if (Toggle.isOn == true)
            PlayerPrefs.SetInt(Toggle.name, _off);
        else
            PlayerPrefs.SetInt(Toggle.name, _on);

        _mixerSetVolume(Toggle.name, PlayerPrefs.GetInt(Toggle.name));
    }
    private void LoadVoice(AudioMixerGroup AudioMixer, Toggle toggle)
    {
        _mixerSetVolume(AudioMixer.name, PlayerPrefs.GetInt(AudioMixer.name));
        if (PlayerPrefs.GetInt(AudioMixer.name) == _off)
            toggle.isOn = true;
    }
    public void URLInstagramm() => Application.OpenURL("https://www.instagram.com/gamesdmurdok/?hl=ru");
}
