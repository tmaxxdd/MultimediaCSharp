using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is comment for first game class
public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(-1.68f, 0.32f, 1);

    public float movementSpeed = 1;
    public float maxTop = 3;
    public float minBottom = 0.32f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // 1 is for right, -1 is for left, 0 is no key pressed
        float horizontalDx = Input.GetAxisRaw("Horizontal") / Time.deltaTime;
        float verticalDx = Input.GetAxisRaw("Vertical") / Time.deltaTime;

        setHorizontalPositionWithLeftBarrier(horizontalDx);
        setVerticalPositionWithBarriers(verticalDx);
    }

    void setHorizontalPositionWithLeftBarrier(float horizontalDx)
    {
        // Move user via vector
        transform.position += new Vector3(horizontalDx * movementSpeed, 0, 0);
        Vector3 current = transform.position;
        // Don't allow to move too much on left
        if (current.x < startPosition.x)
        {
            Vector3 corrected = new Vector3(startPosition.x, current.y, current.z);
            transform.position = corrected;
        }
    }

    void setVerticalPositionWithBarriers(float verticalDx)
    {
        // Move user via vector
        transform.position += new Vector3(0, verticalDx * movementSpeed, 0);
        Vector3 current = transform.position;

        // Block top
        if (current.y > maxTop)
        {
            Vector3 corrected = new Vector3(current.x, maxTop, current.z);
            transform.position = corrected;
        }

        // Block bottom
        if (current.y < minBottom)
        {
            Vector3 corrected = new Vector3(current.x, minBottom, current.z);
            transform.position = corrected;
        }
    }
}
