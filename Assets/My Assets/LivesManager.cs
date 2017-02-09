using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    public static int livesLeft;
    public static int score;

    Text text;

    void Awake()
    {
        //Set up reference
        text = GetComponent<Text>();

        //Reset score
        livesLeft = 10;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Lives: " + livesLeft + "\tScore: " + score;
        
    }
}