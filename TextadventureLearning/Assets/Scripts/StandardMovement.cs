using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D playerCollider;
    private float vertical;
    private float horizontal;

    [SerializeField] private int movementSpeed = 5;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = new Vector2(vertical * movementSpeed, horizontal * movementSpeed);
    }
}
