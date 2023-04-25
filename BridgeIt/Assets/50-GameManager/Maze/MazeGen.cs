using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    [SerializeField] private GameObject tileCrossPreFab;
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

        DrawMaze();
    }

    private void DrawMaze()
    {
        for (int col = 0; col < width; col++) {
            for (int row = 0; row < height; row++) {
                Vector3 position = new Vector3();
                position.x = col * 2 * tileSize;
                position.y = 0.0f;
                position.z = row * 2 * tileSize;

                Instantiate(tileCrossPreFab, position, Quaternion.identity);

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
}
