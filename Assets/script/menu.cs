using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    //  public AudioClip tik;
    // Use this for initialization
    public GameObject fmenu;
    //public GameObject kirater;
	void Start () {
       
    }
   public void tikla()
    {
    //    GetComponent<AudioSource>().PlayOneShot(tik);
    }

    public void Basla()
    {
        // SceneManager.LoadScene("asiring_run");
        fmenu.SetActive(false);
     //   Instantiate(kirater);
      //  GameObject.Find("spawnPoints").AddComponent<spawn>();
    }

    public void Bitir()
    {
        Application.Quit();
    }	
	// Update is called once per frame
	void Update () {
	
	}
}
