using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRoomEven : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
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
        }

        this.gameObject.GetComponent<HoleRoomGenerate>().HoleRoomBuilder();
    }

    void OneRoomEven()
    {

    }
    void TwoRoomEven()
    {

    }
    void ThreeRoomEven()
    {

    }
    void FourRoomEven()
    {

    }
}
