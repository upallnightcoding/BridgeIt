using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GamePawnSO : ScriptableObject
{
    public abstract void CreatePawn(Vector3 position);

    public abstract void AnimatePawn(Vector3 position);

    public abstract void MovePawn();
}