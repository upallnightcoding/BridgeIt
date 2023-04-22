using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="Bridge It/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Game Data")]
    public int mazeSize;
}
