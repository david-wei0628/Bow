using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomList : MonoBehaviour
{
    //public List<Vector3> RoomPos;
    public List<GameObject> RoomPos;
    public GameObject StartRoom;
    private void Start()
    {
        //RoomPos.Add(Vector3.zero);
        RoomPos.Add(StartRoom);
        //StartRoom.GetComponent<HoleRoomGenerate>().DooeWall();
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
    public static GameObject RV3;
    public static List<GameObject> RList;
    public static int RoomCount;
}
