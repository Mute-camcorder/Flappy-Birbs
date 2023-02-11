using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.left);

        System.Random random = new System.Random();
        float offset = Random.Range(-3f, 3f);

        transform.SetPositionAndRotation(
                new Vector3(12f, offset, 0f),
                Quaternion.identity
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawner"))
        {
            Destroy(this.gameObject);
        }
    }
}
