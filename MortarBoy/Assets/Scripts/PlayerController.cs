using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    GameObject mCam;
    float cur;
    CannonController cannon;

    int mode = 0; //player moveing around mode


    void Start()
    {
        anim = GetComponent<Animator>();
        mCam = GameObject.Find("Main Camera");
        cur = 0;
        cannon = null;
    }

    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (mode == 0)
        {
            anim.SetFloat("Speed", move);
            anim.SetFloat("H", h);
            if (move < -0f)
            {
                anim.SetBool("Back", true);
                cur += Time.deltaTime;
                //anim.SetBool("Back", false);
                //print("Back true");

            }
            //print(cur);
            if (anim.GetBool("Back"))
            {
                cur += Time.deltaTime;
            }
            if (cur > 1.62f)
            {
                cur = cur - cur;
                anim.SetBool("Back", false);
                //print("This is not true");
            }

            mCam.transform.position = transform.position - 5 * transform.forward + 2 * Vector3.up;
            mCam.transform.forward = transform.forward;
        }
        else if (mode == 1)
        {
            print("Cannon aiming mode" + cannon.name);
        }

    }
        void OnTriggerStay(Collider other)
        {
            print("thisWorks");
            if (other.tag == "ACannon" && mode == 0 && Input.GetButton("Jump"))
            {
                cannon = other.transform.Find("Cannon").GetComponent<CannonController>();
                setAimMode();

            }
        }

        void setAimMode()
        {
            mode = 1;
        }
        void setMoveMode()
        {
            mode = 0;
        }
}
