using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public float health;
    public int pointsAwarded;
    public Transform[] waypoints;

    private NavMeshAgent agent;
    private int waypointCount, waypointIteration;

    // Used the waypoint system from http://atsiitech.blogspot.com/2016/02/unity-waypoint-system-with-navmesh.html

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);

        waypointCount = waypoints.Length;
        waypointIteration = 0;
	}

	// Update is called once per frame
	void Update () {

        //Handles movement through the waypoints
        if (agent.hasPath)
        {
            if (agent.remainingDistance < .5f)
            {
                if (waypointIteration < waypointCount)
                {
                    agent.SetDestination(waypoints[waypointIteration].position);
                    waypointIteration++;
                } else
                {
                    LivesManager.livesLeft -= 1;
                    Destroy(gameObject, 0f);
                }

            }
        }

        //Debug.Log("Health: " + health);

        if (health <= 0)
        {
            LivesManager.score += pointsAwarded;
            Destroy(gameObject, 0f);
        }
       
	}


}
