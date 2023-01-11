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

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Only jump if we aren't moving up considerably
        //    if (body.velocity.y <= 0.1f) {
        //        body.AddForce(pushUpSmall);
        //    }
        //}

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // we need to be falling a little before we can jump again
            if (body.velocity.y <= -0.25f)
            {
                body.AddForce(pushUpBig);
            }
        }
    }
}
