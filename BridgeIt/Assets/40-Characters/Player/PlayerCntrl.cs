using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private float speed;

    private const float GRAVITY = 9.81f;

    private CharacterController controller;
    //private Rigidbody rb;

    private float verticalVelocity;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
        //rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;

        if (groundedPlayer && verticalVelocity < 0) {
            verticalVelocity = 0.0f;
        }

        verticalVelocity -= GRAVITY * Time.deltaTime;

        //controller.Move(transform.forward * speed * Time.deltaTime); 
        direction.x = 0.0f;
        direction.y = verticalVelocity;
        direction.z = 1.0f;   

        controller.Move(direction.normalized * speed * Time.deltaTime);
    }

    private void FixedUpdate() 
    {
        //rb.AddForce(new Vector3(0.0f, 0.0f, 450.0f) * Time.deltaTime, ForceMode.Force);
    }
}
