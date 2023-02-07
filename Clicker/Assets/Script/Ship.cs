using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Sprite[] sprite_rubka;
    public Sprite[] sprite_korpus;
    public Sprite[] sprite_engine;
    public SpriteRenderer rubka;
    public SpriteRenderer korpus;
    public SpriteRenderer engine;
    float r = 1;
    float k = 1;
    float e = 1;
    public string Rubka;
    public string Korpus;
    public string Engine;
    public ParticleSystem PS;
    AudioSource Audio;
    bool aud;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(Rubka))
        {
            rubka.sprite = sprite_rubka[PlayerPrefs.GetInt(Rubka)];
        }
        if (PlayerPrefs.HasKey(Korpus))
        {
            korpus.sprite = sprite_korpus[PlayerPrefs.GetInt(Korpus)];
        }
        if (PlayerPrefs.HasKey(Engine))
        {
            engine.sprite = sprite_engine[PlayerPrefs.GetInt(Engine)];
        }
    }
    public void aud_Play()
    {
        Audio.Play();
    }
    public void aud_Stop()
    {
        Audio.Stop();
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("tap"))
        {
            if(aud == false)
            {
                aud_Play();
                PS.Play();
                aud = true;
            }
        }
        else
        {
            if(aud == true)
            {
                aud_Stop();
                aud = false;
            }
            PS.Stop();
        }

        if (PlayerPrefs.HasKey("Color"))
        {
            if (PlayerPrefs.HasKey(Rubka))
            {
                if (PlayerPrefs.HasKey("i_" + Rubka))
                {
                    r = PlayerPrefs.GetInt("i_" + Rubka);
                    PlayerPrefs.DeleteKey("i_" + Rubka);
                }
                else
                {
                    if(r < 1)
                    {
                        r = r + 0.02f;
                    }
                    else
                    {
                        r = 1;
                    }
                }
                rubka.sprite = sprite_rubka[PlayerPrefs.GetInt(Rubka)];
                rubka.color = new Color(r, r, r);
            }
            if (PlayerPrefs.HasKey(Korpus))
            {
                if (PlayerPrefs.HasKey("i_" + Korpus))
                {
                    k = PlayerPrefs.GetInt("i_" + Korpus);
                    PlayerPrefs.DeleteKey("i_" + Korpus);
                }
                else
                {
                    if (k < 1)
                    {
                        k = k + 0.02f;
                    }
                    else
                    {
                        k = 1;
                    }
                }
                korpus.sprite = sprite_korpus[PlayerPrefs.GetInt(Korpus)];
                korpus.color = new Color(k, k, k);
            }
            if (PlayerPrefs.HasKey(Engine))
            {
                if (PlayerPrefs.HasKey("i_" + Engine))
                {
                    e = PlayerPrefs.GetInt("i_" + Engine);
                    PlayerPrefs.DeleteKey("i_" + Engine);
                }
                else
                {
                    if (e < 1)
                    {
                        e = e + 0.02f;
                    }
                    else
                    {
                        e = 1;
                    }
                }
                engine.sprite = sprite_engine[PlayerPrefs.GetInt(Engine)];
                engine.color = new Color(e, e, e);
            }
        }
    }
}
