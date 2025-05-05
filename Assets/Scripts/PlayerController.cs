using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float horizontalInput;
    [SerializeField] private float speed = 25.0f;
    private float xRange = 10;

    // Health
    public int health;
    public int maxHealth = 3;
    private int currentHealth;

    //Invinsible state
    private bool isInvincible = false;
    private float timeInvincible = 4.0f;
    private float invincibleTimer;


    //public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Move character horizontally inside the borders
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Check if player is still invincible
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        ////Instantiate projectiles
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Launch a projectile from the player (with adjusted height(y axis))
        //    Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), projectilePrefab.transform.rotation);
        //}
    }

    internal void ChangeHealth(int change)
    {
        if (change < 0)
        {
            if (isInvincible) { return; }

            health--;

            if (health < 1)
            {
                Destroy(gameObject);
            }
            else
            { 
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
                
        }
        else
        {
            health++;

            if (health == maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
