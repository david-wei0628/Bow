using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListType2 : MonoBehaviour
{
    public List<GameObject> RoomObject = new();

    public GameObject RoomObjectInital(int RoomId)
    {
        return Instantiate(RoomObject[RoomId], Vector3.zero, Quaternion.identity, this.gameObject.transform);
    }

    public void MiniMapPlane()
    {
        var RoomPrefab = this.gameObject.GetComponent<HoleRoomList>().RoomPrefab;

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Quaternion PlaneRot = Quaternion.identity;

        PlaneRot.eulerAngles = new Vector3(180, 0, 0);
        plane.layer = 6;

        var LastLevel = this.gameObject.GetComponent<HoleRoomList>().LastLevel;
        var LevelList = this.gameObject.GetComponent<HoleRoomList>().RoomLevel;
        gameObject.GetComponent<HoleRoomList>().RoomEven = false;
        for (int i = LevelList.Count - 1; LevelList[i] >= LastLevel - 1; i--)
        {
            if (RoomPrefab[i].tag == "One")
            {
                //Instantiate(plane, RoomPrefab[i].transform.position + Vector3.down, PlaneRot, GameObject.Find("MiniMapGraup").transform);
                Instantiate(plane, RoomPrefab[i].transform.position + Vector3.down, PlaneRot, GameObject.Find("MiniMapPlane").transform);
            }
        }
        Destroy(plane, 0.1f);
    }
}
