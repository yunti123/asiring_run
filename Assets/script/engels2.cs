using UnityEngine;
using System.Collections;

public class engels2 : MonoBehaviour {
    private Vector3 tut;
   


    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "sEngel")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if(temas.gameObject.name == "alt")
        {
            tut = GetComponent<Transform>().position;
            tut.x = temas.gameObject.GetComponent<Transform>().position.x;
            
            GetComponent<Transform>().position = tut;
        }
    }

    void OnTriggerExit2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "sEngel")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

}
