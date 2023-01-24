using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 pushUpSmall = new Vector2(0f, 1f);
    private Vector2 pushUpBig = new Vector2(0f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //// we need to be falling a little before we can jump again
            //if (body.velocity.y <= -1f)
            //{
            //    body.AddForce(pushUpBig);
            //}
            body.AddForce(pushUpBig);
        }
    }

    private void FixedUpdate()
    {
        // The Player isn't actually moving, but instead the barriers and background move
        // so to calculate the beak angle we need to add in some rightwards motion
        Vector2 apparentDirection = body.velocity + Vector2.right;
        float angle = Mathf.Atan2(apparentDirection.y, apparentDirection.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -30f, 40f);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier"))
        {
            Debug.Log(collision);
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died");
        // Destroy(body);
    }
}
