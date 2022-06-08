using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    // Singleton
    public static UI_Controller Instance;

    


    //public Text noEncounterText;
    public Text stepsText;
    [SerializeField] private Animator encounterAnim;
    [SerializeField] private Animator noEncounterAnim;
    [SerializeField] private Animator lookingForAnim;


    private StepCount stepCounterReference;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        stepCounterReference = StepCount.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //count steps, if it is a multiple of 10, do a UI alert of encounter
        if (stepCounterReference.steps % 10 == 0 && stepCounterReference.steps != 0)
        {
            //disable no encounter anim
            triggerNoEncounterAnim(false);
            triggerLookingForAnim(false);

            //prompt to tap
            triggerEncounterAnim(true);

        }
        else
        {
            //show UI alert that there is no encounter yet
            triggerEncounterAnim(false);
            triggerLookingForAnim(true);
        }

    }

    public void triggerNoEncounterAnim(bool value)
    {
        noEncounterAnim.SetBool("isTriggered", value);
    }

    public void triggerEncounterAnim(bool value)
    {
        encounterAnim.SetBool("isTriggered", value);
    }

    public void triggerLookingForAnim(bool value)
    {
        lookingForAnim.SetBool("isTriggered", value);
    }

    public void disableAllEncounterAnim()
    {
        lookingForAnim.SetBool("isTriggered", false);
        noEncounterAnim.SetBool("isTriggered", false);
        encounterAnim.SetBool("isTriggered", false);
    }


}
