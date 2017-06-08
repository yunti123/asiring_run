using UnityEngine;
using System.Collections;

public class topHareket : MonoBehaviour {

    private float oynat;
    private int x = 0;

    void Start()
    {
        oynat = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= oynat) // hiz
        {
            x++;
            oynat = Time.time + 1.0f / 10.0f;
        }

        if (x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x == 2)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (x == 3)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x == 4)
        {
            GetComponent<SpriteRenderer>().flipY = false;
            x = 0;
        }
    }
}
