using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    private Node[,] NodeArray;
    public Vector2Int bottomLeft, topRight;
   
    int sizeX, sizeY;
    public void StartFinding()
    {
        sizeX = topRight.x - bottomLeft.x + 1;
        sizeY = topRight.y - bottomLeft.y + 1;
        NodeArray = new Node[sizeX, sizeY];

    }
}