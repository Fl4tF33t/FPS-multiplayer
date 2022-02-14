using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 playerRotation = Vector3.zero;
    Vector3 cameraRotation = Vector3.zero;

    [SerializeField] Camera cam;
   
    Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    public void Move (Vector3 playerVelocity)
    {
        velocity = playerVelocity;
    }
    public void PlayerRotate(Vector3 rotatePlayer)
    {
        playerRotation = rotatePlayer;
    }

    public void CameraRotate(Vector3 rotateCamera)
    {
        cameraRotation = rotateCamera;
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            playerRB.MovePosition(playerRB.position + velocity * Time.deltaTime);
        }
    }

    void PerformRotation()
    {

        playerRB.MoveRotation(transform.rotation * Quaternion.Euler(playerRotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}
