using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortuga : MonoBehaviour
{

    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody2D rigi;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigi.AddForce(Vector2.right * speed);
        float velocidadLimite = Mathf.Clamp(rigi.velocity.x, -maxSpeed, maxSpeed);
        rigi.velocity = new Vector2(velocidadLimite, rigi.velocity.y);

        if (rigi.velocity.x > -0.01 && rigi.velocity.x < 0.01f) {
            speed = -speed;
            rigi.velocity = new Vector2(speed, rigi.velocity.y);
        }

        if (speed > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }   
    }
}
