using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(Vector2.left);

        System.Random random = new System.Random();
        bool upsideDown = random.Next(2) == 0;
        float offsetMagnitude = Random.Range(1f, 5f);
        float offsetSigned = offsetMagnitude * (upsideDown ? 1 : -1);
        float rotation = upsideDown ? 180 : 0;

        transform.SetPositionAndRotation(
                new Vector3(12f, offsetSigned, 0f),
                Quaternion.Euler(0f, 0f, rotation)
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
