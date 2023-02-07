using UnityEngine;

public class GenerationEnviroment : MonoBehaviour
{
    public GameObject bubbl;
    public int timer_bubbl;
    float b;
    public GameObject[] fish;
    public int timer_fish;
    float f;
    public GameObject seagulls;
    public int timer_gull;
    float g;
    public GameObject[] bacground;
    public int timer_bacground_min;
    public int timer_bacground_max;
    float z;
    public GameObject[] dno;
    public int timer_dno;
    float d;
    public GameObject zolotaya_fish;
    public GameObject zolotaya_instatiate;
    public int timer_zolotaya_fish_min;
    public int timer_zolotaya_fish_max;
    float zf;
    public GameObject butil;
    public GameObject butil_instatiate;
    public int timer_butil_min;
    public int timer_butil_max;
    float but;
    private int i;
    private int ii;
    private void Start()
    {
        b = timer_bubbl;
        f = timer_fish;
        g = timer_gull;
        z = 100;
        d = timer_dno;
        zf = 500;
    }
    void Update()
    {
        //Дельфин
        if (zf > 0)
        {
            zf = PlayerPrefs.HasKey("tap") ? zf - 100 * Time.deltaTime : zf - 20 * Time.deltaTime;
        }
        else
        {
            zf = Random.Range(timer_zolotaya_fish_min, timer_zolotaya_fish_max);
            zolotaya_instatiate = Instantiate(zolotaya_fish, new Vector3(-3.35f, -2.5f, 0), Quaternion.identity);
            Destroy(zolotaya_instatiate, 12.2f);
        }
        //Бутыль
        if (but > 0)
        {
            but = PlayerPrefs.HasKey("tap") ? but - 100 * Time.deltaTime : but - 20 * Time.deltaTime;
        }
        else
        {
            but = Random.Range(timer_butil_min, timer_butil_max);
            butil_instatiate = Instantiate(butil, new Vector3(3.18f, -1.47f, 0), Quaternion.identity);
            Destroy(butil_instatiate, 10);
        }
        //пузырьки
        if (b > 0)
        {
            b = b - 60 * Time.deltaTime;
        }
        else
        {
            b = timer_bubbl;
            Instantiate(bubbl, new Vector3(Random.Range(-2.54f, 0.27f), -6, 0), Quaternion.identity);
            Instantiate(bubbl, new Vector3(3, Random.Range(-2.1f, -6), 0), Quaternion.identity);
            Instantiate(bubbl, new Vector3(3, Random.Range(-2.1f, -6), 0), Quaternion.identity);
            Instantiate(bubbl, new Vector3(3, Random.Range(-2.1f, -6), 0), Quaternion.identity);
        }
        //рыбки
        if (f > 0)
        {
            f = f - 60 * Time.deltaTime;
        }
        else
        {
            f = timer_fish;
            if (PlayerPrefs.HasKey("tap"))
            {
                Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(4f, Random.Range(-2.1f, -5), 0), Quaternion.identity);
                Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(4f, Random.Range(-2.1f, -5), 0), Quaternion.identity);
                Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(4f, Random.Range(-2.1f, -5), 0), Quaternion.identity);
            }
            else
            {
                Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(4f, Random.Range(-2.1f, -5), 0), Quaternion.identity);
            }
        }
        //чайки
        if (g > 0)
        {
            g = g - 60 * Time.deltaTime;
        }
        else
        {
            g = timer_gull;
            Instantiate(seagulls, new Vector3(-4f, Random.Range(-1.3f, 4.5f), 0), Quaternion.identity);
            Instantiate(seagulls, new Vector3(4f, Random.Range(-1.3f, 4.5f), 0), Quaternion.identity);
        }
        //задний фон
        if (z > 0)
        {
            if (PlayerPrefs.HasKey("tap"))
            {
                z = z - 50 * Time.deltaTime;
            }
            else
            {
                z = z - 10 * Time.deltaTime;
            }
        }
        else
        {
            z = Random.Range(timer_bacground_min, timer_bacground_max);
            i = Random.Range(0, bacground.Length);
            if(i != ii)
            {
                ii = i;
                Instantiate(bacground[i], new Vector3(7, -2, 0), Quaternion.identity);
            }
        }
        //дно
        if (d > 0)
        {
            if (PlayerPrefs.HasKey("tap"))
            {
                d = d - 50 * Time.deltaTime;
            }
            else
            {
                d = d - 20 * Time.deltaTime;
            }
        }
        else
        {
            d = timer_dno;
            Instantiate(dno[Random.Range(0, dno.Length)], new Vector3(7, -4.5f, 0), Quaternion.identity);
        }
    }
}