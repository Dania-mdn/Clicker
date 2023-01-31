using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransleteblText : MonoBehaviour
{
    public int textID;
    public TextMeshProUGUI UItext;
    void Awake()
    {
        UItext = GetComponent<TextMeshProUGUI>();
        Translator.Add(this);
    }
    private void OnEnable()
    {
        Translator.Update_texts();
    }
    private void OnDestroy()
    {
        Translator.Delete(this);
    }
}
