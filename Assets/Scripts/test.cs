using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text textdisplay;

    // Start is called before the first frame update
    void Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }

        InputSystem.EnableDevice(StepCounter.current);
        InputSystem.AddDevice<StepCounter>();

#endif


    }

    // Update is called once per frame
    void Update()
    {
        textdisplay.text = StepCounter.current.stepCounter.ReadValue().ToString();


    }
}
