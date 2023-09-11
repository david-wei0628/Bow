using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room Even:Collider Tigger
/// New Advance Room Instantiate
/// </summary>
public class HoleRoomEven : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
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
                //this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
                break;
        }
        //this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
        Destroy(this.gameObject.GetComponent<HoleRoomEven>());
    }

    void OneRoomEven()
    {

    }
    void TwoRoomEven()
    {
        this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
    }
    void ThreeRoomEven()
    {
        this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
    }
    void FourRoomEven()
    {
        this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
    }
}
