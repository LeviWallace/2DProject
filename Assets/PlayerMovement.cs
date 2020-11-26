using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D col;

    float speed = 5f;
    float jumpspeed = 400f;
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
        isGrounded = Physics2D.OverlapCircle(transform.position + (Vector3.down / 3.5f), 0.4f, LayerMask.GetMask("TileMap")) != null;
        
        Vector2 movement = new Vector2();
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            movement += Vector2.up * jumpspeed;
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left * speed * (isGrounded ? 1f : 0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right * speed * (isGrounded ? 1f : 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down * speed;
        }
        rb.AddForce(movement);
        if (!isGrounded)
        {
            transform.Rotate(new Vector3(0, 0, -rb.velocity.x/5));
        }
        transform.localScale =
            new Vector3(1 + (rb.velocity.y * jumpspeed / 10000) * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                        1 + (rb.velocity.y * jumpspeed / 10000) * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                        1);
    }

}
