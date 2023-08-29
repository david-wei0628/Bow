using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRoomGenerate : MonoBehaviour
{
    public List<GameObject> HoleRoomList;
    [SerializeField]
    private bool[] AroundBool = new bool[4];
    //0->前方|1->後方|2->左方|3->右方
    [SerializeField]
    public List<GameObject> RoomNumber;
    RoomList RL;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            HoleRoomBuilder();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            
        }
    }

    private void FixedUpdate()
    {

    }

    /// <summary>
    /// 間距10
    /// </summary>
    void HoleRoomBuilder()
    {
        Vector3 NewPos = this.transform.position;
        GameObject GrapGameObject = gameObject.transform.parent.gameObject;
        //int NextRoomType;
        //NextRoomType = Random.Range(0, HoleRoomList.Count);
        var F = new Vector3(0, 0, 10);
        var D = new Vector3(0, 0, -10);
        var L = new Vector3(-10, 0, 0);
        var R = new Vector3(10, 0, 0);

        if (AroundBool[0] && AroundRoad(F))
        {
            RangeRoom(NewPos + F, GrapGameObject);
        }
        if (AroundBool[1] && AroundRoad(D))
        {
            RangeRoom(NewPos + D, GrapGameObject);
        }
        if(AroundBool[2] && AroundRoad(L))
        {
            RangeRoom(NewPos + L, GrapGameObject);
        }
        if(AroundBool[3] && AroundRoad(R))
        {
            RangeRoom(NewPos + R, GrapGameObject);
        }

    }

    void RangeRoom(Vector3 NewPos, GameObject GrapGameObject)
    {
        var NextRoomType = Random.Range(0, HoleRoomList.Count);
        GameObject NewRoom;
        NewRoom = Instantiate(HoleRoomList[NextRoomType], NewPos, Quaternion.identity, GrapGameObject.transform);
        NewRoom.name = "HoleRoom";
        //RoomNumber.Add(NewRoom);

        ClassRoom.RV3 = this.transform.localPosition;
        GameObject.Find("RoomScenes").GetComponent<RoomList>().RoomData();

        Destroy(this.gameObject.GetComponent<HoleRoomGenerate>());
        //Destroy(this.gameObject);
    }

    bool AroundRoad(Vector3 NextRoomPos)
    {
        //var NRP = this.transform.position + NextRoomPos;
        foreach (Vector3 NRP in ClassRoom.RList)
        {
            if (NRP != this.transform.position + NextRoomPos)
            {
                return true;
            }
        }
        return false;
        //if(this.transform.position + NextRoomPos != )
    }
}