using UnityEngine;
using System.Collections;

public class bulut : MonoBehaviour {
    public GameObject[] buluts;
    public float hiz;

    private Transform[] ilerle;
    private float sonKare = -15.0f;
    private float ilkKare = 15.5f;
   

    void Start () {
        ilerle = new Transform[buluts.Length];

       for(int i= 0; i < buluts.Length; i++)
        {
      ilerle[i] = (Instantiate(buluts[i])).GetComponent<Transform>().transform; //bulutları instantiate et
        }
	}

    void bulutHareket() //bulutların hareket animasyonu
    {
        float tutx;
        float xKoordinati;
        float yKoordinati;

        for(int i=0; i < buluts.Length; i++)
        {

            xKoordinati = ilerle[i].position.x - hiz;
            yKoordinati = ilerle[i].position.y ;
            

            ilerle[i].position = new Vector3(xKoordinati, yKoordinati, 0);

            tutx = ilerle[i].position.x;

            // son = -17  ilk = 15.5
            if (tutx < sonKare)
            {
                ilerle[i].GetComponent<Transform>().position = new Vector3(ilkKare, yKoordinati, 0);
            }       
        }
    }


	// Update is called once per frame
	void Update () {
        hiz = GameObject.Find("spawnPoints").GetComponent<spawn>().hizbulut;
        bulutHareket();
    }
}
