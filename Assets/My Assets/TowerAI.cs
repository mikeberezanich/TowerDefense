using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour {

    //public GameObject projectile;
    //public GameObject currTarget;
    public Projectile projectile;
    public float rateOfFire = 1f;
    public float towerRadius;

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
            enemiesInRound.Clear();
            enemiesInRange.Clear();
            if (FindObjectOfType(typeof(EnemyAI)) != null) {
                enemiesInRound.AddRange(FindObjectsOfType(typeof(EnemyAI)) as EnemyAI[]);
                currRound = Manager.roundNumber;
            }
            //findO
            Debug.Log("Enemies in round: " + enemiesInRound.Count) ;
        }


        foreach (EnemyAI e in enemiesInRound) {
            if (e != null) {
                if (Vector3.Distance(transform.position, e.transform.position) < towerRadius) {
                    //Debug.Log(Vector3.Distance(transform.position, e.transform.position));
                    if(!enemiesInRange.Contains(e))
                        enemiesInRange.Add(e);

                } else {
                    if (enemiesInRange.Contains(e)) {
                        enemiesInRange.Remove(e);
                        Debug.Log("Removing enemy");
                    }
                }
                //Debug.Log("Enemies in range: " + enemiesInRange.Count);
            } else {
                enemiesInRange.Remove(e);
                Debug.Log("Removing enemy");
                Debug.Log("Enemies in range: " + enemiesInRange.Count);
            }
        }

        //Debug.Log("Enemies: " + enemiesInRound);
        if (enemiesInRange.Count > 0) {
            currTarget = enemiesInRange[0];
        } else {
            currTarget = null;
        }
    }

    IEnumerator Fire() {
        while (true) {
            if (currTarget != null) {
                currProjectile = Instantiate(projectile, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                currProjectile.target = currTarget;
                //Debug.Log("Arrow spawned?");
            }
            //Debug.Log("Waiting");
            yield return new WaitForSeconds(1 / rateOfFire);
        }
    }
}
