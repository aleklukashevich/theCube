using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRenderer : MonoBehaviour
{
    private GameObject container;
    private Camera cam;
    private GameObject part;
    private GameObject pivotPointObj;
    public BoxCollider pivotCollider;
    public float extraColliderValue = 0.1f;
    public static readonly int cubeSize = 8;
    private List<Colors> colors = new List<Colors>();

    // Start is called before the first frame update
    void Start()
    {
        part = GameObject.FindGameObjectWithTag("part");
        container = GameObject.FindGameObjectWithTag("container");
        pivotPointObj = GameObject.FindGameObjectWithTag("pivot");
        cam = Camera.main;

        //set position for pivot point
        pivotPointObj.transform.position = new Vector3(cubeSize / 2, cubeSize / 2, cubeSize / 2);

        //calculate possible colours based on size
        float possibleColorsNum = Mathf.Pow(cubeSize, 3f) / 4;
        colors.Add(new Colors(new Color(255, 0, 0), possibleColorsNum));
        colors.Add(new Colors(new Color(0, 0, 255), possibleColorsNum));
        colors.Add(new Colors(new Color(255, 255, 255), possibleColorsNum));
        colors.Add(new Colors(new Color(0, 128, 0), possibleColorsNum));

        //Generate cube
        for (int z = 0; z < cubeSize; z++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int x = 0; x < cubeSize; x++)
                {
                    this.BuildCube(x, y, z);
                }
            }
        }

        //add to cube Box Collider and set size
        pivotCollider = pivotPointObj.AddComponent<BoxCollider>();
        //part is cude with scale 1,1,1 so pivotColliderCenter should be half of it
        float cubeScaleX = -(part.transform.localScale.x / 2);
        pivotCollider.center = new Vector3(cubeScaleX, cubeScaleX, cubeScaleX);
        //set collider a bit bigger to + 0.1f to be able to drag it
        float cubeCollderSize = cubeSize + extraColliderValue;
        pivotCollider.size = new Vector3(cubeCollderSize, cubeCollderSize, cubeCollderSize);

        //make block invisible
        part.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO camera needs to be dynamicly set range to object depends on x y z length
        cam.transform.position = new Vector3(cubeSize / 2, cubeSize / 2, -(cubeSize + 5));
    }

    private void BuildCube(int x, int y, int z)
    {
        if (z > 0)
        {
        }
        GameObject cube = Object.Instantiate(GameObject.FindGameObjectWithTag("part"));
        cube.transform.localScale = new Vector3(1, 1, 1);
        cube.transform.position = new Vector3(x == 0 ? x : x, y == 0 ? y : y, z == 0 ? z : z);
        Color c = SelectColor();
        cube.transform.Find("top").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("bottom").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("left").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("right").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("front").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("back").GetComponent<Renderer>().material.color = c;
        cube.transform.parent = container.transform;
    }

    private Color SelectColor()
    {
        Colors block = colors[Random.Range(0, colors.Count)];
        if (block.possibleCountOfSameColor <= 0)
        {

            this.SelectColor();
        }
        else
        {
            block.possibleCountOfSameColor = block.possibleCountOfSameColor - 1;
        }
        return block.color;
    }
}
