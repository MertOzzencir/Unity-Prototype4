using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject child;
    private void Start()
    {
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotateSpeed);
       

    }

}
