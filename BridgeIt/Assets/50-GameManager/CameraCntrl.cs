using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntrl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = player.transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = player.transform.position - delta;
    }
}
