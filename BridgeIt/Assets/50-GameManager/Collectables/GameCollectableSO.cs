using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameCollectable", menuName="Bridge It/Collectable")]
public class GameCollectableSO : ScriptableObject
{
    public GameObject preFab;
    public GameObject animationPF;

    public void CreatePreFab(Vector3 position)
    {
        Object.Instantiate(preFab, position, Quaternion.identity);
    }

    public void AnimationPreFab(Vector3 position)
    {
        Object.Instantiate(animationPF, position, Quaternion.identity);
    }
}