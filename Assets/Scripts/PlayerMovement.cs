using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;


    float bottomLimit;
    float topLimit;
    float leftLimit;
    float rightLimit;

    private void Start()
    {
        //Cache of components
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        //Finds the camera limits in World Space
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomLimit = bottomLeft.y;
        leftLimit = bottomLeft.x;   

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        topLimit = topRight.y;
        rightLimit = topRight.x;

        //Adds to the limits the size of the sprite
        bottomLimit += renderer.bounds.extents.y;
        topLimit -= renderer.bounds.extents.y;
        leftLimit += renderer.bounds.extents.x;
        rightLimit -= renderer.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {       
        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime;

        //if (desiredPosition.x < leftLimit)
        //    desiredPosition.x = leftLimit;
        //else if (desiredPosition.x > rightLimit)
        //    desiredPosition.x = rightLimit;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit);

        //if (desiredPosition.y < bottomLimit)
        //    desiredPosition.y = bottomLimit;
        //else if (desiredPosition.y > topLimit)
        //    desiredPosition.y = topLimit;
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomLimit, topLimit);
        

        //Calculate movement
        rb.MovePosition(desiredPosition);       
    }
}
