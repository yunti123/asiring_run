using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvas : MonoBehaviour {
    public bool ol=false; //dier textleri etkileyebilir
    private int skor;
    private int max;
    public GameObject olum;
    public GameObject rekorr;
 //   public AudioClip tik;
	// Use this for initialization
	void Start () {
        
        max = PlayerPrefs.GetInt("Max");
	}
    public void tikla()
    {
       // GetComponent<AudioSource>().PlayOneShot(tik);
    }

    public void bitir()
    {
        SceneManager.LoadScene("asiring_run");
    }

	
	// Update is called once per frame
	void Update () {
        ol = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().Olum;
        max = PlayerPrefs.GetInt("Max");

        if (skor > max)
        {
            PlayerPrefs.SetInt("Max", skor);
            PlayerPrefs.Save();
        }

        if (ol) //diğer textleri etkileyebilir
        {
            if (gameObject.name == "sikor")
            {
                olum.SetActive(true);
                gameObject.SetActive(false);
                rekorr.SetActive(false);
            } 
        }
        skor = GameObject.FindGameObjectWithTag("Player").GetComponent<karakteHareket>().Skor;
        gameObject.GetComponent<Text>().text = "Skor: " + skor;
        rekorr.GetComponent<Text>().text = "Rekor: " + max;
	}
}
