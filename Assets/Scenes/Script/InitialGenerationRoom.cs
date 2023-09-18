using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGenerationRoom : MonoBehaviour
{
    int RestRoom = 0;
    List<GameObject> RoomPos;
    bool NextLevel = true;

    // Update is called once per frame
    void Update()
    {
        RoomPos = this.gameObject.GetComponent<RoomList>().RoomPrefab;
        if (RoomPos.Count <= 30 && RoomPos[RestRoom].transform.GetChild(0).transform.position.y == 0 && NextLevel)
        {
            RestRoomIns();
        }

        if (RoomPos.Count > 30 || !NextLevel)
        {
            LastRound();
            Destroy(this.gameObject.GetComponent<InitialGenerationRoom>());
        }
    }

    void RestRoomIns()
    {
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().DoorWall();
        RoomPos[RestRoom].gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        //Destroy(RoomPos[RestRoom].gameObject.GetComponent<HoleRoomEven>());
        RestRoom++;
        RoomLevel();
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
        List<bool> vs = new List<bool>();
        int vs2 = 0;
        for (int i = RoomPrefab.Count - 1; RoomPrefab[i].name != LastRoom; i--)
        {
            vs2++;
            if (RoomPrefab[i].tag == "One")
            {
                vs.Add(true);
            }
        }
        if (vs.Count == vs2)
        {
            NextLevel = false;
        }
    }
}
