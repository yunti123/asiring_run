using UnityEngine;
using System.Collections;

public class zemin : MonoBehaviour
{
    public GameObject yer;
    public float hiz;                  //0.05

    private GameObject[] yers;
    private float xKoordinati = -10.0f;
    private float sonKare = -17;       //-17
    private float ilkKare = 15.5f;     //15.5
    private float oteleme = 6.5f;      //6.5
    private int zeminSys = 5;           //5
    
    // Use this for initialization
    void Start()
    {
        yers = new GameObject[zeminSys];  
        
        // x = -10     y =-4     z = 0
        for (int i = 0; i < zeminSys; i++)
        {
       yers[i] = ((GameObject)Instantiate(yer, new Vector3(xKoordinati, -4, 0), Quaternion.identity)); //zemini instantiate et
       xKoordinati += oteleme;  
        }
    //    AudioSource audio = GetComponent<AudioSource>();
      //  audio.Play();
    }     

    void ilerle()


    {
        float ilerlex;
        float tutx;

        for (int i = 0; i < zeminSys; i++) //zeminin hareket animasyonu
        {
            ilerlex = yers[i].GetComponent<Transform>().position.x - hiz;
            yers[i].GetComponent<Transform>().position = new Vector3(ilerlex, -4, 0);
            tutx = yers[i].GetComponent<Transform>().position.x;

            // son = -17  ilk = 15.5
            if (tutx < sonKare)
            {
                yers[i].GetComponent<Transform>().position = new Vector3(ilkKare, -4, 0);
            } 
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        hiz = GameObject.Find("spawnPoints").GetComponent<spawn>().hizyer;
        ilerle();
    }

}