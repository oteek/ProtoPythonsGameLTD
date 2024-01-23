using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed = 1f;
    public float rotSens = 1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horX = Input.GetAxis("Horizontal");
        float horY = Input.GetAxis("Vertical");
        //transform.Translate(horX * movSpeed * 0.01f, 0, horY * movSpeed * 0.01f);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(-mouseY * rotSens, 0, 0);

        /*
        if(Input.GetKey(KeyCode.W)) {
            Debug.Log("W");
            transform.Translate(0,0,0.01f);
        }
        */

        if(Input.GetButtonDown("Fire1")) {
            Debug.Log("Mouse1");
        }
    }
}
