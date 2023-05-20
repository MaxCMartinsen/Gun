using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private CharacterController controller;
    public Camera cam;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 10.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Move = transform.TransformDirection(Move);
        controller.Move(Move * Time.deltaTime * playerSpeed);

        // Grounded Player not working probally
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -0.3f * gravityValue);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 8;
        } else
        {
            playerSpeed = 5;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            cam.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }else
        {
            cam.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
