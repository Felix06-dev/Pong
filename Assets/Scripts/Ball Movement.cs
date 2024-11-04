using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector3 lastFrameVelocity;
    private Vector3 initialVelocity;
    private int BounceCounter = 0; 
    [SerializeField] float speed = 150f;
    public Score scoreLeft;
    public Score scoreRight;
 
    void Awake()
    {
        var speed = 150f;
        body = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = GetRandomLeftRightDirection();
        Debug.Log("Random Direction (Left/Right Focused): " + randomDirection);

        body.velocity = randomDirection * speed;
    }

    Vector2 GetRandomLeftRightDirection()
    {
        float x = Random.Range(-1f, 1f);

        float y = Random.Range(-0.25f, 0.25f);

        Vector2 direction = new Vector2(x, y).normalized;

        return direction;
    }

    private void Update()
    {
        lastFrameVelocity = body.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal, collision);
        if (collision.gameObject.name == "Right Paddle" || collision.gameObject.name == "Left Paddle")
        {
            BounceCounter++;
        }
        if (collision.gameObject.name == "Score Zone Right")
        {
            transform.position = new Vector3(0f, 0f, -9.5f);
            speed = 150f;
            body.velocity = body.velocity.normalized * speed;
            BounceCounter = 0;
            scoreLeft.ChangeScoreLeft();
        }
        if (collision.gameObject.name == "Score Zone Left")
        {
            transform.position = new Vector3(0f, 0f, -9.5f);
            speed = 150f;
            body.velocity = body.velocity.normalized * speed;
            BounceCounter = 0;
            scoreRight.ChangeScoreRight();
        }
    }

    private void Bounce(Vector3 collisionNormal, Collision2D collision)
    {
        if (BounceCounter > 2 && collision.gameObject.name == "Right Paddle" || collision.gameObject.name == "Left Paddle" && BounceCounter > 2)
        {
            speed = speed + 25;
            Debug.Log(speed);
        }
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        body.velocity = direction * speed;
    }
}
