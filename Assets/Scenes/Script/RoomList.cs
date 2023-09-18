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
    public List<AroundBool> StartAround = new List<AroundBool>();
    public List<GameObject> RoomPrefab;
    public List<GameObject> RoomBranch;
    //public List<GameObject> ParentRoomPrefab;
    private void Awake()
    {
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        RoomBranch.Add(StartRoom);
        ClassRoom.RList = RoomPrefab;
    }

    public void RoomData()
    {
        RoomPrefab.Add(ClassRoom.RV3);
        RoomBranch.Add(ClassRoom.RBG);
        ClassRoom.RList = RoomPrefab;   
        ClassRoom.RoomCount = RoomPrefab.Count;
    }

    public void RA()
    {
        AroundBool Around = new AroundBool();
        Around.list = ClassRoom.RoomAround;
        StartAround.Add(Around);
    }

}

public class ClassRoom
{
    public static GameObject RV3;
    public static GameObject RBG;
    public static List<GameObject> RList;
    public static int RoomCount;
    public static bool[] RoomAround = new bool[4];
}

[System.Serializable]
public class AroundBool
{
    //public List<bool> list = new List<bool>(ClassRoom.RoomAround.Length);
    public bool[] list = new bool[4];
}
