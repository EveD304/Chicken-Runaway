using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    [SerializeField] private float speed = 25.0f;
    private float xRange = 10;


    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
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

        //Instantiate projectiles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player (with adjusted height(y axis))
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
