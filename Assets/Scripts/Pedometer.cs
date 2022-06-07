using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
//using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pedometer : MonoBehaviour
{
    public Text textdisplay;
    public Text stepcounterStatus;
    //private StepCounter stepCounter;
    public static int currentSteps = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        

   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        stepCounter = StepCounter.current;
        InputSystem.EnableDevice(stepCounter);
        if (stepCounter.enabled)
        {
            stepcounterStatus.text = "enabled";
            currentSteps = stepCounter.stepCounter.ReadValue();
        }


        textdisplay.text = currentSteps.ToString();

        */
    }
}
