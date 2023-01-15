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
            // we need to be falling a little before we can jump again
            if (body.velocity.y <= -0.25f)
            {
                body.AddForce(pushUpBig);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = body.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
