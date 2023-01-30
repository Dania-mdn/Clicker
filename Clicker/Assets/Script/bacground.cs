using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacground : MonoBehaviour
{
    public float a;
    public float b;
    void Update()
    {
        if (this.transform.position.x > -6)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                this.transform.position = new Vector3(this.transform.position.x - a * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x - b * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
