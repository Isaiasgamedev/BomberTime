using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start_text_script : MonoBehaviour {

    public int Levelnow;


	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = "MISSION " + Levelnow.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
