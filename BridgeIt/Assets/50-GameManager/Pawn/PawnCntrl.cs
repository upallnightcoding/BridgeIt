using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCntrl : MonoBehaviour
{
    private GamePawnSO gamePawn = null;

    private GameObject pawn;

    private PawnState pawnState = PawnState.IDLE_PAWN;

    void Start()
    {
        //turn = new Vector3(0.0f, speed, 0.0f);

        

        //gamePawn?.CreatePawn(position);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(turn * Time.deltaTime);

        switch(pawnState) 
        {
            case PawnState.IDLE_PAWN:
                pawnState = Idle();
                break;
            case PawnState.ANIMATE_PAWN:
                pawnState = AnimatePawn(Time.deltaTime);
                break;
        }
    }

    public void Set(GamePawnSO gamePawn)
    {
        this.gamePawn = gamePawn;

        pawnState = PawnState.ANIMATE_PAWN;
    }

    private PawnState Idle()
    {
        return(PawnState.IDLE_PAWN);
    }

    private void CreatePawn(Vector3 position)
    {
        pawn = gamePawn.CreatePawn(position);

        PawnCntrl pawnCntrl = pawn.GetComponent<PawnCntrl>();
        pawnCntrl.Set(gamePawn);
    }

    private PawnState AnimatePawn(float deltaTime)
    {
        gamePawn.AnimatePawn(transform, deltaTime);

        return(PawnState.ANIMATE_PAWN);
    }

    private void OnTriggerEnter(Collider other) 
    {
        gamePawn.OnDestoryPawn(transform.position);
        
        Destroy(gameObject);
    }
     
    private enum PawnState
    {
        IDLE_PAWN,
        ANIMATE_PAWN
    }
}
