using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GamePawnSO : ScriptableObject
{
    public abstract GameObject CreatePawn(Vector3 position);

    public abstract void AnimatePawn(Transform transform, float deltaTime);

    public abstract void OnDestoryPawn(Vector3 position);

    public abstract GamePawnType GetGamePawnType();
}