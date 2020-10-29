using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission_Text_Script : MonoBehaviour {

	string s_1 =  "Seja bem vindo! ";
	string secret_1 = "Esta é uma história sobre desenvolvimento  ";
	string secret_2 = " de um game, onde um grande herói ";
	string s_2 = "  acaba" ;
	string s_3 = " ajudando a dar continuidade";
	string secret_3 = " a este projeto. " ;
	string secret_4 = " Mesmo trabalhando duro não consigo terminar, ";
	string s_4 = " Texto ";
	string secret_5 = " este projeto porém com sua ajuda ";
	string s_5 = "Texto ";
	string secret_6 = " tenho certeza que consiguirei";
	string s_6 = " texto"  ;
	string secret_7 = " e graças a você o mundo gamer continuará" ;
	string s_7 =  "\n"+ "Meu sincero obrigado ISAIASGAMEDEV";

	// Use this for initialization
	void Start () {
		Text t = GetComponent<Text>();
		
		t.text = create_text();
	}

	private string create_text(){
		string res = "";
		int i =	PlayerPrefs.GetInt("current_level");
		Debug.Log(i);
		res += s_1;
		if(i >= 1){
			res+= secret_1;
		} else {
			res += "-- --- -- -----";
		}
		
		if(i >= 2){
			res+= secret_2;
		} else {
			res += "-- ---- -- ---";
		}
		res += s_2;
		res += s_3;
		if(i >= 3){
			res += secret_3;
		} else {
			res += "--- --- ------";
		}
		
		if(i >= 4){
			res += secret_4;
		} else {
			res += "-------------------";
		}
		res += s_4;
		if(i >= 5){
			res += secret_5;
		} else {
			res += "--- -- ----";
		}
		
		res += s_5;
		if(i >= 6){
			res += secret_6;
		} else {
			res += "------- -- --";
		}
		
		res += s_6;
		if(i >= 7){
			res += secret_7;
		} else {
			res += "--- -- ----";
		}
		
		res += s_7;
		
		return res;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
