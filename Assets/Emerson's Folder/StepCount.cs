using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    // Singleton
    private static StepCount instance = null;

    public static StepCount Instance
    {
        get
        {
            if (instance == null)
                instance = new StepCount();
            return instance;
        }
    }

    //public Text acc;
 
    public float loLim = 0.005f; // level to fall to the low state 
    public float hiLim = 0.1f; // level to go to high state (and detect step) 
    public int steps = 0; // step counter - counts when comp state goes high private 
    bool stateH = false; // comparator state
    bool isWalk = false;
 
    public float fHigh = 10.0f; // noise filter control - reduces frequencies above fHigh private 
    public float curAcc = 0f; // noise filter 
    public float fLow = 0.1f; // average gravity filter control - time constant about 1/fLow 
    float avgAcc = 0f;
 
    public int wait_time = 30;
    private int old_steps;
    private int counter = 30;

   
 
    void Awake() 
    {
        avgAcc = Input.acceleration.magnitude; // initialize avg filter
        old_steps = steps;
    }
 
    void Update() 
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
 
    void FixedUpdate()
    { // filter input.acceleration using Lerp
        curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
        avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
        float delta = curAcc-avgAcc; // gets the acceleration pulses

        if (!stateH)
        { // if state == low...
            if (delta>hiLim)
            { // only goes high if input > hiLim
                stateH = true; 
                steps++; // count step when comp goes high 
                //acc.text = "steps:" + steps;
            } 
        } 
        else 
        { 
            if (delta<loLim)
            { // only goes low if input < loLim 
                stateH = false; 
            } 
        } 
    }

    public void checkForEncounter()
    {
        if (steps % 10 == 0 && steps != 0)
        {
            GameManager.Instance.Encounter();
        }
        else
        {
            
        }
    }


}


    /*
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Input.gyro.enabled = false;
            Debug.Log("no gyro");
        }
    }
    private float speed = 5;
    private float minChange = 0.2f;

    private static Quaternion GyroToUnity(Quaternion q)
    {
        //invert z and w values
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.gyro.enabled)
        {
            Quaternion rotation = GyroToUnity(Input.gyro.attitude);
            transform.rotation = rotation;
        }

        /*Vector3 accel = Input.acceleration;
        if(Mathf.Abs(accel.x) >= minChange)
        {
            accel.x *= speed * Time.deltaTime;
            transform.Translate(accel.x, 0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying)
        {
            Debug.DrawRay(transform.position, Input.acceleration.normalized, Color.red);
            
        }
    }
*/