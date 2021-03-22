using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is comment for first game class
public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(-3, 0, 0);
    public float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // 1 is for right, -1 is for left, 0 is no key pressed
        float verticalDx = Input.GetAxisRaw("Horizontal") / Time.deltaTime;
        transform.position += new Vector3(verticalDx, 0, 0);
    }
}
