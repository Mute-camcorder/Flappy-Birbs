using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 pushUpSmall = new Vector2(0f, 1f);
    private Vector2 pushUpBig = new Vector2(0f, 4f);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(pushUpSmall);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            body.AddForce(pushUpBig);
        }
    }
}
