using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public GameObject bloodEffect;

    public float speed;
    private Vector2 moveVelocity;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
    }

    public void Hurt()
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }
}
