using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive_Even : MonoBehaviour
{
    public GameObject ModelEven;

    private void OnTriggerEnter(Collider other)
    { 
        switch (this.gameObject.name)
        {
            case "RemakeEven":
                RemakeEven();
                break;
            case "RangeEven":
                UserCameraEven();
                break;
            case "TrapEven_1":
                TrapEvenEnter(1);
                break;
            case "TrapEven_2":
                TrapEvenEnter(2);
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

    void UserCameraEven()
    {        
        //this.gameObject.SetActive(false);
        if (ModelEven.transform.localEulerAngles.x == 90)
        {
            //ModelEven.transform.localEulerAngles = new Vector3(30, 0, 0);
            //ModelEven.transform.localPosition = new Vector3(0, 50, -20);
            ModelEven.transform.localEulerAngles = new Vector3(0, 0, 0);
            ModelEven.transform.localPosition = new Vector3(0, 30, -60);
        }
        else/* if (MoveEven.transform.localEulerAngles.x == 90)*/
        {
            ModelEven.transform.localEulerAngles = new Vector3(90, 0, 0);
            ModelEven.transform.localPosition = new Vector3(0, 150, 0);
        }
        
    }

    void TrapEvenEnter(int value)
    {
        switch (value)
        {
            case 1:
                ModelEven.transform.position = new Vector3(340, 100, 820);
                break;
            case 2:
                var RangeEvenNumber = Random.Range(0, 5);
                RangeEven(RangeEvenNumber);
                break;
            case 3:
                ModelEven.GetComponent<UserMove>().UserSpeed = 100;
                break;
            case 4:
                //ModelEven.GetComponent<Animator>().enabled = true;
                ModelEven.GetComponent<Animator>().SetBool("Open", true);
                //ModelEven.gameObject.transform.position += new Vector3(70, 0, 0);
                break;
        }
    }

    void TrapEvenExit(int value)
    {
        switch (value)
        {
            case 3:
                ModelEven.GetComponent<UserMove>().UserSpeed =200;
                break;
            case 4:
                ModelEven.GetComponent<Animator>().SetBool("Close", true);
                //ModelEven.gameObject.transform.position -= new Vector3(70, 0, 0);
                break;
        }
    }

    void RangeEven(int RangeResult)
    {
        switch (RangeResult)
        {
            case 0:
                ModelEven.GetComponent<UserMove>().UserSpeed += 10;
                break;
            case 1:
                TrapEvenEnter(1);
                break;
            case 2:
                TrapEvenEnter(3);
                break;
            case 3:
                ModelEven.transform.position = new Vector3(900, 0, 900);
                break;
            case 4:
                ModelEven.transform.position = new Vector3(40, 0, 40);
                break;
        }
    }
}
