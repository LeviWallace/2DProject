using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Vector3 velocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 limit = new Vector3(player.position.x, Mathf.Clamp(player.position.y, 0, 3), -10);
        transform.position = Vector3.SmoothDamp(
            transform.position,
            limit,
            ref velocity,
            0.5f);
    }
}
