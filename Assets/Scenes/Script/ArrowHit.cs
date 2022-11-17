using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    Vector3 BowPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent != null)
        {
            BowPos = transform.position;
        }
        else if (this.transform.parent == null)
        {
            if (Input.GetKeyDown(KeyCode.O)) 
            {
               Destroy(this.gameObject);
            }
            //if (Mathf.Abs(this.transform.position.x - BowPos.x) > 100) 
            //{
            //   Destroy(this.gameObject);
            //}
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().freezeRotation = true;
       
        Destroy(this.gameObject,10.0f);
    }
}
