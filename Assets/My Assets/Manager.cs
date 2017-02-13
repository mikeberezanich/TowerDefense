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
    public Camera firstCamera;
    public Camera nextCamera;

    public GameObject startLocation;
    //private Vector3 startLocation;
    private EnemyAI currEnemy;
    private int enemiesInRound;
    private bool gameOver;

    Text text;

    void Awake() {
        //Set up reference
        text = GetComponent<Text>();

        //Reset score
        livesLeft = 1;
        score = 0;
        roundNumber = 1;
        gold = 250;

        gameOver = false;

        //startLocation = new Vector3(3.8f, -5.5f, -3.2f);
        //roundEnemy

        //startLocation = get
    }

    void Start() {
        Camera[] cameras = FindObjectsOfType(typeof(Camera)) as Camera[];
        if (cameras[0].name == "Main Camera") {
            firstCamera = cameras[0];
            nextCamera = cameras[1];
        } else if (cameras[0].name == "Dev Camera") {
            firstCamera = cameras[1];
            nextCamera = cameras[0];
        } else {
            firstCamera = cameras[0];
            nextCamera = cameras[1];
        }
        firstCamera.enabled = true;
        nextCamera.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        

        enemiesInRound = FindObjectsOfType(typeof(EnemyAI)).Length;
        //Debug.Log("Enemies in round: " + enemiesInRound);

        if (enemiesInRound < 1 && !gameOver) {
            roundNumber += 1;
            gold += 10 * roundNumber;
            newRound();
        }

        if (livesLeft > 0) {
            text.text = "\n\t\t\tLives: " + livesLeft +"\tScore: " + score + "\tRound: ".PadLeft(162) + roundNumber + "\tGold: " + gold;
        } else {
            //text.text = "Sorry you lose. Your score was: " + score;
            gameOver = true;
            //firstCamera.enabled = false;
            //nextCamera.enabled = true;
            text.text = "\n\t\t\tSorry you lose. \n\t\t\tYour score was: " + score;
            
            //GetComponent<Canvas>().renderMode()
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