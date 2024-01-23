using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed = 200f;
    public float rotSens = 1f;
    public Rigidbody rb;

    Vector3 direction;
    float horX, horY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horX = Input.GetAxis("Horizontal");
        horY = Input.GetAxis("Vertical");

        direction = new Vector3(horX, 0, horY);
        Vector3.Normalize(direction);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * rotSens, 0);


        if(Input.GetButtonDown("Fire1")) {
            Debug.Log("Mouse1");
        }

        if(Input.GetButton("Jump")) {
            
        }
    }

    void FixedUpdate() {
        rb.velocity = ((transform.forward * horY) + (transform.right * horX)) * movSpeed * Time.fixedDeltaTime + new Vector3 (0, rb.velocity.y, 0);
    }
}
