using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class hide_on_start : MonoBehaviour
{

	public bool hide = true;
    public GameObject info;

	// Use this for initialization
	void Start () {
		if(hide){
		gameObject.SetActive(false);
		} else {
			
			Time.timeScale = 0;
		}
	}
	
	public void toggle()
    {
		if(gameObject.activeSelf)
        {
			gameObject.SetActive(false);
            info.SetActive(true);
		}

        else
        {
			gameObject.SetActive(true);
            info.SetActive(false);
        }

		bool t = false;
		foreach(hide_on_start h in Resources.FindObjectsOfTypeAll<hide_on_start>()){
			if(h.isActiveAndEnabled){
				t = true;
				break;
			}
            }
		if(t){
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		
	}

	public void restart(){
		Time.timeScale = 1;

        // get animation
        fade_script fade = new fade_script();
        // init fader
        foreach (fade_script f in FindObjectsOfType<fade_script>())
        {
            if (f.tag == "fader")
            {
                fade = f;
            }

            else
            {
                Debug.Log("TESTE");
                continue;
            }
        }

        // reset values


        // load map
        if (Application.CanStreamedLevelBeLoaded("Game"))
        {
            StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Mission0" + FindObjectOfType<start_text_script>().Levelnow));
        }

        else
        {
            StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Mission0" + FindObjectOfType<start_text_script>().Levelnow));
        }
    }
	public void exit(){
		Time.timeScale = 1;
		Application.Quit();
	}

	public void MainMenu()
    {
        //StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Start_Menu"));
        SceneManager.LoadScene("Start_Menu");
        toggle();
    }
}
