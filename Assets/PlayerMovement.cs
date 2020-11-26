using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D col;
    public GameObject light;

    float speed = 5f;
    public float jumpspeed = 400f;
    Rigidbody2D rb;
    BoxCollider2D bc;
    private Vector3 checkpointPos;
    public bool isGrounded = true;

    public float jumpTimer = 1.0f;


    void Start()
    {
        checkpointPos = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Init()
    {
        transform.position = checkpointPos;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        rb.velocity = Vector2.zero;
        light.GetComponent<Movement>().Init();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position + (Vector3.down / 3.5f), 0.4f, LayerMask.GetMask("TileMap")) != null;
        Vector2 movement = new Vector2();
        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            jumpTimer += 0.01f;
            jumpTimer = Mathf.Clamp(jumpTimer, 0, .25f);
            transform.localScale = new Vector3(1, 1 - jumpTimer, 1);
        }
        if (isGrounded && Input.GetKeyUp(KeyCode.W))
        {
            movement += Vector2.up * jumpspeed * jumpTimer * 5;
            transform.localScale = new Vector3(1, jumpTimer, 1);
            jumpTimer = 1.0f;
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
            movement += Vector2.down * speed * 0.2f;
        }
        rb.AddForce(movement);
        if (!isGrounded)
        {
            transform.Rotate(new Vector3(0, 0, rb.velocity.y/20 * Mathf.Sign(rb.velocity.x)));
        }
        if (Vector3.Distance(light.transform.position, transform.position) > 15)
        {
            Init();
        }
        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1, 1, 1), 0.1f);
        /*
        transform.localScale =
            new Vector3(Mathf.Clamp(1 + rb.velocity.y * jumpspeed / 10000 *
                            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                            0.5f, 1.5f),
                        Mathf.Clamp(1 + rb.velocity.y * jumpspeed / 10000 *
                        Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                            0.5f, 1.5f),
                        1);
         */
    }

}
