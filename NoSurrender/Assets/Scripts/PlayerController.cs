using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed;

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public bool hasCollectible = false;
    public static int power = 0;


    private void Awake() 
    {
        isGameOver = false;
    }


    private void Start() 
    {
        _joystick = FindObjectOfType<FloatingJoystick>();
        _playerRb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate() 
    {
        // Player movement using a joystick.
        _playerRb.velocity = new Vector3(_joystick.Horizontal * _speed, 0, _joystick.Vertical * _speed);

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_playerRb.velocity.normalized);
        }   
    }


    private void Update() 
    {
        GameObject[] enemies= GameObject.FindGameObjectsWithTag("Enemy");

        // If there are no enemies left on the platform, the game will end.
        if(enemies.Length == 0)
        {
            isGameOver = true;
        }

        // If the player falls down from the platform, the game will end and the player will be destroyed.
        if(transform.position.y < -2)   
        {
            Enemy.power++;
            Destroy(gameObject);
            isGameOver = true;
        }
    }

    // When the collectible GameObject collided with the player, player gets bigger and stronger. Also destroys the collectible GameObject.
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Collectible"))
        {
            hasCollectible = true;
            Destroy(other.gameObject);
            power++;
            _playerRb.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }    
    }

    // Player adds a force towards to the enemy with the power of the collectible it has collected when they collide.  
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") && hasCollectible)
        {
            Rigidbody _enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            _enemyRb.AddForce(awayFromPlayer * power, ForceMode.Impulse);
        }    
    }
}
