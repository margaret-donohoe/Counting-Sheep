using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    public float rotationSpeed = 50.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 cameraOffset = new Vector3(1, 2, 1);

    //private Animator animator = null;
    private Timer timer;

    //private AudioSource microphone = null;
    private AnimationController animations = null;

    //public GameObject followPoint;

    void Start()
    {
        //GET CHARACTER COLOR FROM PLAYERNETWORKING!!!!!
        timer = GameObject.FindObjectsOfType<Timer>()[0];

        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.FindWithTag("Ground").transform;
        
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        if (GetComponentInChildren<AnimationController>() != null && animations == null)
        {

            animations = GetComponentInChildren<AnimationController>();
        }

        // Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset the falling velocity when grounded
        }

        // Get input for movement (WASD or Arrow Keys)
        //float moveX = Input.GetAxis("Horizontal");
        float rot = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        
        //Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 move = transform.forward * moveZ;

        if (moveZ > 0)
        {
            animations.Move();
        }
        controller.Move(move * speed * Time.deltaTime);

        Vector3 rotation = new Vector3(0, rot * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        // Jumping
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animations.Jump();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }


        //Sheep will follow if within certain distance!
        if (Input.GetButtonDown("Fire1"))
        {
            animations.Call();
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (timer.IsFinished() == true)
        {
            animations.Sleep();
        }
    }

    
}
