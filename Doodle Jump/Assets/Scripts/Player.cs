using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public float movementSpeed = 10f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    float movement = 0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (movement < 0)
        {
            sr.flipX = true;
        } else if (movement>0) sr.flipX = false;
	}

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        Vector3 leftPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f,Camera.main.pixelHeight / 2,0f));
        Vector3 rightPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,Camera.main.pixelHeight / 2,0f));

        if(rb.transform.position.x <= leftPoint.x)
        {
            Vector3 newPos = new Vector3(rightPoint.x,rb.transform.position.y,rb.transform.position.z);
            rb.transform.position = newPos;
        }else
        if((rb.transform.position.x >= rightPoint.x))
        {
            Vector3 newPos = new Vector3(leftPoint.x,rb.transform.position.y,rb.transform.position.z);
            rb.transform.position = newPos;
        }
    }

}
