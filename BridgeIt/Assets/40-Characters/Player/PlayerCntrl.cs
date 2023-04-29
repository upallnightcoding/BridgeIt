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

    private GroundBase currentGroundBase = null;

    private GameMaze gameMaze = null;

    // Current Player State
    private PlayerState playerState = PlayerState.IDLE;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 

        gameCamera = Camera.main;  
    }

    private void OnPlay()
    {
        playerState = PlayerState.START_GAME;
    }

    void Update()
    {
        switch(playerState) {
            case PlayerState.START_GAME:
                playerState = StartNewGame();
                break;
            case PlayerState.IDLE:
            break;
        }

        //MovePlayer();
    }

    private PlayerState StartNewGame()
    {
        gameMaze = GameManager.Instance.GetGameMaze();

        currentGroundBase = gameMaze.GetGroundBase(0, 0);

        gameObject.transform.position = currentGroundBase.GetPosition();

        return(PlayerState.IDLE);
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

    private void MovePlayerTo(GameObject selection) 
    {
        GroundBaseCntrl groundBaseCntrl = selection.GetComponent<GroundBaseCntrl>();
        GroundBase newGround = gameMaze.GetGroundBase(groundBaseCntrl);
        MazeLink mazeLink = currentGroundBase.IsNeighbor(newGround);

        if (mazeLink != null) {
            currentGroundBase = newGround;
            gameObject.transform.position = currentGroundBase.GetPosition();
        }
    }

    private void OnSelection(Vector2 mousePosition)
    {
        Ray ray = gameCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, RAYCAST_LENGTH, tileLayerMask)) {
            GameObject selection = hit.transform.gameObject;

            if (selection.CompareTag("Ground")) {
                MovePlayerTo(selection);
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

        UICntrl.OnPlay += OnPlay;   
    }

    private void OnDisable() 
    {
        InputSystem.OnSelection -= OnSelection;  

        UICntrl.OnPlay -= OnPlay;  
    }

    private enum PlayerState {
        START_GAME,
        IDLE,
        WALK_PORT,
        WALK_BRIDGE
    }
}
