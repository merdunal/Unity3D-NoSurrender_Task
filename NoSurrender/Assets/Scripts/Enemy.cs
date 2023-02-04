using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private Rigidbody _playerRb;

    public GameObject player;
    public GameObject collectible;

    public bool hasCollectible = false;
    private float _enemySpeed = 2;
    public static int power = 0;
    

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerRb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(PauseMenu.gameisPaused == false)
        {
            GameObject closest  = findClosestEnemy();
        
            // Adds a force towards to the closest collectible or the player.
            Vector3 lookCollectible = (closest.transform.position - transform.position);
            _enemyRb.AddForce( lookCollectible.normalized *  _enemySpeed);


            // If an enemy falls down from the platform, the game will end and the enemy will be destroyed.
            if(transform.position.y < -2)   
            {
                PlayerController.power += 1;
                Destroy(gameObject);
            }

        }
        
    }

    // When the collectible GameObject collided with the enemy, enemy gets bigger and stronger. Also destroys the collectible GameObject.
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            power++;
            _enemyRb.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }    
    }

    // Enemy adds a force towards to the player with the power of the collectible it has collected when they collide.
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Rigidbody _playerRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            _playerRb.AddForce(awayFromPlayer * power, ForceMode.Impulse);
        }    
    }

    // This method will return the closest collectibles to the enemies. When there is no collectibles left, it will return the player.
    private GameObject findClosestEnemy() 
    {
        GameObject[] objs= GameObject.FindGameObjectsWithTag("Collectible");
        player = GameObject.Find("Player");
        GameObject closestEnemy = null;
        float closestDistance = 0f;
        bool first = true;

        foreach (var obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (first)
            {
                closestDistance = distance;
                closestEnemy = obj;
                first = false;
            }
            else if (distance < closestDistance)
            {
                closestEnemy = obj;
                closestDistance = distance;
            }

        }
        if(closestEnemy == null)
        {
            return player;
        }
        else
        {
            return closestEnemy;
        }
        
     }

}
