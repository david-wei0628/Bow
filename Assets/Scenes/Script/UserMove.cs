using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMove : MonoBehaviour
{
    public GameObject UserModel;
    Animator animation;
    public float UserSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        animation = UserModel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UserModel_Move();
    }


    void UserModel_Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animation.SetBool("Walk", true);
            var ForDir = HorXVert(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            UserModel.transform.localEulerAngles = new Vector3(0, ForDir, 0);
            if (Input.GetAxis("Horizontal") != 0)
            {
                this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * UserSpeed, 0, 0);
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                this.transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * UserSpeed);
            }
        }
        else
        {
            animation.SetBool("Walk", false);
        }
    }

    float HorXVert(float Horiz, float Verti)
    {
        float ForwardDir = 0;
        float ForBack = 0;
        float LeftRight = 0;
        if (Verti != 0)
        {
            if (Verti > 0)
                ForBack = 0;
            else if (Verti < 0)
                ForBack = 180;
        }
        if (Horiz != 0)
        {
            if (Horiz > 0)
                LeftRight = 90;
            else if (Horiz < 0)
                LeftRight = -90;
        }

        if (Verti != 0 && Horiz != 0)
        {
            if (Verti > 0)
            {
                ForwardDir = ForBack + LeftRight / 2;
            }
            else
            {
                ForwardDir = ForBack - LeftRight / 2;
            }
        }
        else
        {
            ForwardDir = ForBack + LeftRight;
        }
        return ForwardDir;
    }
}
