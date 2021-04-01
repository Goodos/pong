using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.up;
    private float speed = 250f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(SetVector(), SetVector());
        transform.localScale = GetScale();
        rb.AddForce(velocity * GetSpeed());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            GameController.score++;
            Bounce(collision.contacts[0].normal);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Bounce(collision.contacts[0].normal);
        }
    }

    float SetVector()
    {
        float vector;
        if (Random.Range(0, 2) == 0)
        {
            vector = -.5f;
        }
        else
        {
            vector = .5f;
        }
        return vector;
    }

    float GetSpeed()
    {
        float newSpeed = Random.Range(3, 6);
        return newSpeed * 100f;
    }

    Vector3 GetScale()
    {
        float s = Random.Range(3, 7) / 10f;
        return new Vector3(s, s, 1f);
    }

    void Bounce(Vector2 point)
    {
        Vector2 vector = point - (Vector2)transform.position;
        velocity = -vector.normalized;
    }
}
