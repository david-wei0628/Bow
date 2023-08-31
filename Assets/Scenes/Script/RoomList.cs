using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomList : MonoBehaviour
{
    public List<Vector3> RoomPos;
    private void Start()
    {
        RoomPos.Add(Vector3.zero);
        ClassRoom.RList = RoomPos;
    }
    public void RoomData()
    {
        RoomPos.Add(ClassRoom.RV3);
        ClassRoom.RList = RoomPos;
        ClassRoom.RoomCount = RoomPos.Count;
    }
}

public class ClassRoom
{
    public static Vector3 RV3;
    public static List<Vector3> RList;
    public static int RoomCount;
}