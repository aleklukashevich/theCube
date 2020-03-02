using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool rotate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == -90) {
            rotate = false;
        }
        if (rotate) {
            transform.Rotate(Vector3.down, Space.Self);
        }
    }
}
