using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// passive script 
/// Only Save Room Date
/// </summary>
public class RoomList : MonoBehaviour
{
    //public List<Vector3> RoomPos;
    public GameObject StartRoom;
    public List<bool> StartAround = new List<bool>(ClassRoom.RoomAround);
    public List<GameObject> RoomPrefab;
    //public List<GameObject> ParentRoomPrefab;

    private void Awake()
    {
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        //RoomPrefab.Add(StartRoom, StartAround);
        ClassRoom.RList = RoomPrefab;
    }

    public void RoomData()
    {
        RoomPrefab.Add(ClassRoom.RV3);
        //RoomPrefab.Add(ClassRoom.RV3, ClassRoom.RoomAround);
        ClassRoom.RList = RoomPrefab;
        ClassRoom.RoomCount = RoomPrefab.Count;
    }
   
}

public class ClassRoom
{
    public static GameObject RV3;
    public static List<GameObject> RList;
    public static int RoomCount;
    public static bool[] RoomAround = new bool[4];
}