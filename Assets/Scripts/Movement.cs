using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movSpeed = 200f;
    public float rotSens = 2f;
    public float jumpForce = 0.2f;
    public float jumpCooldown = 1f;
    public Rigidbody rb;

    Vector3 direction;
    float horX, horY;
    bool canJump = true;
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

        //Vector3 moveDirection = new Vector3(horX, 0f, horY).normalized;
        //transform.Translate(moveDirection * movSpeed * Time.deltaTime);

        HandleMouseMovement();

        if(Input.GetButton("Jump")) {
            Jump();
        }
        //Debug.Log(isGrounded);
    }

    void HandleMouseMovement() {    // peles judejimas
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //transform.Rotate(0, mouseX * rotSens, 0);
        transform.Rotate(Vector3.up * mouseX * rotSens);
        Camera.main.transform.Rotate(Vector3.left * mouseY * rotSens);
    }

    void FixedUpdate() {
        rb.velocity = ((transform.forward * horY) + (transform.right * horX)) * movSpeed * Time.fixedDeltaTime + new Vector3 (0, rb.velocity.y, 0);
    }
    void Jump()
    {
        if (canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(JumpCooldown());         //1 sekundes cooldown koroutina
        }
    }
    IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}
