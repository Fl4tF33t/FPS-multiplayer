using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float movementSpeed = 12f;
    float gravity = -9.18f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("First Person Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
        characterController.Move(movement * movementSpeed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
