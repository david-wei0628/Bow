using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Other : MonoBehaviour
{
    public List<Point> a;

}

[System.Serializable]
public class Point
{
    public List<Vector3> list;
}

[System.Serializable]
public class PointList
{
    public List<Point> list;
}

