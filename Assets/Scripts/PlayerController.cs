using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float mouseSpeed = 20f;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement 
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 horizontalMove = transform.right * horizontalMovement;
        Vector3 verticalMove = transform.forward * verticalMovement;
        Vector3 movement = (horizontalMove + verticalMove).normalized * movementSpeed;
        motor.Move(movement);

        //player rotation on y axis
        float mouseX = Input.GetAxisRaw("Mouse X");
        Vector3 yRotation = new Vector3(0f, mouseX, 0f) * mouseSpeed;
        motor.PlayerRotate(yRotation);

        //camera rotation on x axis
        float mouseY = Input.GetAxisRaw("Mouse Y");
        Vector3 xRotation = new Vector3(mouseY, 0f, 0f) * mouseSpeed;
        motor.CameraRotate(xRotation);
    }
}

