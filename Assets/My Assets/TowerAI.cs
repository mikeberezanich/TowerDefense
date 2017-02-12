using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour {

    //public GameObject projectile;
    //public GameObject currTarget;
    public Projectile projectile;
    public float rateOfFire = 1f;

    private Projectile currProjectile;
    private EnemyAI currTarget;
    private List<EnemyAI> enemiesInRound;
    private List<EnemyAI> enemiesInRange;
    private int currRound;


    // Use this for initialization
    void Start() {

        currRound = 0;
        //enemiesInRange.

        enemiesInRange = new List<EnemyAI>();
        enemiesInRound = new List<EnemyAI>();
        StartCoroutine(Fire());

    }

    // Update is called once per frame
    void Update() {
        //FindEnemy();

        if (currRound != Manager.roundNumber) {
            enemiesInRound.AddRange(FindObjectsOfType(typeof(EnemyAI)) as EnemyAI[]);
            currRound += 1;
            //findO
            Debug.Log("Enemies: " + enemiesInRound[0]);
        }

        
        foreach (EnemyAI e in enemiesInRound) { 
        //for (int i = 0; i < enemiesInRound.Length; i++) {
            //EnemyAI e = enemiesInRound[i];
            if (Vector3.Distance(transform.position, e.transform.position) < 7) {
                Debug.Log("Enemies: " + e);
                Debug.Log(Vector3.Distance(transform.position, e.transform.position));
                enemiesInRange.Add(e);
   
            } else {
                if (enemiesInRange.Contains(e)) {
                    enemiesInRange.Remove(e);
                }
            }
        }

        //Debug.Log("Enemies: " + enemiesInRound);
        if (enemiesInRange.Count > 0) {
            currTarget = enemiesInRange[0];
        }
    }

    IEnumerator Fire() {
        while (true) {
            if (currTarget != null) {
                currProjectile = Instantiate(projectile, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                currProjectile.target = currTarget;
                Debug.Log("Arrow spawned?");
            }
            Debug.Log("Waiting");
            yield return new WaitForSeconds(rateOfFire);
        }
    }
}
