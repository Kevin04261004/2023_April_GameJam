using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class Node
{
    public Node(bool _isEnemy, int _x, int _y) { isEnemy = _isEnemy; x = _x;y = _y; }
    public int x, y; //��ǥ.
    public bool isEnemy; // ���� �����ϴ°�?
}
