using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGenerationRoom : MonoBehaviour
{
    int RestRoom = 0;
    List<GameObject> RoomPos;

    // Update is called once per frame
    void Update()
    {
        RoomPos = this.gameObject.GetComponent<RoomList>().RoomPrefab;
        if (RoomPos.Count <= 30 && RoomPos[RestRoom].transform.GetChild(0).transform.position.y == 0)
        {
            RestRoomIns();
        }

        if (RoomPos.Count > 30)
        {
            Destroy(this.gameObject.GetComponent<InitialGenerationRoom>());
        }
    }

    void RestRoomIns()
    {
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        //Destroy(RoomPos[RestRoom].gameObject.GetComponent<HoleRoomEven>());
        RestRoom++;
    }

    //void DoorWallIns()
    //{
    //    RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
    //    RestRoom++;
    //}
}
