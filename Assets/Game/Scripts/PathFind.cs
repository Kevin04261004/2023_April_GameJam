//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PathFind : MonoBehaviour
//{
//    private Node[,] NodeArray;
//    public Vector2Int bottomLeft, topRight;
   
//    int sizeX, sizeY;

//    private void Start()
//    {
//        StartFinding();
//    }
//    public void StartFinding()
//    {
//        sizeX = topRight.x - bottomLeft.x + 1;
//        sizeY = topRight.y - bottomLeft.y + 1;
//        NodeArray = new Node[sizeX, sizeY];

//        for(int i = 0; i <sizeX;i++)
//        {
//            for(int j=0;j <sizeY;j++)
//            {
//                bool isEnemy = false;
//                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + bottomLeft.x, j + bottomLeft.y), 0.4f))
//                    if (col.gameObject.CompareTag("Enemy")) isEnemy = true;

//                NodeArray[i, j] = new Node(isEnemy, i + bottomLeft.x, j + bottomLeft.y);
//                //print("NodeArray" + i + ", " + j + ":  " + NodeArray[i, j].isEnemy + NodeArray[i, j].x + NodeArray[i, j].y);
//            }
//        }
//    }
//}