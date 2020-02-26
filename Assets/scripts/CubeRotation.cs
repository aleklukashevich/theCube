using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(0, -90f, 0), 2 * Time.deltaTime);
    }
}
