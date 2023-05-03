using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCntrl : MonoBehaviour
{
    [SerializeField] private GameObject sparklePS;

    private float speed = 20.0f;

    private Vector3 turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = new Vector3(0.0f, speed, 0.0f);

        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y + 1.0f, 
            transform.position.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turn * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
        Instantiate(sparklePS, transform.position, Quaternion.identity);
    }
}
