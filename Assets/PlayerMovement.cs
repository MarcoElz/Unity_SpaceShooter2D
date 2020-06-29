using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        //Calculate movement
        rb.MovePosition(transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime);
    }
}
