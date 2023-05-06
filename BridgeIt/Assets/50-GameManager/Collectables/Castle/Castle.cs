using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Castle", menuName = "Bridge It/Pawn/Castle")]
public class Castle : GamePawnSO
{
    public GameObject preFab;

    public override void AnimatePawn(Transform transform, float deltaTime)
    {
        
    }

    public override GameObject CreatePawn(Vector3 position)
    {
        return(Object.Instantiate(preFab, position, Quaternion.identity));
    }

    public override void OnDestoryPawn(Vector3 position)
    {
        
    }
}
