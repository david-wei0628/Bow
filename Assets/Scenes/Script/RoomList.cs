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
    public List<GameObject> RoomPrefab;
    public GameObject StartRoom;

    private void Awake()
    {
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        //StartRoom.GetComponent<HoleRoomGenerate>().DooeWall();
        ClassRoom.RList = RoomPrefab;
    }

    public void RoomData()
    {
        RoomPrefab.Add(ClassRoom.RV3);
        ClassRoom.RList = RoomPrefab;
        ClassRoom.RoomCount = RoomPrefab.Count;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        var NUP = ClassRoom.RList.Exists(R => R.transform.position == new Vector3(10,0,0));
    //        print(NUP);
    //    }
    //}
}

public class ClassRoom
{
    public static GameObject RV3;
    public static List<GameObject> RList;
    public static int RoomCount;
}

class Room
{
    public GameObject R;
    public GameObject R1;
    public GameObject R2;
}