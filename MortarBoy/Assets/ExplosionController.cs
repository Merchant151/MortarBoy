using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExplosionController : MonoBehaviour
{
    GameObject  Player;
    GameObject[] EGuns;
    GameObject[] AGuns;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EGuns = GameObject.FindGameObjectsWithTag("ECannon");
        AGuns = GameObject.FindGameObjectsWithTag("ACannon");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player == null)
        {
            EndGame();
        }
        bool end = true;
        foreach (GameObject gun in AGuns)
        {
            if(gun != null)
            {
                end = false;
            }
        }

        if (end)
        {
            EndGame();
        }
        if((EGuns[0] == null && EGuns[1] == null && EGuns[2] == null))
        {
            WinGame();
        }

        if (Input.GetKeyDown("r"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("main");
        }
    }

    private void WinGame()
    {
        GameObject.Find("win").GetComponent<Text>().enabled = true;
    }

    public void EndGame()
    {
        GameObject.Find("Text").GetComponent<Text>().enabled = true;
        Time.timeScale = 0;
    }
}
