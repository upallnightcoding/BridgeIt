using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CoinBlank", menuName="Bridge It/Pawn/CoinBlank")]
public class CoinBlank : GamePawnSO
{
    public GameObject preFab;
    public GameObject animationPF;

    public override void AnimatePawn(Vector3 position)
    {
        Object.Instantiate(animationPF, position, Quaternion.identity);
    }

    public override void CreatePawn(Vector3 position)
    {
        Vector3 pos = new Vector3
        (
            position.x, position.y + 1.0f, position.z
        );

        Object.Instantiate(preFab, pos, Quaternion.identity);
    }

    public override void MovePawn()
    {
        
    }
}
