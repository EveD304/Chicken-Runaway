using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        //Debug.Log("got collision");
        if (playerController != null)
        {
            Debug.Log("Car hit player!");
            playerController.ChangeHealth(-1);
        }
        //Destroy(gameObject);
        // If collided witht he player destroy the chicken
        //Destroy(other.gameObject);
        //Debug.Log("Game Over!");
        
    }
}
