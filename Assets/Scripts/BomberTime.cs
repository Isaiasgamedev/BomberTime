using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BomberTime : MonoBehaviour
{
    [Header("Bomber Time Control")]
    public static bool BomberTimeStart;
    public int CountEnemysControl;
    public static int CountEnemys;
    public GameObject[] UnlockChipKey;
    public float timeRemaining = 300;
    public GameObject timeText;

    private void Start()
    {
        CountEnemys = CountEnemysControl;
    }

    void Update()
    {        
        BomberTimeManager();
        WinBomberTime();
        CountEnemysControl = CountEnemys;
        Debug.Log("ENEMYS  =  " + CountEnemys);
    }

    public void BomberTimeManager()
    {
        if (!BomberTimeStart) return;

        if (timeText.activeSelf == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timeText.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        else
        {
            timeText.SetActive(true);
        }

        if (timeRemaining <= 0)
        {
            Debug.Log("GAME OVER");
            timeRemaining = 0;
        }

    }

    public void WinBomberTime()
    {
        if (CountEnemysControl <= 0)
        {
            BomberTimeStart = false;

            for (int i = 0; i < UnlockChipKey.Length; i++)
            {
                Destroy(UnlockChipKey[i]);
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            BomberTimeStart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BomberTimeStart = false; 
        }
    }
}
