using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    Animator animations;
    private bool isGrounded;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    void Start()
    {
        animations = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animations.SetBool("isGrounded", isGrounded);


        // Hareket etme animasyonu
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float VerticalMovement = Input.GetAxisRaw("Vertical");
        animations.SetFloat("speed", Mathf.Sqrt(Mathf.Pow(horizontalMovement, 2) + Mathf.Pow(VerticalMovement, 2)));
    }
}
