using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room Even:Collider Tigger
/// New Advance Room Instantiate
/// </summary>
public class HoleRoomEven : MonoBehaviour
{
    public GameObject Box;
    Vector3 RoomBoxPos = new Vector3(2.7f, 0, 2);
    private void OnTriggerEnter(Collider other)
    {
        //if (!GameObject.Find("RoomScenes").GetComponent<InitialGenerationRoom>())
        if (ClassRoom.RList.Count < 30)
        {
            if (ClassRoom.RList.Exists(R => R.transform.position == this.transform.position))
            {
                this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
            }

        }

        switch (gameObject.tag)
        {
            case "One":
                OneRoomEven();
                break;
            case "Two":
                TwoRoomEven();
                break;
            case "Three":
                ThreeRoomEven();
                break;
            case "Four":
                FourRoomEven();
                break;
            default://OR case "StartOne":

                Destroy(this.gameObject.GetComponent<HoleRoomEven>());
                break;
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }

    void OneRoomEven()
    {
        GameObject BoxIns = Instantiate(Box, RoomBoxPos + this.transform.position, Quaternion.identity, this.gameObject.transform);
        //Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }
    void TwoRoomEven()
    {
        GameObject BoxIns = Instantiate(Box, RoomBoxPos + this.transform.position, Quaternion.identity, this.gameObject.transform);
        //if (ClassRoom.RList.Count > 30)
        //{
        //    this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        //}
        //Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }
    void ThreeRoomEven()
    {
        GameObject BoxIns = Instantiate(Box, RoomBoxPos + this.transform.position, Quaternion.identity, this.gameObject.transform);
        //if (ClassRoom.RList.Count > 30)
        //{
        //    this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        //}
        //Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }
    void FourRoomEven()
    {
        GameObject BoxIns = Instantiate(Box, RoomBoxPos + this.transform.position, Quaternion.identity, this.gameObject.transform);
        //if (ClassRoom.RList.Count > 30)
        //{
        //    this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        //}
        //Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }
}
