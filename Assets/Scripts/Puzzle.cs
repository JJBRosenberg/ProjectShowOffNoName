using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox[,] boxes = new NumberBox[3, 3];

    public Sprite[] sprites;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        //rows for the 3x3
        int n = 0;
        for(int y =2;y>=0;y--)
        for(int x = 0; x < 3; x++)
            {
                //creates the puzzle
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n]);
                boxes[x, y] = box;
                n++;
            }
    }
}
