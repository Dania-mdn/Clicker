using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    float i;
    float y;
    float coef;
    SpriteRenderer sprite;
    private void Start()
    {
        coef = Random.Range(0.3f, 0.5f);
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, Random.Range(0.25f, 0.85f));
        y = Random.Range(0.2f, -0.2f);
        if (this.transform.position.x > 0)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                int a = Random.Range(1, 3);
                if(a == 1)
                {
                    sprite.flipX = true;
                    i = 0.7f;
                    transform.right = new Vector2(i, y);
                }
                else
                {
                    sprite.flipX = false;
                    i = -0.7f;
                    transform.right = new Vector2(-i, -y);
                }
            }
            else
            {
                sprite.flipX = false;
                i = -0.7f;
                transform.right = new Vector2(-i, -y);
            }
        }
        else
        {
            sprite.flipX = true;
            i = 0.7f;
            transform.right = new Vector2(i, y);
        }
    }
    void Update()
    {
        if (this.transform.position.y < -2.2f && this.transform.position.y > -5.7f && this.transform.position.x > -4.2f && this.transform.position.x < 4.2f)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                this.transform.position = new Vector3(this.transform.position.x - 0.04f + i * coef * Time.deltaTime, this.transform.position.y + y * coef * Time.deltaTime, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(this.transform.position.x - 0.01f + i * coef * Time.deltaTime, this.transform.position.y + y * coef * Time.deltaTime, this.transform.position.z);
            }
        }
        else if(this.transform.position.y >= -2.2f)
        {
            y = -0.5f;
            if (PlayerPrefs.HasKey("action"))
            {
                if (sprite.flipX == true)
                {
                    transform.right = new Vector2(i, y);
                    this.transform.position = new Vector3(this.transform.position.x - 0.04f + i * Time.deltaTime, this.transform.position.y + y * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    transform.right = new Vector2(-i, -y);
                    this.transform.position = new Vector3(this.transform.position.x - 0.04f + i * Time.deltaTime, this.transform.position.y + y * Time.deltaTime, this.transform.position.z);
                }
            }
            else
            {
                if (sprite.flipX == true)
                {
                    transform.right = new Vector2(i, y);
                    this.transform.position = new Vector3(this.transform.position.x - 0.01f + i * Time.deltaTime, this.transform.position.y + y * Time.deltaTime, this.transform.position.z);
                }
                else
                {
                    transform.right = new Vector2(-i, -y);
                    this.transform.position = new Vector3(this.transform.position.x - 0.01f + i * Time.deltaTime, this.transform.position.y + y * Time.deltaTime, this.transform.position.z);
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
