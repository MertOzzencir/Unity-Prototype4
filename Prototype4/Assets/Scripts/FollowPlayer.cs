using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody rb;
    public float speed;
    public bool canPush;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {

        HandleMovement();

        if (transform.position.y < -10)
        {
            Destroy(gameObject); 

        }
    }

    void HandleMovement()
    {
        if(player != null)
        {
            Vector3 distance = (player.transform.position - transform.position).normalized;

            rb.AddForce(distance * Time.deltaTime * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (canPush)
            {

                Vector3 direction = (collision.gameObject.transform.position - transform.position).normalized;
                Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
                playerRb.AddForce(direction * Time.deltaTime * speed);

            }
        }
        
    }
}
