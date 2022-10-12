/*
 * Zach Wilson
 * Assignment 5A
 * This is a script that controlles the scoreboard and score integer
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public gameManager gameManagerScript;
    public Text textbox;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 0) { score = 0; } //this prevents the allowing of negative scores. (comment out this line if we want that option)
        if(!gameManagerScript.GameOver)
        {
            textbox.text = "Score: " + score;
        }
    }
}
