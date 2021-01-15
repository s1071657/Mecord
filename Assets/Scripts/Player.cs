using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Player : MonoBehaviour
{
    public static Flowchart flowchartManager;
    Rigidbody rb; //角色剛體
    [SerializeField] float MoveSpeed = 2; //移動速度
    [SerializeField] float RotateSpeed = 15; //旋轉速度
    [SerializeField] float JumpPower = 4000; //跳躍力量
    bool JumpAction = false; //是否在跳躍狀態
    public GameObject myNote;
    bool isOpen;
    public Camera cam;
    bool canMove = true;
    [SerializeField] private float timeHit = 0f;

    private void Awake()
    {
        flowchartManager = GameObject.Find("talkManager").GetComponent<Flowchart>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //取得此角色的剛體物件

    }
    public static bool isTalking
    {
        get { return flowchartManager.GetBooleanVariable("talk"); }
    }

    void Update() {
        OpenMyNote();
        PlayerMove();
    }
        

    
    void PlayerMove() {
        if (!isTalking) {
            float h = Input.GetAxis("Horizontal");   //取得輸入器的水平軸值(角色轉左/轉右)
            float v = Input.GetAxis("Vertical");     //取得輸入器的垂直軸值(角色前進/後退)
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            //print(h + "/"+ v);

            transform.Translate(v * Vector3.forward * MoveSpeed * Time.deltaTime); //角色移動(跑步)
            transform.Translate(h * Vector3.right * MoveSpeed * Time.deltaTime);


            transform.Rotate(0, x * RotateSpeed, 0); //角色旋轉


            if (Input.GetButtonDown("Jump")) //角色跳躍
            {
                if (JumpAction == false)
                {//不在跳躍狀態
                    rb.AddForce(Vector3.up * JumpPower); //增加角色向上跳的力量
                    JumpAction = true;//設定跳躍狀態(跳躍中)
                }
            }
        }
    }

    void OpenMyNote()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            myNote.SetActive(isOpen);
        }
    }
}
