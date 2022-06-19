using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;
    public SwipeProperty _swipeProperty;

    Touch trackedFinger1;
    Touch trackedFinger2;
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0;


    private bool isFingerUp = true;

    [HideInInspector] public bool canThrowBall = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                trackedFinger1 = Input.GetTouch(0);
                checkSingleFingerGestures();
            }
        }
        else
        {
            isFingerUp = true;
            canThrowBall = false;
        }
    }

    private void checkSingleFingerGestures()
    {
        if (trackedFinger1.phase == TouchPhase.Began)
        {
            startPoint = trackedFinger1.position;
            gestureTime = 0;
        }
        else if (trackedFinger1.phase == TouchPhase.Ended)
        {
            endPoint = trackedFinger1.position;

            //SWIPE
            if (gestureTime <= _swipeProperty.swipeTime &&
                Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi) && isFingerUp == true)
            {
                isFingerUp = false;

                //THROW BALL HERE
                canThrowBall = true;
            }
        }
        else
        {
            gestureTime += Time.deltaTime;
        }
    }

    

    private Vector2 GetPreviousPoint(Touch finger)
    {
        return finger.position - finger.deltaPosition;
    }


    private Vector2 GetMidPoint(Vector2 finger1, Vector2 finger2)
    {
        return (finger1 + finger2) / 2;
    }
}