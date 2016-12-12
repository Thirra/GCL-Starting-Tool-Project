using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public enum MovementType
    {
        strafeMovement,
        rotatingMovement
    }

    public MovementType movementType;

    private Rigidbody playerRb;

    [SerializeField]
    [Range(0, 50)]
    private float movementSpeed;

    [SerializeField]
    [Range(0, 50)]
    private float strafeSpeed;

    [SerializeField]
    [Range(0, 200)]
    private float rotateSpeed;

    [SerializeField]
    [Range(0, 500)]
    private float jumpSpeed;

    [SerializeField]
    private bool rotateLeft;

    [SerializeField]
    private bool rotateRight;

    [SerializeField]
    private bool canJump;

    private void Start ()
    {
        playerRb = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
    {
        Movement();

        if (Input.GetKey("w"))
        {
            playerRb.MovePosition(transform.position + transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            playerRb.MovePosition(transform.position - transform.forward * movementSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        CheckRotation();

        if (this.transform.position.y < 0.5f && canJump == true)
        {
            Jump();
        }
    }

    void Movement()
    {
        float horizontalMovement = strafeSpeed * Input.GetAxis("Horizontal");
        float rotatingMovement = rotateSpeed * Input.GetAxis("Horizontal");

        switch (movementType)
        {
            case MovementType.strafeMovement:
                playerRb.MovePosition(transform.position + (transform.right * horizontalMovement));
                break;


            case MovementType.rotatingMovement:
                if (rotateLeft == true)
                {
                    transform.Rotate(Vector3.up * (-rotateSpeed * Time.deltaTime));
                }

                if (rotateRight == true)
                {
                    transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
                }
                break;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            playerRb.AddForce(new Vector3(0, jumpSpeed, 0));
        }
    }

    void CheckRotation()
    {
        if (Input.GetKeyDown("a"))
        {
            rotateLeft = true;
        }
        else if (Input.GetKeyUp("a"))
        {
            rotateLeft = false;
        }

        if (Input.GetKeyDown("d"))
        {
            rotateRight = true;
        }
        else if (Input.GetKeyUp("d"))
        {
            rotateRight = false;
        }
    }
}
