using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask tileLayerMask;
    [SerializeField] private ParticleSystem waterWavePS;

    private const float RAYCAST_LENGTH = 300.0f;

    private const float GRAVITY = 9.81f;

    private float moveSpeed;
    private float rotationSpeed;

    private CharacterController controller;
    private Animator animator;

    private float verticalVelocity;

    private Vector3 direction;

    private Camera gameCamera;

    private GroundBase currentGround = null;
    private GroundBase newGround = null;

    private GameMaze gameMaze = null;

    private Vector3 portPosition;
    private Vector3 oppPortPosition;

    // Current Player State
    private PlayerState playerState = PlayerState.IDLE;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();

        gameCamera = Camera.main;  

        moveSpeed = gameData.moveSpeed;
        rotationSpeed = gameData.rotationSpeed;
    }

    void Update()
    {
        switch(playerState) {
            case PlayerState.START_GAME:
                playerState = StartNewGame();
                break;
            case PlayerState.IDLE:
                playerState = Idle();
                break;
            case PlayerState.WALK_TO_PORT:
                playerState = WalkToPort();
                break;
            case PlayerState.WALK_BRIDGE:
                playerState = WalkBridge();
                break;
        }
    }

    private PlayerState StartNewGame()
    {
        gameMaze = GameManager.Instance.GetGameMaze();

        currentGround = gameMaze.GetGroundBase(0, 0);

        gameObject.transform.position = currentGround.GetPosition();

        return(PlayerState.IDLE);
    }

    private PlayerState Idle()
    {
        animator.SetFloat("Speed", 0.0f);
        return(PlayerState.IDLE);
    }

    private PlayerState WalkToPort()
    {
        return((MoveTo(portPosition) < 0.5) ? PlayerState.WALK_BRIDGE : PlayerState.WALK_TO_PORT);
    }

    private PlayerState WalkBridge()
    {
        currentGround = newGround;

        return((MoveTo(oppPortPosition) < 0.5) ? PlayerState.IDLE : PlayerState.WALK_BRIDGE);
    }

    private void OnSelection(Vector2 mousePosition)
    {
        Ray ray = gameCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, RAYCAST_LENGTH, tileLayerMask)) {
            GameObject selection = hit.transform.gameObject;

            if (selection.CompareTag("Ground")) {
                Debug.Log($"Selection: {selection}");
                MovePlayerTo(selection);
            }

            if (selection.CompareTag("WaterWave")) {
                Debug.Log("Water Selection ...");
                Vector3 position = new Vector3(hit.point.x, 2.0f, hit.point.z);
                Instantiate(waterWavePS, hit.point, Quaternion.identity);
            }
        } 
    }

    private void MovePlayerTo(GameObject selection) 
    {
        GroundBaseCntrl groundBaseCntrl = selection.GetComponent<GroundBaseCntrl>();

        if (gameMaze != null) {
            newGround = gameMaze.GetGroundBase(groundBaseCntrl);
            MazeLink mazeLink = currentGround.IsNeighbor(newGround);

            if (mazeLink != null) {
                portPosition = currentGround.GetPortPosition(mazeLink);
                oppPortPosition = newGround.GetOppPortPosition(mazeLink);
                Debug.Log($"Port: {portPosition}");
                Debug.Log($"Port: {oppPortPosition}");
                animator.SetFloat("Speed", 1.0f);
                playerState = PlayerState.WALK_TO_PORT;
            }
        }
    }

    private float MoveTo(Vector3 position) 
    {
        float distance = Vector3.Distance(position, transform.position);
        Vector3 direction = (position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = rotation;

        bool groundedPlayer = controller.isGrounded;

        if (groundedPlayer && verticalVelocity < 0) {
            verticalVelocity = 0.0f;
        }

        verticalVelocity -= GRAVITY * Time.deltaTime;

        Vector3 forward = transform.forward;
        forward.y = verticalVelocity;

        controller.Move(forward * moveSpeed * Time.deltaTime);

        return(distance);
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


    private void OnPlay()
    {
        playerState = PlayerState.START_GAME;
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
        WALK_TO_PORT,
        WALK_BRIDGE
    }
}
