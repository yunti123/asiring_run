using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class engels : MonoBehaviour {
    private bool isAktif = false;
    private bool yuru = false;
    private bool top= false;
    private bool topOlum = false;
    private int arttır = 0;
    private int topAnim = 0;
    private float oynat1;
    private JointMotor2D mo = new JointMotor2D();
 
    //  private AudioClip sesPuan;
    //private AudioClip sesOlum;


    void Start()
    {
     //   sesOlum = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().sesOlum;
       // sesPuan = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().sesPuan;
        if(gameObject.name == "top")
        {
            top = true;
            oynat1 = Time.time + 1f;
        }
        mo = gameObject.GetComponent<SliderJoint2D>().motor;
        mo.motorSpeed = -5;

    }

    public bool IsAktif
    {
        get { return isAktif; }
        set { isAktif = value; }
    }
    public bool Yuru
    {
        get
        {
            return yuru;
        }
    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Player")
        {
            olum();
        }

        if (temas.gameObject.tag == "sEngel")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }


    void OnTriggerStay2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Hat")
        {
            yuru = true;
        }
     
    }


    void OnTriggerExit2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "sEngel")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (temas.gameObject.tag == "Player")
        {
            arttır++ ;
        }
        if (temas.gameObject.tag == "Hat")
        {
            yuru = false;
        }
    }

    void olum()
    {
     //   GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(sesOlum);
        GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().Olum = true;
        topOlum = true;
        Destroy(GetComponent<SliderJoint2D>());
    }


    void Update()
    {
        gameObject.GetComponent<SliderJoint2D>().motor = mo;
       // gameObject.GetComponent<SliderJoint2D>().useMotor = isAktif;

        if (isAktif)
            mo.motorSpeed = GameObject.Find("spawnPoints").GetComponent<spawn>().hizmotor; 
        else
            mo.motorSpeed = 0;

       if (arttır == 3)
        {
      //      GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(sesPuan);
            GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().Skor += 1;  
            arttır = 0;
        }
    
            if (top)
            {
                if (!topOlum)
                {
                    if (Time.time >= oynat1) // hiz
                    {
                        topAnim++;
                        oynat1 = Time.time + 1.0f / 10.0f;
                    }

                    if (topAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else if (topAnim == 2)
                    {
                        GetComponent<SpriteRenderer>().flipY = true;
                    }
                    else if (topAnim == 3)
                    {
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else if (topAnim == 4)
                    {
                        GetComponent<SpriteRenderer>().flipY = false;
                        topAnim = 0;
                    }
                }
            
        }
    }

}
