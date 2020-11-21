using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]
//[AddComponentMenu("Control Script/move")]
public class PlayerMove_2 : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    //Move


    // Update is called once per frame
    void Update()
    {
        //Move
        if (Input.GetKey("a"))
            controller.SimpleMove(transform.right * -speed);
        if (Input.GetKey("d"))
            controller.SimpleMove(transform.right * speed);
        if (Input.GetKey("w"))
            controller.SimpleMove(transform.forward * speed);
        if (Input.GetKey("s"))
            controller.SimpleMove(transform.forward * -speed);
    }
}