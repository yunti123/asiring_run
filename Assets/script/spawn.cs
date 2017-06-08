using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
   struct levıl
    {
       public int rdm;
       public float hiz;
       public float hiz2;
       public float buluts;
    };
    public Transform[] sp = new Transform[9];                               //1 2: yer , 3 4 5: hava , 6 7 8: ucan , 0: havuz 
    private GameObject engel;
    private int sec;
    private int lvl;
    private bool spawns= false;
    private bool olum = false;
    private levıl dagit;
    // Use this for initialization
    void Start (){
        dagit.rdm = 1;
        dagit.hiz = 0.05f;
        dagit.hiz2 = -5;
        dagit.buluts = 0.02f;

        sec = 1;
        engel = bul(sec);                                                   //engel seç
        engel.GetComponent<Transform>().position = spawnla(engel.name);     //spawnla
        engel.GetComponent<engels>().IsAktif = true;

    }

    public float hizyer
    {
        get
        {
            return dagit.hiz;
        }
    }
    public float hizmotor
    {
        get
        {
            return dagit.hiz2;
        }
    }
    public float hizbulut
    {
        get
        {
            return dagit.buluts;
        }
    }
	
    GameObject bul(int bul)                                                 //spawlanacak engeli seç
    {
        GameObject buldum = null;

        if (bul == 1 )                                                      // 1/8
        {
           buldum = GameObject.Find("top");
        }
        else if(bul == 2 || bul ==3)                                        // 2/8
        {
            buldum = GameObject.Find("mermi");
        }
        else if(bul == 4|| bul ==5)                                         // 2/8
        {
            buldum = GameObject.Find("16T");
        }
        else if(bul == 8|| bul ==6||bul==7)                                 // 3/8
        {
            buldum = GameObject.Find("roket");
        }
        return buldum;
    }

    Vector3 spawnla(string ad)                                              //spawnlancak yeri seç
    {
        int spp = 1;
        Vector3 position = GameObject.Find("Havasp1").GetComponent<Transform>().position;
        if (ad == "top")
        {
            position = sp[1].position;
        }
        else if(ad == "mermi")
        {
            spp = Random.Range(1, 2);

            position = sp[spp].position;
        }
        else if (ad == "16T")
        {
            spp = Random.Range(3, 5);
            position = sp[spp].position;
        } 
        else if(ad == "roket")
        {
            spp = Random.Range(6, 8);
            position = sp[spp].position;
        }

        return position;
    }

    levıl sayi(int lvl)                                                     //level a göre hızı ve engelleri ayarlama
    {
        levıl ata;
        ata.rdm = 1;
        ata.hiz = 0.05f;
        ata.hiz2 = -5;
        ata.buluts = 0.02f;
        

        if (lvl == 1)                                                       //3
        {
           ata.rdm = Random.Range(1,3);
        }
        else if(lvl == 2)                                                   //4
        {
            ata.rdm = Random.Range(1,3);
        }
        else if(lvl == 3)                                                   //6
        {
            ata.rdm = Random.Range(2, 4);
            ata.hiz = 0.055f;
            ata.hiz2 = -7;
        }
        else if(lvl == 4)                                                   //9
        {
            ata.rdm = Random.Range(1, 5);
            ata.hiz = 0.055f;
            ata.hiz2 = -7;
            ata.buluts = 0.025f;
        }
        else if(lvl ==5)                                                    //13
        {
            ata.rdm = Random.Range(2, 7);
            ata.hiz = 0.06f;
            ata.hiz2 = -10;
            ata.buluts = 0.028f;
        }
        else if(lvl == 6)                                                   //19
        {
            ata.rdm = Random.Range(1, 8);
            ata.hiz = 0.065f;
            ata.hiz2 = -13;
            ata.buluts = 0.03f;
        }
        else if(lvl == 7)                                                   //29
        {
            ata.rdm = Random.Range(1, 8);
            ata.hiz = 0.07f;
            ata.hiz2 = -17;
            ata.buluts = 0.032f;
        }
        else
        {
            ata.rdm = Random.Range(1, 8);
            ata.hiz = 0.07f * lvl * 0.13f;
            ata.hiz2 = -17 * lvl * 0.145f;
            ata.buluts = 0.032f * lvl * 0.11f;
        }

        return ata;
    }
    

	// Update is called once per frame
	void Update (){
        olum = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().Olum;
        lvl = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().level;
        spawns = GameObject.FindGameObjectWithTag("toplama").GetComponent<spawn2>().Gecti;
        Debug.Log(spawns);
        if (!olum)
        {
            if (spawns)
            {
                engel.GetComponent<Transform>().position = sp[0].position;                              //havuza at      
                if (engel.name != "16T")
                    engel.GetComponent<engels>().IsAktif = false;
                dagit = sayi(lvl);
                sec = dagit.rdm;                                                                        //engel seç
                engel = bul(sec);                                                                       //engel seç
                engel.GetComponent<Transform>().position = spawnla(engel.name);                         //spawnla
                if (engel.name != "16T")
                    engel.GetComponent<engels>().IsAktif = true;
                GameObject.FindGameObjectWithTag("toplama").GetComponent<spawn2>().Gecti = false;
            }
           
        }
        else
        {
            spawns = false;
            dagit.hiz = 0;
            dagit.hiz2 = 0;
            dagit.buluts = 0f;

        }
    }
}
