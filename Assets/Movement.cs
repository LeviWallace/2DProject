using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> ts;
    int idx = 0;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ts[idx].position, 0.01f);
        if (Vector3.Distance(transform.position, ts[idx].position) < 0.1f && idx < ts.Count)
        {
            idx++;
        }
    }
}
