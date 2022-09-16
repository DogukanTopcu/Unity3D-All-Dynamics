using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float mouseSensitivity = 100f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;


    public Transform cam;



    // Zıplama
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public float jumpHeight = 3f;



    private float gravity = -9.81f * 4f;


    float xRotation = 0f;
    Vector3 velocity;




    // Animations
    Animator animations;
    private float lastY;
    private bool checkJump;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animations = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();

        lastY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // yere değip değmeme değişkeni
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animations.SetBool("isGrounded", isGrounded);


        // Hareket etme animasyonu
        float horizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");
        animations.SetFloat("speed", Mathf.Sqrt(Mathf.Pow(horizontalMovement, 2) + Mathf.Pow(VerticalMovement, 2)));


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


            if (checkJump)
            {
                animations.SetBool("Jump", true);
            }
            else
            {
                animations.SetBool("Jump", false);
            }
        }



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        // Zıplama 
        if (lastY < gameObject.transform.position.y)
        {
            checkJump = true;
        }
        else
        {
            checkJump = false;
        }
        lastY = gameObject.transform.position.y;

    }
}
