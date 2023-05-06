using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CoinBlank", menuName="Bridge It/Pawn/CoinBlank")]
public class CoinBlank : GamePawnSO
{
    public GameObject preFab;
    public GameObject onDestroyPF;
    public float turnSpeed;

    public override void AnimatePawn(Transform transform, float deltaTime)
    {
        transform.Rotate(0.0f, 5.0f * turnSpeed * deltaTime, 0.0f);
    }

    public override GameObject CreatePawn(Vector3 position)
    {
        Vector3 pos = new Vector3
        (
            position.x, position.y + 1.0f, position.z
        );

        return(Object.Instantiate(preFab, pos, Quaternion.identity));
    }

    public override void OnDestoryPawn(Vector3 position)
    {
        Object.Instantiate(onDestroyPF, position, Quaternion.identity);
    }
}
