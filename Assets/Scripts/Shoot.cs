using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform BallGroup;
    [SerializeField]
    private Vector3 firstPos;
    [SerializeField]
    private bool shotable;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(2.5f, 2.5f, 10); // 카메라 위치
        }
        shotable = true;
        for (int i = 0; i < BallGroup.childCount; i++) 
        {
            if (BallGroup.GetChild(i).GetComponent<Ball>().isMoving)
            {
                shotable = false;
            }
        }
            
    }
}
