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
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            foreach (Vector3 NRP in ClassRoom.RList)
            {
                print(NRP);
            }
        }
    }
}

public class ClassRoom
{
    public static Vector3 RV3;
    public static List<Vector3> RList;
}