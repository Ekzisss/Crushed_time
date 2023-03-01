using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    private float y;

    public float speed = 7f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector3(x, y);
        move.Normalize();
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
