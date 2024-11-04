using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleMovement : MonoBehaviour
{
    [SerializeField] float speed = 200f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(0, speed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector2(0, -speed);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
        Vector2 clampedPosition = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -192, 192));
        transform.position = clampedPosition;
    }
}
