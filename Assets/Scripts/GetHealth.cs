using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = GetComponent<PlayerController>();

        if (playerController != null)
        {
            Debug.Log("Player got health!");
            playerController.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
