using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private float speed = 15f;
    private GameObject centre;
    private float centr = -0.5f;
    private float size = CubeRenderer.cubeSize + 0.5f;

    private void Start()
    {
        centre = GameObject.FindGameObjectWithTag("centre");
        centre.AddComponent<BoxCollider>();
        centre.GetComponent<BoxCollider>().center = new Vector3(centr, centr, centr);
        centre.GetComponent<BoxCollider>().size = new Vector3(size, size, size);
    }

    void OnMouseDrag()
    {
        float xRot = Input.GetAxis("Mouse X") * speed;
        float yRot = Input.GetAxis("Mouse Y") * speed;
        transform.Rotate(Vector3.up, -xRot, Space.World);
        transform.Rotate(Vector3.right, yRot, Space.World);
    }
}
