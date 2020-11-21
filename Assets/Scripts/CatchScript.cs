using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    private GameObject gameobj;
    private bool CubeFlag = false;
    private bool SphereFlag = false;
    private bool CapsuleFlag = false;
    public Texture2D texture;
    void Start()
    {

    }
    void Update()
    {
        //鼠標監聽 是否點擊
        if (Input.GetMouseButtonDown(0))
        {
            //創建射線 Camera.main 只是代表tag標籤爲main camera 的攝像機 其可以替換爲任何攝像機
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //創建碰撞體對象
            RaycastHit hit;
            //判斷是否碰撞
            if (Physics.Raycast(ray, out hit))
            {
                //打印拾取物體的名稱
                Debug.Log(hit.transform.name);
                SetObj(hit.transform.name);
            }
            else
            {
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
            }
        }

        if (CubeFlag)
        {
            gameobj.GetComponent<Renderer>().material.mainTexture = texture;
            gameobj.transform.Rotate(0, 10, 0);
        }

        if (SphereFlag)
        {
            gameobj.transform.Translate(0, 0.02f, 0);
        }
        if (CapsuleFlag)
        {
            gameobj.transform.Rotate(0, 10, 0);
        }

    }
    void SetObj(string hitname)
    {
        switch (hitname)
        {
            case "Cube":

                gameobj = GameObject.Find("Cube");
                CubeFlag = true;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
            case "Sphere":
                gameobj = GameObject.Find("Sphere");
                SphereFlag = true;
                CubeFlag = false;
                CapsuleFlag = false;
                break;
            case "Capsule":
                gameobj = GameObject.Find("Capsule");
                CapsuleFlag = true;
                CubeFlag = false;
                SphereFlag = false;
                break;
            default:
                CubeFlag = false;
                CapsuleFlag = false;
                SphereFlag = false;
                break;
        }
    }
}