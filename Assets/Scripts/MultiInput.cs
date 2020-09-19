﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this Script to Handle multi plateform Inputs Like mobile or windows or web 
/// </summary>
public class MultiInput : MonoBehaviour
{

    static int DEADZONE = 100;

    bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    public static MultiInput Instance { set; get; }
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        tap = swipeDown = swipeLeft = swipeRight = swipeUp = false;
        //check for inputs
        #region standlone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector3.zero;
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector3.zero;
            }
        }
        #endregion
        //calculate distance 
        swipeDelta = Vector3.zero;
        if (startTouch != Vector2.zero)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        //swipping in which direction 
        if (swipeDelta.magnitude > DEADZONE)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {//right & left
                if (x > 0) swipeRight = true;
                else swipeLeft = true;
            }
            else
            {
                if (y > 0) swipeUp = true;
                else swipeDown = true;
            }
            startTouch = swipeDelta = Vector3.zero;
        }
    }
}
