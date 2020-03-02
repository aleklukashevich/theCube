using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRenderer : MonoBehaviour
{
    private GameObject container;
    private Camera cam;
    private GameObject block;
    private GameObject pivotPointObj;
    public static readonly int cubeSize = 8;
    private List<Colors> colors = new List<Colors>();

    // Start is called before the first frame update
    void Start()
    {
        block = GameObject.FindGameObjectWithTag("block");
        container = GameObject.FindGameObjectWithTag("Dummy");
        pivotPointObj = GameObject.FindGameObjectWithTag("centre");
        cam = Camera.main;
        //set position for pivot point
        pivotPointObj.transform.position = new Vector3(cubeSize / 2, cubeSize / 2, cubeSize / 2);

        //make block invisible
        block.transform.localScale = new Vector3(0, 0, 0);
        
        float possibleColorsNum = Mathf.Pow(cubeSize, 3f)/4;
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
        print(container.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO camera needs to be dynamicly set range to object depends on x y z length
       cam.transform.position = new Vector3(cubeSize/2, cubeSize / 2, -(cubeSize + 5));
    }

    private void BuildCube(int x, int y, int z) {
        if (z > 0) {
        }
        GameObject cube = Object.Instantiate(GameObject.FindGameObjectWithTag("block"));
        cube.transform.localScale = new Vector3(1, 1, 1);
        cube.transform.position = new Vector3(x==0 ? x : x, y==0 ? y : y, z==0 ? z : z);
        Color c = SelectColor();
        cube.transform.Find("top").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("bottom").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("left").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("right").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("front").GetComponent<Renderer>().material.color = c;
        cube.transform.Find("back").GetComponent<Renderer>().material.color = c;
        cube.transform.parent = container.transform;
    }

    private Color SelectColor() {
        Colors block = colors[Random.Range(0, colors.Count)];
        if (block.possibleCountOfSameColor <= 0)
        {
            //print("number is 0 finding new color");
            this.SelectColor();
        }
        else {
            block.possibleCountOfSameColor = block.possibleCountOfSameColor - 1;
        }
        //print("Got: " + block.color + " and available left: " + block.possibleCountOfSameColor);
        return block.color;
    }
}
