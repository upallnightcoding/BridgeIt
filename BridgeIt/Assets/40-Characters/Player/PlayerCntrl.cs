using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private float speed;

    private const float GRAVITY = 9.81f;

    private CharacterController controller;

    private float verticalVelocity;

    private Vector3 direction;

    // Current Player State
    private PlayerState playerState = PlayerState.IDLE;

    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    void Update()
    {
        switch(playerState) {
            case PlayerState.IDLE:
            break;
        }

        //MovePlayer();
    }

    private void MovePlayer()
    {
        bool groundedPlayer = controller.isGrounded;

        if (groundedPlayer && verticalVelocity < 0) {
            verticalVelocity = 0.0f;
        }

        verticalVelocity -= GRAVITY * Time.deltaTime;

        direction.x = 0.0f;
        direction.y = verticalVelocity;
        direction.z = 1.0f;   

        controller.Move(direction.normalized * speed * Time.deltaTime);
    }

    private enum PlayerState {
        IDLE
    }
}
