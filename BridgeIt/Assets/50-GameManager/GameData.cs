using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="Bridge It/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Maze Data")]
    public int width;
    public int height;

    public int tileSize;
    public int bridgeSize;

    [Header("Game Pre Fabs")]
    public GameObject tileCrossPreFab;
    public GameObject tileStraightPreFab;
    public GameObject tileElbowPreFeb;
    public GameObject tileTeePreFeb;
    public GameObject tileEndPreFeb;
    public GameObject bridgePreFab;
    public GameObject waterPreFab;
    public GameObject waterStripPreFab;
}
