using UnityEngine;
using System.Collections;
public class karakteHareket : MonoBehaviour
{

    public Sprite[] karakter = new Sprite[8];
    public float animHizi = 10.0f;
    public float yurumeHizi = 1.0f;
    public int level = 1;
    public float y = 3.0f;
  //  public AudioClip sesZipla;
    //public AudioClip sesPuan;
    //public AudioClip sesOlum;

    private float oynat;
    private Vector3 tut;                                                    //karakterin positionı
    private Vector3 ilkKonum;
    private int x = 0;                                                      //animasyonun indexi
    private int skor = 0;
    private int levelBarajı = 0;
    private float skorKatla = 1.5f;
    private bool zipla = false;
    private bool olum = false;

    void Start()
    { 
        ilkKonum = Input.acceleration;
        oynat = Time.time + 1f;
        levelBarajı = 3;
    }
    public bool Olum
    {
        get
        {
            return olum;
        }
        set
        {
            olum = value;
        }
    }

    public int Skor                                                         
    {
        get
        {
            return skor;
        }
        set
        {
            skor = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    void OnCollisionEnter2D(Collision2D temas)                              // zıplama için colliderın zemins tagını görmesi gerek
    {
        if (temas.gameObject.tag == "zemins")
        {
            zipla = true;
        }
    }

    void OnCollisionExit2D(Collision2D temas)                               // zıplama için colliderın zemins tagını görmesi gerek
    {
        if (temas.gameObject.tag == "zemins")
        {
            zipla = false;
        }
    }

    void OnTriggerStay2D(Collider2D temas)                                  //zıplaması için hat çizgisini kontrol eder
    {
        if(temas.gameObject.tag == "Hat")
        {
            zipla = true;
        } 
    }

    void OnTriggerExit2D(Collider2D temas)                                  //zıplaması için hat çizgisini kontrol eder
    {
        if (temas.gameObject.tag == "Hat")
        {
            zipla = false;
        }
    }

    void Update()
    {
         y = tut.y + 3f ;

        tut = GetComponent<Transform>().position; 
        
        if (Time.time >= oynat)                                             //animasyonun indexi değiştirmek için belli bir süre bekle
        {
            x++;
            oynat = Time.time + 1.0f / animHizi;
        }
        if (x >= karakter.Length)                                           //index karakterin indexini geçerse sıfırla
        {
            x = 0;
        }
        GetComponent<SpriteRenderer>().sprite = karakter[x];
        if (!olum)
        {
            if (zipla)                                                          //ziplama animasyonunu geliştir !!!!
            {

                if (Input.GetKeyDown("w") || Input.touchCount == 1) //zıplama
                {
                    //              GetComponent<AudioSource>().clip = sesZipla;
                    while (tut.y <= y)
                    {

                        tut.y += 0.02f;
                        GetComponent<Transform>().position = tut;
                    }
        //            GetComponent<AudioSource>().PlayOneShot(sesZipla);

                    GetComponent<Transform>().rotation = Quaternion.identity;   //karakter düşünce ayağa kaldırma (animasyon geliştirilebilir) 
                }                                                               //!!!ridigbody freez rotation z ile düşmesi engellendi!!!
            }
        
            if (Input.GetKey("a") || Input.GetKey("d"))                          // ileri geri
            {

                transform.Translate(Input.GetAxis("Horizontal") / yurumeHizi, 0, 0);
            }
            else if (Input.acceleration.x - ilkKonum.x < -0.2 || Input.acceleration.x - ilkKonum.x > 0.2)
            {
                transform.Translate(Input.acceleration.x * 2 / yurumeHizi, 0, 0);
            }
        }
        else
        {
         //   Destroy(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>());
        }

        if(skor >= levelBarajı)
        {
            level++;
            levelBarajı = (int)(skor * skorKatla);
        }
        Debug.Log(skor + " " + level + " " + levelBarajı);
    }
}

