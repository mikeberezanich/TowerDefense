using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour {

    public GameObject projectile;
    public GameObject currTarget;
    public bool enemyNearby;
    public int numArrows = 5;
    private GameObject currProjectile;
	// Use this for initialization
	void Start () {
        enemyNearby = true;
    }
	
	// Update is called once per frame
	void Update () {
        //FindEnemy();
        if (enemyNearby)
        {
            //currProjectile = Instantiate(projectile, transform);
            //Kinda working
        }
        
	}

    //GameObject FindEnemy()
    //{

    //}

    //IEnumerator Fire()
    //{
    //    currProjectile =  Instantiate(projectile, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
    //    Debug.Log("Arrow spawned?");
    //    //currProjectile.Shoot(currTarget);
    //    //yield return new WaitForSeconds(3);
    //}
}
