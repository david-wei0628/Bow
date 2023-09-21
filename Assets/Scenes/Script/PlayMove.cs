using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject PlayerMove;
    public GameObject PlayerModel;
    public float mouseSensitivity = 1000f;
    float xRotation = 0f;
    public float MoveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed, 0, 0);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            this.transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Home))
        {
            this.transform.Translate(0, Time.deltaTime * MoveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.End) && this.transform.position.y > 0.75f)
        {
            this.transform.Translate(0, -Time.deltaTime * MoveSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //GameObject.Find("Uc").transform.position = PlayerCam.transform.position;
            Instantiate(PlayerModel, this.transform);
        }

        if (Cursor.lockState.ToString() == "Locked")
        {
            PlayRat();
        }

    }

    void PlayRat()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (Input.GetAxis("Mouse X") != 0)
        {
            this.transform.Rotate(Vector3.up * mouseX);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 80f); // 讓頭部旋轉在90度
            PlayerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}
