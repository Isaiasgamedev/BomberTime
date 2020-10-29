using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject OptionsMenu;


    private void Start()
    {
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void OptionsOpen()
    {
        StartMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OptionsClose()
    {
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("current_level", 0);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("current_level"));
    }

}


    
