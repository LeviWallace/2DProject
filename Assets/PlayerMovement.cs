using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D col;

    float speed = 5f;
    float jumpspeed = 200f;
    Rigidbody2D rb;
    BoxCollider2D bc;
    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2();
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            movement += Vector2.up * jumpspeed;
            isGrounded = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left * speed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            movement += Vector2.right * speed;
        }
        Debug.Log(movement);
        rb.AddForce(movement);
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D col in collision.contacts)
        {
            if (col.normal.y > 0)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }


}
