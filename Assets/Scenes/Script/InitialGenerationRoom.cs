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
        RoomPos = this.gameObject.GetComponent<HoleRoomList>().RoomPrefab;

        //if (/*RoomPos.Count <= 30 && */RoomPos[RoomPos.Count-1].transform.GetChild(0).transform.position.y == 0)
        if (RoomPos[RoomPos.Count - 1].transform.GetChild(0).transform.position.y == 0 && RestRoom < RoomPos.Count)
        {
            RestRoomIns();
        }

        if (RoomPos.Count > 30 || RestRoom == RoomPos.Count)
        {
            LastRound();
            Destroy(this.gameObject.GetComponent<InitialGenerationRoom>());
        }
    }

    void RestRoomIns()
    {
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        RestRoom++;
    }

    void LastRound()
    {
        var RoomBranch = gameObject.GetComponent<HoleRoomList>().RoomBranch;
        var RoomPrefab = gameObject.GetComponent<HoleRoomList>().RoomPrefab;
        var LastRoom = RoomBranch[RoomBranch.Count - 1].name;
        //for (int i = RoomPrefab.Count - 1; RoomLevel[i] == LastLevel; i--)
        for (int i = RoomPrefab.Count - 1; RoomPrefab[i].name != LastRoom; i--)
        {
            if (RoomPrefab[i].tag != "One")
            {
                RoomPrefab[i].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
                RoomPrefab[i].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
            }
        }

        //gameObject.GetComponent<HoleRoomList>().Level();
    }

    void levelBool()
    {
        var LVBool = gameObject.GetComponent<HoleRoomList>().NextRoomIns;
        var RoomBranch = gameObject.GetComponent<HoleRoomList>().RoomBranch;
        var RoomPrefab = gameObject.GetComponent<HoleRoomList>().RoomPrefab;
        var Level = gameObject.GetComponent<HoleRoomList>().RoomLevel;


    }

}
