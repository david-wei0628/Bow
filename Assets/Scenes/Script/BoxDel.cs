using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxDel : MonoBehaviour
{
    public Canvas Point;
    public GameObject BoxQuantity;
    // Start is called before the first frame update
    void Start()
    {
        Point = FindObjectOfType<Canvas>();
        BoxQuantity = GameObject.Find("Target");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Arrow")
        {
            BoxQuantity.SendMessage("BoxClear");
            Point.SendMessage("PointUp");
            Destroy(this.gameObject);
        }
    }
}
