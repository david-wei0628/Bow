using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGenerationRoom : MonoBehaviour
{
    int RestRoom = 0;
    List<GameObject> RoomPos;
    [HideInInspector]
    public bool NextLevel = false;

    // Update is called once per frame
    void Update()
    {
        RoomPos = this.gameObject.GetComponent<RoomList>().RoomPrefab;
        if (RoomPos.Count <= 30 && RoomPos[RoomPos.Count-1].transform.GetChild(0).transform.position.y == 0)
        {
            RestRoomIns();
            //RoomLevel();
        }

        if (RoomPos.Count > 30 )
        {
            LastRound();
            gameObject.GetComponent<RoomList>().Level();
            Destroy(this.gameObject.GetComponent<InitialGenerationRoom>());
        }

        //if (NextLevel)
        //{
        //    Destroy(this.gameObject.GetComponent<InitialGenerationRoom>());
        //}
    }

    void RestRoomIns()
    {
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();

        RestRoom++;
        //RoomLevel();
    }

    void LastRound()
    {
        var RoomBranch = gameObject.GetComponent<RoomList>().RoomBranch;
        var RoomPrefab = gameObject.GetComponent<RoomList>().RoomPrefab;
        var LastRoom = RoomBranch[RoomBranch.Count - 1].name;
        for (int i = RoomPrefab.Count - 1; RoomPrefab[i].name != LastRoom; i--)
        {
            if (RoomPrefab[i].tag != "One")
            {
                RoomPrefab[i].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
                RoomPrefab[i].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
            }
        }
    }

    void RoomLevel()
    {
        var RoomBranch = gameObject.GetComponent<RoomList>().RoomBranch;
        var RoomPrefab = gameObject.GetComponent<RoomList>().RoomPrefab;
        var LastRoom = RoomBranch[RoomBranch.Count - 1].name;
        //for (int i = RoomPrefab.Count - 1; RoomPrefab[i].name != LastRoom; i--)
        //{

        //}
        
    }
}
