using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControl : MonoBehaviour
{


    /// <summary>
    /// Just used to play around, not in use atm
    /// </summary>


    //public int startingState = 0;
    public int currentState;
    public Vector3 origin;
    public float speed = 10f;
    public GameObject targetRotation;
    private float rotation = 0f;
    private Quaternion qTo = Quaternion.identity;


    // Use this for initialization
    void Start()
    {
        //currentState = startingState;
        currentState = 0;
        //origin = new Vector3(0, -16, -18);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (currentState == 0)
            {
               // transform.Translate(-18, 0, 18);
                //transform.rotation.Set(45, 90, 0, 0);
                transform.localEulerAngles = new Vector3(-18, 0, 18);
            }
            else if (currentState == 1)
            {
                transform.Translate(18, 0, 18);
            }
            else if (currentState == 2)
            {
                transform.Translate(18, 0, -18);
            }
            else
            {
                transform.Translate(-18, 0, -18);
            }
            currentState++;
//transform.Rotate(Vector3.forward, 90);

            if (currentState > 3)
            {
                currentState = 0;
            }
        }
    }
}


        //if (Input.GetKeyUp(KeyCode.Q))
        //{

        //    transform.Rotate(Vector3.,90);

        //    if (currentState == 0)
        //    {
        //        transform.(-30, 16, -12);
        //    }
        //    else if (currentState == 1)
        //    {
        //        transform.position.Set(-12, 16, 6);
        //    }
        //    else if (currentState == 2)
        //    {
        //        transform.position.Set(6, 16, -12);
        //    }
        //    else
        //    {
        //        transform.position.Set(-12, 16, 30);
        //    }

            //transform.Rotate(Vector3.left, 90);
            //currentState++;

            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    rotation += 90f;
            //    qTo = Quaternion.Euler(0f, rotation, 0f);

            //    if (currentState == 0)
            //    {
            //        transform.Translate(-18, 0, 18);
            //    } else if (currentState == 1)
            //    {
            //        transform.Translate(18, 0, 18);
            //    } else if (currentState == 2)
            //    {
            //        transform.Translate(18, 0, -18);
            //    } else
            //    {
            //        transform.Translate(-18, 0, -18);
            //    }
            //    currentState++;
            //if (currentState > 3)
            //{
            //    currentState = 0;
            //}
            ////transform.Translate(-18, 0, 18);
            //}

            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    rotation -= 90f;
            //    qTo = Quaternion.Euler(0f, rotation, 0f);
            //}
            //transform.rotation = qTo;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speed * Time.deltaTime);

        //}
        //}
    //}
//}
