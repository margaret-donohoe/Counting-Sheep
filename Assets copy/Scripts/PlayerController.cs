using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    public GameObject visibleRange;
    [SerializeField]
    private int herdCount;
    //public GameObject followPoint;

    private string pColor;

    void Start()
    {
        //GET CHARACTER COLOR FROM PLAYERNETWORKING!!!!!

        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.FindWithTag("Ground").transform;
        visibleRange.SetActive(false);
    }

    void Update()
    {

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
        controller.Move(move * speed * Time.deltaTime);

        Vector3 rotation = new Vector3(0, rot * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        //Sheep will follow if within certain distance!
        if (Input.GetButtonDown("Fire1"))
        {
            visibleRange.SetActive(true);
            StartCoroutine(TurnOffRange());
            GameObject[] spawnedSheep = GameObject.FindGameObjectsWithTag("Sheep");

            foreach (GameObject sheep in spawnedSheep)
            {
                if (Vector3.Distance(sheep.transform.position, gameObject.transform.position) < 4 && sheep.GetComponent<SheepController>().GetDiscoverable() == true)
                {
                    sheep.GetComponent<SheepController>().FollowPlayer(gameObject);

                    //change herdCount based on sheep.GetComponent<SheepController>().GetColor()
                    herdCount++;
                    Debug.Log(herdCount.ToString());
                }
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator TurnOffRange()
    {
        yield return new WaitForSeconds(1f);
        visibleRange.SetActive(false);
    }
}
