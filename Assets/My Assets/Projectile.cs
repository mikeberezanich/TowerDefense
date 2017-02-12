using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Rigidbody rb;
    public EnemyAI target;
    public Vector3 enemyPosition;
    public float speed;
    public float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //EnemyAI[] enemyList = FindObjectsOfType(typeof(EnemyAI)) as EnemyAI[];
        //target = enemyList[0];
        //speed = 10;
        //damage = 10;
    }

    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 180 * Time.deltaTime);
        //enemyPosition = target.transform.position;

        //Either of these work, play around with later
        //rb.AddForce(Vector3.Normalize((enemyPosition - transform.position)) * speed, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (target.isActiveAndEnabled){
            enemyPosition = target.transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 180 * Time.deltaTime);
            rb.AddForce(Vector3.Normalize((enemyPosition - transform.position)) * speed, ForceMode.Acceleration);
        }
        
        //Either of these work, play around with later
        //rb.AddForce(Vector3.Normalize((enemyPosition - transform.position)) * speed, ForceMode.Impulse);
        //rb.velocity = Vector3.Normalize((enemyPosition - transform.position)) * speed;

        //Debug.Log("EP: " + enemyPosition + " AP: " + transform.position + " V: " + rb.velocity);


    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision between arrow and " + collision.collider);

        //Debug.Log(collision.

        if (collision.gameObject.tag == "Enemy")
        {
            target.health -= damage;
            Debug.Log("Destroyed");
            Destroy(gameObject, 0f);
        }
        else if (collision.gameObject.name == "Ground")
        {
            Debug.Log("Destroyed");
            Destroy(gameObject, 0f);
        }
    }
}
