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
        translator.Add(this);
    }
    private void OnEnable()
    {
        translator.Update_texts();
    }
    private void OnDestroy()
    {
        translator.Delete(this);
    }
}
