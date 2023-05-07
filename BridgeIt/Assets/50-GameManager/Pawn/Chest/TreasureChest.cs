using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreasureChest", menuName = "Bridge It/Pawn/Treasure Chest")]
public class TreasureChest : GamePawnSO
{
    public GameObject preFab;

    public override void AnimatePawn(Transform transform, float deltaTime)
    {
        
    }

    public override GameObject CreatePawn(Vector3 position)
    {
        return(Object.Instantiate(preFab, position, Quaternion.identity));
    }

    public override GamePawnType GetGamePawnType()
    {
        return(GamePawnType.COLLECTABLE);
    }

    public override void OnDestoryPawn(Vector3 position)
    {
        
    }
}
