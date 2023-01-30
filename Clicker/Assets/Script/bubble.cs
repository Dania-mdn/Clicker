using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    float i;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, Random.Range(0.1f, 0.5f));
        i = Random.Range(0.3f, 0.6f);
        this.transform.localScale = new Vector3(i, i, 1);
    }
    void Update()
    {
        if (this.transform.position.y < -1.85f)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                this.transform.position = new Vector3(this.transform.position.x - 2 * Time.deltaTime, this.transform.position.y + Random.Range(0.2f, 0.4f) * Time.deltaTime, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x - 0.5f * Time.deltaTime, this.transform.position.y + Random.Range(0.2f, 0.4f) * Time.deltaTime, this.transform.position.z);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
