using UnityEngine;
using System.Collections;

public class spawn2 : MonoBehaviour {
    public bool gecti = false;

    public bool Gecti
    {
        get
        {
            return gecti;
        }
        set
        {
            gecti = value;
        }
    }

    void OnTriggerExit2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "Enemy" || temas.gameObject.tag == "enemy")
        {
            gecti = true;
            Debug.Log(temas.gameObject.name);
        }
    }
    void OnCollisionExit2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Enemy" || temas.gameObject.tag == "enemy")
        {
            gecti = true;
            Debug.Log(temas.gameObject.name);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
