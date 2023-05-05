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

    [Header("Player Attributes")]
    public float moveSpeed;
    public float rotationSpeed;

    [Header("Game Pre Fabs Attribute")]
    public float bridgeDepth;

    [Header("Game Collectables")]
    public GamePawnSO coinBlank;
    public GamePawnSO coinMoney;
    public GamePawnSO coinStar;

    [Header("Enemies")]
    public GameObject goblinPreFab;

    [Header("Game Pre Fabs")]
    public GameObject tileCrossPreFab;
    public GameObject tileStraightPreFab;
    public GameObject tileElbowPreFeb;
    public GameObject tileTeePreFeb;
    public GameObject tileEndPreFeb;
    public GameObject bridgePreFab;
    public GameObject waterPreFab;
    public GameObject waterStripPreFab;

    [Header("Water PreFabs")]
    public GameObject[] waterFwPreFab;
    public GameObject waterPreFabFw;
}
