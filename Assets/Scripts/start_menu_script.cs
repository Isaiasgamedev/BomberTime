﻿using System.Collections;
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
        //if (!Starpress)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        start_pressed();
        //        Starpress = true;
        //    }
        //}
        


    }

   
	public void start_pressed()
    {		 
		
		
	    if (Application.CanStreamedLevelBeLoaded("Game"))
        {
		    StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game"));
	    }

        else
        {
		 	StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game_mobile"));
	
	    }
	
	}
}
