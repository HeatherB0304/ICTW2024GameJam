using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {
    public Transform myT;
    public Transform rotT;
    private float V,H;
    public float speedMove;
    private Vector3 rot;
    private Vector3 pos;
    public int ScrollWheelSpeed;
    private void Awake()
    {
        Cursor.visible = false;
        pos = myT.position;
        rot.y = myT.eulerAngles.y;
        rot.x = rotT.eulerAngles.x;
    }
    void Start () {
        myT = transform;
    }
    void LateUpdate()
    {
        V = Input.GetAxis("Vertical");
        H = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(H, 0, V).normalized;
        dir = myT.TransformDirection(dir);
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        pos += dir * speedMove * Time.deltaTime;
         pos -= Vector3.up * ScrollWheel * ScrollWheelSpeed * Time.deltaTime;
         myT.position = Vector3.Lerp(myT.position, pos, 3f * Time.deltaTime);
        if (Input.GetButton("Fire2"))
        {
            Vector2 mouseMove = new Vector2((Input.GetAxis("Mouse X")) * 160f, (Input.GetAxis("Mouse Y")) * 100f);
            rot.y += (mouseMove.x) * Time.deltaTime;
            rot.x -= (mouseMove.y) * Time.deltaTime;
        }
        myT.eulerAngles = new Vector3(myT.eulerAngles.x, Mathf.LerpAngle(myT.eulerAngles.y, rot.y, 3f * Time.deltaTime), myT.eulerAngles.z);
        rotT.eulerAngles = new Vector3(Mathf.LerpAngle(rotT.eulerAngles.x, rot.x, 3f * Time.deltaTime), rotT.eulerAngles.y, rotT.eulerAngles.z);
    }
}
