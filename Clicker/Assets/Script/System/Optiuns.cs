using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Optiuns : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioMixerGroup _music;
    [SerializeField] private AudioMixerGroup _sound;
    [SerializeField] private Toggle _toggleMusic;
    [SerializeField] private Toggle _toggleSound;

    private readonly int _on = 0;
    private readonly int _off = -80;
    private Func<string, float, bool> _mixerSetVolume;

    private void Start()
    {
        _mixerSetVolume = _mixer.audioMixer.SetFloat;

        if (PlayerPrefs.HasKey(_music.name))
            LoadVoice(_music, _toggleMusic);
        if (PlayerPrefs.HasKey(_sound.name))
            LoadVoice(_sound, _toggleSound);
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
