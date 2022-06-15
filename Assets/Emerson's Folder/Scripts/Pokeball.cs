using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : APoolable
{
    public StructHandler.PokeballInfo info;
    public PokeballCode pokeballCode;

    //FOR THROWING
    [SerializeField]
    private float throwSpeed = 35f;
    private float speed;
    private float lastMouseX, lastMouseY;

    private bool thrown, holding;

    private Rigidbody _rigidbody;
    private Vector3 newPosition;

    //GO HANDLER
    private GameObjectHandler GOHandler;

    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokeballInfo[pokeballCode];

        _rigidbody = GetComponent<Rigidbody>();
        GOHandler = GameObject.FindGameObjectWithTag("ScriptsHolder").GetComponent<GameObjectHandler>();
        Reset();
    }
    
    public override void onRelease(StructHandler.OnReleaseStruct info)
    {
        // returns the pool object to its original parent and position
        transform.SetParent(GameObject.FindGameObjectWithTag("PoolManager").transform);
        transform.position = GameObject.FindGameObjectWithTag("PoolManager").transform.position;
    }

    public override void onActivate(StructHandler.OnRequestStruct info)
    {
        // place the pool object to the specified position and parent
        transform.SetParent(info.parent);
        transform.position = info.position;
    }

    void Update()
    {
        if (holding)
            OnTouch();

        if (thrown)
            return;

        if (Input.GetMouseButtonDown(0))
        { //for pc = if(Input.GetButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //for pc = Input.mousePosition
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform == transform)
                {
                    holding = true;
                    transform.SetParent(null);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        { //for pc = if(Input.GetButtonUp(0)){
            if (lastMouseY < Input.GetTouch(0).position.y)
            {
                ThrowBall(Input.GetTouch(0).position);
            }
        }

        if (Input.touchCount == 1)
        { //for pc = if(Input.GetButton(0)){
            lastMouseX = Input.GetTouch(0).position.x;
            lastMouseY = Input.GetTouch(0).position.y;
        }
    }

    void Reset()
    {
        CancelInvoke();
        //transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 0.5f);
        transform.position = GOHandler.pokeballPos.transform.position;
        //transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, (Camera.main.nearClipPlane * 7.5f) + 1.0f));
        newPosition = transform.position;
        thrown = holding = false;

        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 200f, 0f);
        transform.SetParent(GOHandler.groundPlaneStage.transform);
        //transform.SetParent(Camera.main.transform);
    }

    void OnTouch()
    {
        Vector3 mousePos = Input.GetTouch(0).position;
        mousePos.z = Camera.main.nearClipPlane * 7.5f;

        //newPosition = Camera.main.ScreenToWorldPoint(mousePos);
        newPosition = GOHandler.pokeballPos.position;

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, 50f * Time.deltaTime);
    }

    void ThrowBall(Vector2 mousePos)
    {
        _rigidbody.useGravity = true;

        float differenceY = (mousePos.y - lastMouseY) / Screen.height * 100;
        speed = throwSpeed * differenceY;

        float x = (mousePos.x / Screen.width) - (lastMouseX / Screen.width);
        x = Mathf.Abs(Input.GetTouch(0).position.x - lastMouseX) / Screen.width * 100 * x;

        Vector3 direction = new Vector3(x, 0f, 1f);
        direction = Camera.main.transform.TransformDirection(direction);

        _rigidbody.AddForce((direction * speed / 2f) * 5.0f + (Vector3.up * speed) * 2.0f);

        holding = false;
        thrown = true;

        //Invoke("GameObject.FindObjectOfType<EncounterSystem>().ThrownPokeball(this.GetComponent<Pokeball>().pokeballCode)", 5.0f);
        Invoke("Reset", 5.0f);
    }

    public override GameObject createCopy(ObjectPool pool)
    {
        //duplicate the origin copy
        GameObject go = 
            GameObject.Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;

        //awake
        go.GetComponent<APoolable>().poolRef = pool;
        go.GetComponent<APoolable>().initialize();
        return go;
    }
}
