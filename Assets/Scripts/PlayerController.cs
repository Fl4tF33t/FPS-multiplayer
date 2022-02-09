using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
        motor.Move(movement);
    }
}
