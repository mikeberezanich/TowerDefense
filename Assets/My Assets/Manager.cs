using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public static int livesLeft;
    public static int score;
    public static int roundNumber;
    public static int gold;
    public EnemyAI roundEnemy;

    public GameObject startLocation;
    //private Vector3 startLocation;
    private EnemyAI currEnemy;
    private int enemiesInRound;

    Text text;

    void Awake() {
        //Set up reference
        text = GetComponent<Text>();

        //Reset score
        livesLeft = 10;
        score = 0;
        roundNumber = 1;
        gold = 100;

        //startLocation = new Vector3(3.8f, -5.5f, -3.2f);
        //roundEnemy

        //startLocation = get
    }

    // Update is called once per frame
    void Update() {
        text.text = "\n\t\tLives: " + livesLeft + "\tScore: " + score + "\tRound: ".PadLeft(100) + roundNumber + "\tGold: " + gold;

        enemiesInRound = FindObjectsOfType(typeof(EnemyAI)).Length;
        //Debug.Log("Enemies in round: " + enemiesInRound);

        if (enemiesInRound < 1) {
            roundNumber += 1;
            newRound();
        }

        if (livesLeft < 1) {
            //set lose screen visible
        }
    }

    void newRound() {
        for (int i = 0; i < roundNumber; i++) {
            currEnemy = Instantiate(roundEnemy, startLocation.transform.position, Quaternion.identity);
            GameObject[] wp = GameObject.FindGameObjectsWithTag("Waypoint");
            for (int j = 0; j < wp.Length; j++) { //wp.Length + 1; j++) {
                currEnemy.waypoints[j] = GameObject.Find("Waypoint" + (j + 1)).transform;
            }

            //}
            //if (roundNumber % 2 == 0) {

            //} else {

            //}
        }
        Debug.Log("Enemies in round: " + enemiesInRound);
    }
}