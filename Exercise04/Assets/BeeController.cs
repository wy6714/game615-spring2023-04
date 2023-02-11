using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeController : MonoBehaviour
{
    // These two lines create two variables. In general, define variables in
    // this region of your Unity scripts so that you can use them through out
    // the entire script.
    float moveSpeed = 5f;
    float rotateSpeed = 50f;
    private Vector3 scaleChange;


    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
   

    }

    // Update is called once per frame
    void Update()
    {
        // Below is an example of how you would check to see if a key was just
        // pressed. Don't forget that there is also a GetKey, and GetKeyUp.
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Do something when the space key was just pressed
        //}


        // The following two lines of code create two variables that contain info
        // about the up, down, left and right buttons. hAxis will be -1 if left
        // is pressed, 1 if right is pressed and 0 if nothing is pressed. Same
        // sort of thing for up and down with vAxis.
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // This line of code will make it so the gameObject moves forward/backwards
        // based on the vAxis. Because vAxis is 0 when up and down aren't pressed
        // unless those buttons are pressed, the amount we are telling unity to
        // move the gameObject will be zero because multiplying anything by will
        // be 0.
        // Note that the second parameter to the Translate function is Space.World.
        // For now, just go with this approach.
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);

        // Do something similar for how much we will rotate on the y axis with
        // the hAxis. 
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);
    }
    }