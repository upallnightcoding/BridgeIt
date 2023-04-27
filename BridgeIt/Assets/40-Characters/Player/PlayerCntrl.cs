using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask tileLayerMask;
    [SerializeField] private ParticleSystem waterWavePS;

    private const float RAYCAST_LENGTH = 100.0f;

    private const float GRAVITY = 9.81f;

    private CharacterController controller;

    private float verticalVelocity;

    private Vector3 direction;

    private Camera gameCamera;

    // Current Player State
    private PlayerState playerState = PlayerState.IDLE;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 

        gameCamera = Camera.main;  
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

    private void OnSelection(Vector2 mousePosition)
    {
        Ray ray = gameCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, RAYCAST_LENGTH, tileLayerMask)) {
            GameObject selection = hit.transform.gameObject;

            Debug.Log($"Tag: {selection.tag}");

            if (selection.CompareTag("Ground")) {
                Debug.Log("Ground Selection ...");
                GroundBaseCntrl groundBaseCntrl = selection.GetComponent<GroundBaseCntrl>();
                MazeCell mazeCell = groundBaseCntrl.mazeCell;
                Debug.Log($"Location (col, row) -> {mazeCell.Col},{mazeCell.Row}");
            }


            if (selection.CompareTag("WaterWave")) {
                Debug.Log("Water Selection ...");
                Vector3 position = new Vector3(hit.point.x, 2.0f, hit.point.z);
                Instantiate(waterWavePS, hit.point, Quaternion.identity);
            }
        } 
    }

    private void OnEnable() 
    {
        InputSystem.OnSelection += OnSelection;    
    }

    private void OnDisable() 
    {
        InputSystem.OnSelection -= OnSelection;    
    }

    private enum PlayerState {
        IDLE
    }
}
