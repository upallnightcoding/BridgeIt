using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    [SerializeField] private GameObject tileCrossPreFab;
    [SerializeField] private GameObject tileStraightPreFab;
    [SerializeField] private GameObject tileElbowPreFeb;
    [SerializeField] private GameObject tileTeePreFeb;
    [SerializeField] private GameObject tileEndPreFeb;
    [SerializeField] private GameObject bridgePreFab;
    [SerializeField] private GameObject waterPreFab;

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private int tileSize;

    private Maze maze = null;

    private void Start() 
    {
        maze = new Maze(width, height);

        maze.Generate();

        DrawMaze(maze);
    }

    private void DrawMaze(Maze maze)
    {
        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * 2 * tileSize;
                position.y = 0.0f;
                position.z = row * 2 * tileSize;

                DisplayGroundTile(col, row, position);

                if (maze.IsLinkedNorth(col, row)) {
                    Vector3 northPos = new Vector3();
                    northPos.x = position.x;
                    northPos.y = -0.30f;
                    northPos.z = position.z + tileSize;
                    Instantiate(bridgePreFab, northPos, Quaternion.identity);
                }

                if (maze.IsLinkedEast(col, row)) {
                    Vector3 eastPos = new Vector3();
                    eastPos.x = position.x + tileSize;
                    eastPos.y = -0.30f;
                    eastPos.z = position.z;
                    GameObject bridge = Instantiate(bridgePreFab, eastPos, Quaternion.identity);
                    bridge.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                }
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * 2 * tileSize + tileSize;
                position.y = -1.0f;
                position.z = row * 2 * tileSize;

                Instantiate(waterPreFab, position, Quaternion.identity);

                position.x = col * 2 * tileSize;
                position.y = -1.0f;
                position.z = row * 2 * tileSize + tileSize;

                Instantiate(waterPreFab, position, Quaternion.identity);

                position.x = col * 2 * tileSize + tileSize;
                position.y = -1.0f;
                position.z = row * 2 * tileSize + tileSize;

                Instantiate(waterPreFab, position, Quaternion.identity);
            }
        }

        for (int col = width-1; col < width; col++) {
            for (int row = 0; row < height-1; row++) {
                Vector3 position = new Vector3();
                position.x = col * 2 * tileSize;
                position.y = -1.0f;
                position.z = row * 2 * tileSize + tileSize;

                Instantiate(waterPreFab, position, Quaternion.identity);
            }
        }

        for (int col = 0; col < width-1; col++) {
            for (int row = height-1; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * 2 * tileSize + tileSize;
                position.y = -1.0f;
                position.z = row * 2 * tileSize;

                Instantiate(waterPreFab, position, Quaternion.identity);
            }
        }
    }

    private void DisplayGroundTile(int col, int row, Vector3 position) 
    {
        MazeCell cell = maze.GetMazeCell(col, row);

        GameObject go = null;

        if (cell != null) {
            int index = cell.GetMazeIndex();

            switch(index) {
                // Straight PreFab
                case 3:
                    go = Instantiate(tileStraightPreFab, position, Quaternion.identity);
                    break;
                case 12:
                    go = Instantiate(tileStraightPreFab, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 90.0f, 0.0f);
                    break;

                // Elbow PreFab
                case 5:
                    go = Instantiate(tileElbowPreFeb, position, Quaternion.identity);
                    break;
                case 9:
                    go = Instantiate(tileElbowPreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 90.0f, 0.0f);
                    break;
                case 10:
                    go = Instantiate(tileElbowPreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 180.0f, 0.0f);
                    break;
                case 6:
                    go = Instantiate(tileElbowPreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 270.0f, 0.0f);
                    break;

                // Tee PreFab
                case 7:
                    go = Instantiate(tileTeePreFeb, position, Quaternion.identity);
                    break;
                case 13:
                    go = Instantiate(tileTeePreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 90.0f, 0.0f);
                    break;
                case 11:
                    go = Instantiate(tileTeePreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 180.0f, 0.0f);
                    break;
                case 14:
                    go = Instantiate(tileTeePreFeb, position, Quaternion.identity);
                    go.transform.Rotate(0.0f, 270.0f, 0.0f);
                    break;

                // End PreFab
                case 1:
                    CreateGroundTile(tileEndPreFeb, position, 0.0f);
                    break;
                case 8:
                    CreateGroundTile(tileEndPreFeb, position, 90.0f);
                    break;
                case 2:
                    CreateGroundTile(tileEndPreFeb, position, 180.0f);
                    break;
                case 4:
                    CreateGroundTile(tileEndPreFeb, position, 270.0f);
                    break;

                default:
                    go = Instantiate(tileCrossPreFab, position, Quaternion.identity);
                    break;
            }
        }
    }

    private void CreateGroundTile(GameObject preFab, Vector3 position, float rotation) 
    {
        GameObject go = Instantiate(preFab, position, Quaternion.identity);
        go.transform.Rotate(0.0f, rotation, 0.0f);

        GroundBaseCntrl cntrl = go.GetComponent<GroundBaseCntrl>();

        if (cntrl != null) {
            
        }
    }
}


