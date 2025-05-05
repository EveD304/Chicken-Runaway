using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Debug.Log("Player got health!");
            playerController.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
