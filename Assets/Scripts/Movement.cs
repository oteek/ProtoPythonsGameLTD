using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed = 1f;
    public float rotSens = 1f;
    public Rigidbody rb;

    Vector3 direction;
    float horX, horY;
    public float kickForce = 1;
    public float kickForceIncrease = 5;
    public float kickUp = 2;
    float kickForceOld;
    bool shoot = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        kickForceOld = kickForce;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime
        horX = Input.GetAxis("Horizontal");
        horY = Input.GetAxis("Vertical");

        direction = new Vector3(horX, 0, horY);
        Vector3.Normalize(direction);
        
        //transform.Translate(horX * movSpeed * 0.01f, 0, horY * movSpeed * 0.01f);
        //transform.Translate(direction * movSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * rotSens, 0);

        /*
        if(Input.GetKey(KeyCode.W)) {
            Debug.Log("W");
            transform.Translate(0,0,0.01f);
        }
        */

        //transform.position = new Vector3(1, 2, 3);
        //transform.rotation = Quaternion.Euler(10, 20, 30);

        if(Input.GetButtonDown("Fire1")) {
            Debug.Log("Mouse1");
        }

        if(Input.GetButton("Jump")) {
            kickForce += kickForceIncrease * Time.deltaTime;
        }
        if(Input.GetButtonUp("Jump")) {
            shoot = true;
        }
    }

    void FixedUpdate() {
        rb.velocity = ((transform.forward * horY) + (transform.right * horX)) * movSpeed * Time.fixedDeltaTime + new Vector3 (0, rb.velocity.y, 0);
        //rb.AddRelativeForce(direction * movSpeed * Time.deltaTime, ForceMode.Force);
        //rb.MovePosition(transform.position + (direction * movSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if we collide with ball, we can shoot it
        if (collision.gameObject.tag == "ball")
        {
            //collision.rigidbody.AddForce(new Vector3(transform.forward.x, kickUp, transform.forward.z) * kickForce, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "goalpost")
        {
            Debug.Log("get out of there!!!");
        } 
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "ball") {
            Debug.Log("we're colliding");
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "ball") {
            Debug.Log("asdasds");
        }
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger with: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "ball") {
            if (shoot) {
                other.attachedRigidbody.AddForce(new Vector3(transform.forward.x, kickUp, transform.forward.z) * kickForce, ForceMode.Impulse);
                shoot = false;
                kickForce = kickForceOld;
            }
        }
    }
}
