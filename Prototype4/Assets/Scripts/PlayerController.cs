using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject powerupIndicator;
    public float speed;
    public float forcePower;
    public bool hasPower;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        IndicatorPosition();

        HandleMovement();

        if(transform.position.y < -10)
        {

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Powerup")
        {
            hasPower = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(countDownForPowerUp());

        }
    }
    void IndicatorPosition()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.2f, 0);
    }

    void HandleMovement()
    {

        float verticalInput = Input.GetAxisRaw("Vertical");

        rb.AddForce(cameraTransform.transform.forward * verticalInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && hasPower)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 force = (enemyRB.transform.position - transform.position).normalized;

            enemyRB.AddForce(force * forcePower,ForceMode.Impulse);
            
        }
    }

    IEnumerator countDownForPowerUp()
    {

        yield return new WaitForSeconds(6f);
        powerupIndicator.SetActive(false);
        hasPower = false;

    }
}
