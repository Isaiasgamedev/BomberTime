using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start_menu_script : MonoBehaviour {

    public bool Starpress;

    private void Start()
    {
        Starpress = false;
    }

    private void Update()
    {
        if (!Starpress)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                start_pressed();
                Starpress = true;
            }
        }
    }

   
	public void start_pressed()
    {
        StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Mission01"));	
	}
}
