using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
    {
    [SerializeField] float RotateSpeed = 3; //旋轉速度
    void Start()
    {

    }

    void Update()
    {
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(y * RotateSpeed*-1, 0, 0); //角色旋轉
    }
}

