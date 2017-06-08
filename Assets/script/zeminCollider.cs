using UnityEngine;
using System.Collections;

public class zeminCollider : MonoBehaviour {
    public float hiz;

    private bool yuru;
    private Vector3 tut;


    void Update()
    {
        hiz = GameObject.Find("spawnPoints").GetComponent<spawn>().hizyer;
        yuru = GetComponentInChildren<engels>().Yuru;
        if (yuru)
        {
            tut = GetComponent<Transform>().position;
            tut.x -= hiz;
            GetComponent<Transform>().position = tut;
        } 
    }   
}
