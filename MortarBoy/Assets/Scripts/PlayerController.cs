using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    GameObject mCam;
    float cur;
    CannonController cannon;
    public Rigidbody cannonBall;

    Image crossHair;

    float rotateSpeed = 20;
    int mode = 0; //player moveing around mode


    void Start()
    {

        anim = GetComponent<Animator>();
        mCam = GameObject.Find("Main Camera");
        cur = 0;
        cannon = null;
        crossHair = GameObject.Find("cross").GetComponent<Image>();
        cannonBall = null;
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
            //print("Cannon aiming mode" + cannon.name);
            cannon.transform.Rotate(Vector3.up, h * rotateSpeed * Time.deltaTime, Space.World);
            cannon.transform.Rotate(cannon.transform.right, move * rotateSpeed * Time.deltaTime, Space.World);

            mCam.transform.position = cannon.spawnPoint.transform.position;
            mCam.transform.forward = cannon.transform.forward;

            if (Input.GetButtonDown("Fire1"))
            {
                cannonBall = cannon.shoot(50);
                mode = -1;
                Invoke("setFollowing",.25f);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                setMoveMode();
            }
        }
        else if (mode == 2)
        {
            if (cannonBall != null)
            {
                mCam.transform.position = cannonBall.transform.position - cannonBall.velocity * 0.25f;
                mCam.transform.LookAt(cannonBall.transform.position);
            }
            else
            {
                mode = -1;
                Invoke("setAimMode", 1);
            }
        }
        else
        {
            //null mode
        }

    }
    void OnTriggerStay(Collider other)
    {
        //print("thisWorks");
        if (other.tag == "ACannon" && mode == 0 && Input.GetButton("Jump"))
        {
            cannon = other.transform.Find("Cannon").GetComponent<CannonController>();
            setAimMode();

        }
    }

    void setAimMode()
    {
        Debug.Log("cur mode: "+ mode);
        crossHair.enabled = true;
        mode = 1;
    }
    void setMoveMode()
    {
        Debug.Log("cur mode: " + mode);
        crossHair.enabled = false;
        mode = 0;
    }

    void setFollowing()
    {
        Debug.Log("cur mode: " + mode);
        crossHair.enabled = false;
        mode = 2;
    }
}
