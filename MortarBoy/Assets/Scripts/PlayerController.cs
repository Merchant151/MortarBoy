using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    GameObject mCam;
    float cur;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mCam = GameObject.Find("Main Camera");
        cur = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        float move = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
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
        if(cur > 1.62f )
        {
            cur = cur - cur;
            anim.SetBool("Back", false);
            //print("This is not true");
        }

        mCam.transform.position = transform.position - 5 * transform.forward + 2 * Vector3.up;
        mCam.transform.forward = transform.forward;


    }
}
