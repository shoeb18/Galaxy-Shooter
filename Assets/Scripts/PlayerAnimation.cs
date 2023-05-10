using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            anim.SetBool("TurnLeft", true);
            anim.SetBool("TurnRight", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            anim.SetBool("TurnRight", true);
            anim.SetBool("TurnLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);
        }

    }
}
