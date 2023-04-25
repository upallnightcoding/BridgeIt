using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCntrl : MonoBehaviour
{
    [SerializeField] private LayerMask tileLayerMask;

    private const float RAYCAST_LENGTH = 100.0f;

    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSelection(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, RAYCAST_LENGTH, tileLayerMask)) {
            GameObject selection = hit.transform.gameObject;

            if (selection.CompareTag("Ground")) {
                Transform selected = selection.transform.Find("Selection");
                selected.transform.gameObject.SetActive(true);
            }
        } 
    }

    private void OnEnable() 
    {
        InputSystem.OnSelection += OnSelection;    
    }

    private void OnDisable() 
    {
        InputSystem.OnSelection -= OnSelection;    
    }
}
