using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRenderer : MonoBehaviour
{
    private GameObject dummy;
    private Camera cam;
    public static readonly int cubeSize = 8;
    private List<Colors> colorz = new List<Colors>();
    private int startPoint = 0;
    private static List<Color> colors = new List<Color> {
        new Color(255,0,0),//Red
        new Color(0,0,255),//Blue
        new Color(255,255,255),//White
        new Color(0,128,0),//Green
        //new Color(255,255,0),//Yellow
        //new Color(255,165,0)//Orange
    };

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        dummy = GameObject.FindGameObjectWithTag("Dummy");
        float c = Mathf.Pow(cubeSize, 3f)/4;
        colorz.Add(new Colors(new Color(255, 0, 0), c));
        colorz.Add(new Colors(new Color(0, 0, 255), c));
        colorz.Add(new Colors(new Color(255, 255, 255), c));
        colorz.Add(new Colors(new Color(0, 128, 0), c));

        for (int z = startPoint; z < cubeSize; z++)
        {
            for (int y = startPoint; y < cubeSize; y++)
            {
                for (int x = startPoint; x < cubeSize; x++)
                {
                    this.BuildCube(x, y, z);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       cam.transform.position = new Vector3(cubeSize/2, cubeSize / 2, -10);
    }
    private void BuildCube(int x, int y, int z) {
        if (z > 0) {
        }
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(1, 1, 1);
        cube.transform.position = new Vector3(x==0 ? x : x, y==0 ? y : y, z==0 ? z : z);
        cube.GetComponent<Renderer>().material.color = SelectColor();

        cube.transform.parent = dummy.transform;
    }

    private Color SelectColor() {
        Colors block = colorz[Random.Range(0, colorz.Count)];
        if (block.possibleCountOfSameColor <= 0)
        {
            print("number is 0 finding new color");
            this.SelectColor();
        }
        else {
            block.possibleCountOfSameColor = block.possibleCountOfSameColor - 1;
        }
        print("Got: " + block.color + " and available left: " + block.possibleCountOfSameColor);
        return block.color;
    }
}
