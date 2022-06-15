using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    public static StepCount Instance;


	public Text acc;

    public float loLim = 0.005f; // level to fall to the low state 
    public float hiLim = 0.1f; // level to go to high state (and detect step) 
    public int steps = 0; // step counter - counts when comp state goes high private 
    bool stateH = false; // comparator state
    bool isWalk = false;
    public bool canCount = true;

    public float fHigh = 10.0f; // noise filter control - reduces frequencies above fHigh private 
    public float curAcc = 0f; // noise filter 
    public float fLow = 0.1f; // average gravity filter control - time constant about 1/fLow 
    float avgAcc = 0f;

    public int wait_time = 30;
    private int old_steps;
    private int counter = 30;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this);


        avgAcc = Input.acceleration.magnitude; // initialize avg filter
        old_steps = steps;
    }

    void Update()
    {
        if (canCount)
        {
            if (counter > 0)
            {
                counter--;
                return;
            }
            counter = wait_time;
            if (steps != old_steps)
                isWalk = true;
            else
                isWalk = false;
            old_steps = steps;
        }
    }

    void FixedUpdate()
    {
        if (canCount)
        {
            // filter input.acceleration using Lerp
            curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
            avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
            float delta = curAcc - avgAcc; // gets the acceleration pulses
            if (!stateH)
            { // if state == low...
                if (delta > hiLim)
                { // only goes high if input > hiLim
                    stateH = true;
                    steps++; // count step when comp goes high 
                    acc.text = "steps:" + steps;
                }
            }
            else
            {
                if (delta < loLim)
                { // only goes low if input < loLim 
                    stateH = false;
                }
            }
        }
    }


}


    