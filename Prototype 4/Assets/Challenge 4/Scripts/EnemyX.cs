using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 100;
    private Rigidbody enemyRb;
    public GameObject playerGoal;

    //reference spawnmanx script
    SpawnManagerX smxScript;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        //set smxscript to spawnmanaerx script attached to spawn manager object
        smxScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        //set speed to enemy speed
        speed = smxScript.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
