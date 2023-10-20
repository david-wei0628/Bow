using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMove : MonoBehaviour
{
    public GameObject UserModel;
    new Animator animation = new Animator();
    public float UserSpeed = 200;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        animation = UserModel.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.y > 0.01f)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * -9.81f, ForceMode.Acceleration);
        }
        else if (this.transform.position.y <= 0.01f)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }

        ForwardDir();
    }

    private void FixedUpdate() => UserModel_Move();

    void UserModel_Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animation.SetBool("Walk", true);
            var ForDir = HorXVert(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            UserModel.transform.localEulerAngles = new Vector3(0, ForDir, 0);
            CollisionSize(ForDir);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //UserSpeed = 0;
        }
    }

    void ForwardDir()
    {
        Vector3 YUp = new Vector3(0, 10, 0);
        if (Physics.Raycast(UserModel.transform.position + YUp, UserModel.transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(UserModel.transform.position + YUp, UserModel.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.collider.tag == "Wall")
            {
                UserSpeed = 10;
            }
        }
        else
        {
            UserSpeed = 200;
        }
        //Debug.DrawRay(UserModel.transform.position, UserModel.transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
    }

    void CollisionSize(float ModelToward)
    {
        Vector3 FB = new Vector3(20, 20, 10);
        Vector3 RL = new Vector3(10, 20, 20);
        if (Mathf.Abs(ModelToward) == 90)
        {
            this.GetComponent<BoxCollider>().size = RL;
        }
        if (ModelToward == 0 || ModelToward == 180)
        {
            this.GetComponent<BoxCollider>().size = FB;
        }
    }
}
