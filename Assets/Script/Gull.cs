using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gull : MonoBehaviour
{
    float i;
    float y;
    float scale;
    private void Start()
    {
        scale = Random.Range(0.1f, 0.5f);
        y = Random.Range(0.6f, -0.6f);
        if (this.transform.position.x > 0)
        {
            i = -1f;
        }
        else
        {
            i = 1f;
        }
        transform.localScale = new Vector3(scale, scale, 1);
    }
    void Update()
    {
        if (this.transform.position.y > -1.4f && this.transform.position.y < 4.6f && this.transform.position.x > -4.2f && this.transform.position.x < 4.2f)
        {
            this.transform.position = new Vector3(this.transform.position.x + i * scale * Time.deltaTime, this.transform.position.y + y * scale * Time.deltaTime, this.transform.position.z);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
