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
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 180 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        enemyPosition = target.transform.position;
        
        //Either of these work, play around with later
        rb.AddForce(Vector3.Normalize((enemyPosition - transform.position)) * speed, ForceMode.Impulse);
        //rb.velocity = Vector3.Normalize((enemyPosition - transform.position)) * speed;
        
        //Debug.Log("EP: " + enemyPosition + " AP: " + transform.position + " V: " + rb.velocity);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject enemyHit = collision.gameObject;
        target.health -= damage;
        Destroy(gameObject, 0f);
    }
}
