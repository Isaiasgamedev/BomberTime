using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global_Game_Controller : MonoBehaviour {

 
	private Text level_label;
	private Text enemy_label;

    public GameObject Door;
    public GameObject map_parent;
	public Map map;
 

    // Use this for initialization
    void Start () {

		 Application.targetFrameRate = 30;

		// init labels
		 foreach(Text t in FindObjectsOfType<Text>()){
                switch(t.tag){
                    case "enemies":
                    enemy_label = t;
                    break;
					case "level":
                    level_label = t;
                    break;
				}
		 }


		// increase map size over maps
		if(PlayerPrefs.GetInt("current_level").ToString().Length == 0)
        {
			PlayerPrefs.SetInt("current_level", 1);
		}

        int level = PlayerPrefs.GetInt("current_level");
       

        //if (level <= 8)
        //{
        //    map = gameObject.AddComponent<Map>();
        //    map.construct(1 + level, 13, 13, map_parent);
        //}
        //else
        //{
        //    map = gameObject.AddComponent<Map>();
        //    map.construct(1 + level, 13 + (level - 8) * 2, 13 + (level - 8) * 2, map_parent);
        //}



        if (level == 0)
        {
            map = gameObject.AddComponent<Map>();
            map.construct(1 + level, 9, 9, map_parent);
        }
        else if (level == 1)
        {
            map = gameObject.AddComponent<Map>();
            map.construct(1 + level, 11, 11, map_parent);
        }

        else if (level >= 2 && level <= 4)
        {
            map = gameObject.AddComponent<Map>();
            map.construct(1 + level, 13, 13, map_parent);
        }

        else if (level % 5 == 0)
        {
            map = gameObject.AddComponent<Map>();
            map.construct(1 + level, 15 + (level - 8) * 2, 15 + (level - 8) * 2, map_parent);
        }

        if (level == 0)
        {
            Destroy(GameObject.Find("Door(Clone)"));
        }
            

    }

	public void update_labels()
    {
		int i = 0;
		foreach(Player a in FindObjectsOfType<Player>())
        {
			if(a.isActiveAndEnabled)
            {
				i++;
			}
		}

		if(i <= 1)
        {
			if(FindObjectOfType<door_script>())
            {				
			    Destroy(FindObjectOfType<door_script>().gameObject);
			}
		}

		if(i > 0)
        {
			i-= 1;
		}

		enemy_label.text = (i).ToString();
	

		level_label.text = PlayerPrefs.GetInt("current_level").ToString();
	}

	public void Restart()
    {


	// get animation
	    fade_script fade = new fade_script();
	// init fader
        foreach(fade_script f in FindObjectsOfType<fade_script>())
        {
            if(f.tag == "fader")
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
		    StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game"));
	    }

        else
        {
		 	StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game_mobile"));	
	    }
           
       
	}

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("current_level"));
    }

}
