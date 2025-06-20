using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    float xInput;
    float yInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();

    }
    private void FixedUpdate()
    {
        Move();
    }
    public void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    public void Move()
    {
            rb.velocity = new Vector2(xInput * speed, yInput * speed);
    }
}
