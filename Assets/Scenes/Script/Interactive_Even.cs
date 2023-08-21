using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive_Even : MonoBehaviour
{
    public GameObject MoveEven;

    private void OnTriggerEnter(Collider other)
    { 
        switch (this.gameObject.name)
        {
            case "RemakeEven":
                RemakeEven();
                break;
            case "RangeEven":
                RangeEven();
                break;
            case "TrapEven_1":
                TrapEvenEnter(1);
                break;
            case "TrapEven_3":
                TrapEvenEnter(3);
                break;
            case "TrapEven_4":
                TrapEvenEnter(4);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (this.gameObject.name)
        {
            case "TrapEven_3":
                TrapEvenExit(3);
                break;
            case "TrapEven_4":
                TrapEvenExit(4);
                break;
            default:
                break;
        }
    }

    void RemakeEven()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RangeEven()
    {        
        //this.gameObject.SetActive(false);
        if (MoveEven.transform.localEulerAngles.x == 90)
        {
            MoveEven.transform.localEulerAngles = new Vector3(30, 0, 0);
            MoveEven.transform.localPosition = new Vector3(0, 50, -20);
        }
        else/* if (MoveEven.transform.localEulerAngles.x == 90)*/
        {
            MoveEven.transform.localEulerAngles = new Vector3(90, 0, 0);
            MoveEven.transform.localPosition = new Vector3(0, 150, 0);
        }
        
    }

    void TrapEvenEnter(int value)
    {
        switch (value)
        {
            case 1:
                MoveEven.transform.position = new Vector3(340, 100, 820);
                break;
            case 3:
                MoveEven.GetComponent<UserMove>().UserSpeed = 100;
                print(MoveEven.GetComponent<UserMove>().UserSpeed);
                break;
            case 4:
                MoveEven.transform.position = new Vector3(830, 75, 540);
                break;
        }
    }

    void TrapEvenExit(int value)
    {
        switch (value)
        {
            case 3:
                MoveEven.GetComponent<UserMove>().UserSpeed =200;
                break;
            case 4:
                MoveEven.transform.position = new Vector3(760, 75, 540);
                break;
        }
    }


}
