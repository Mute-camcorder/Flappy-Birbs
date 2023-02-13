using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    public GameController gameController;
    private Rigidbody2D body;
    private Vector2 pushUpSmall = new Vector2(0f, 1f);
    private Vector2 pushUpBig = new Vector2(0f, 5f);

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
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
        var birbBody = GetComponent<Rigidbody2D>();
        birbBody.simulated = false;
        gameController.GameOver();
    }

    private void OnJump()
    {
        Debug.Log("Jump!");
        body.AddForce(pushUpBig);
    }
}
