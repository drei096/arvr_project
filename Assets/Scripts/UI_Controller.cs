using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    // Singleton
    private static UI_Controller instance = null;

    public static UI_Controller Instance
    {
        get
        {
            if (instance == null)
                instance = new UI_Controller();
            return instance;
        }
    }


    //public Text noEncounterText;
    public Text stepsText;
    [SerializeField] private Animator encounterAnim;
    [SerializeField] private Animator noEncounterAnim;


    private StepCount stepCounterReference;

    // Start is called before the first frame update
    void Start()
    {
        stepCounterReference = StepCount.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        stepsText.text = "Steps: " + stepCounterReference.steps.ToString();
        //count steps, if it is a multiple of 10, do a UI alert of encounter
        if (stepCounterReference.steps % 10 == 0 && stepCounterReference.steps != 0)
        {
            //disable no encounter anim
            triggerNoEncounterAnim(false);

            //prompt to tap
            triggerEncounterAnim(true);

        }
        else
        {
            //show UI alert that there is no encounter yet
            triggerNoEncounterAnim(true);
        }

    }

    private void triggerNoEncounterAnim(bool value)
    {
        noEncounterAnim.SetBool("isTriggered", value);
    }

    private void triggerEncounterAnim(bool value)
    {
        encounterAnim.SetBool("isTriggered", value);
    }

    private void disableAllEncounterAnim()
    {
        noEncounterAnim.SetBool("isTriggered", false);
        encounterAnim.SetBool("isTriggered", false);
    }


}
