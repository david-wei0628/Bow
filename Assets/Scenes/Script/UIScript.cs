using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    int Point;
    public Text PointUI;
    // Start is called before the first frame update
    void Start()
    {
        Point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PointUI.text = Point.ToString();
    }

    void PointUp()
    {
        Point++;
    }
}
