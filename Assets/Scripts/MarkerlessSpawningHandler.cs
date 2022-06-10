using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerlessSpawningHandler : MonoBehaviour
{
    // Singleton
    public static MarkerlessSpawningHandler Instance;

   
    //REFERENCE TO SINGLETONS
    private StepCount stepCounterReference;
    private GameManager gameManagerReference;
    private UI_Controller uiControllerReference;

    //REFERENCE TO GROUND PLANE STAGE AND PLANE FINDER
    private GameObject groundPlaneGO;
    private GameObject planeFinderGO;


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
       gameManagerReference = GameManager.Instance;
       uiControllerReference = UI_Controller.Instance;

       groundPlaneGO = GameObject.Find("Ground Plane Stage");
       planeFinderGO = GameObject.Find("Plane Finder");
    }

    // Update is called once per frame
    void Update()
    {
        checkForEncounter();
    }

    public void checkForEncounter()
    {
        //IF THE STEPS IS A MULTIPLE OF 10
        if (stepCounterReference.steps % 10 == 0 && stepCounterReference.steps != 0)
        {
            //ENABLE GROUND PLANE DETECTION
            groundPlaneGO.SetActive(true);
            planeFinderGO.SetActive(true);
        }

        //ELSE IF STEPS IS NOT A MULTIPLE OF 10 OR IS ZERO
        else
        {
            //DISABLE GROUND PLANE DETECTION
            groundPlaneGO.SetActive(false);
            planeFinderGO.SetActive(false);

            if (Input.GetMouseButtonDown(0))
            {
                uiControllerReference.triggerNoEncounterAnim(true);
                Invoke("disableNoEncounterAnim", 0.5f);
            }
        }
    }

    private void disableNoEncounterAnim()
    {
        uiControllerReference.triggerNoEncounterAnim(false);
    }

    public void startEncounter()
    {
        //DISABLE STEP COUNTER
        stepCounterReference.gameObject.SetActive(false);

        gameManagerReference.Encounter();
    }
}
