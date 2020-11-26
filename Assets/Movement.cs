using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> ts;
    [Range(0, 1)]
    public float speed = 0.01f;

    private Vector3 firstPos;

    int idx = 0;

    void Start()
    {
        firstPos = transform.position;
        Init();
    }

    public void Init()
    {
        transform.position = firstPos;
        idx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ts[idx].position, speed);
        if (Vector3.Distance(transform.position, ts[idx].position) < 0.1f && idx < ts.Count-1)
        {
            idx++;
        }
    }
}
