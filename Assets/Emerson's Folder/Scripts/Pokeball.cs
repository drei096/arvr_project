using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

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

    private float angleChasingSpeed = 1;
    private float movementSpeed = 1;

    //SCRIPTS HANDLER
    private GameObject scriptsHolder;

    //GO HANDLER
    private GameObjectHandler GOHandler;

    //ENCOUNTER SYSTEM
    private EncounterSystem encounterSystemRef;

    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokeballInfo[pokeballCode];

        _rigidbody = GetComponent<Rigidbody>();
        scriptsHolder = GameObject.FindGameObjectWithTag("ScriptsHolder");
        GOHandler = scriptsHolder.GetComponent<GameObjectHandler>();
        encounterSystemRef = scriptsHolder.GetComponent<EncounterSystem>();
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

        /*
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
                transform.LookAt(GOHandler.opPokemonPos);
                throwball2();
                //ThrowBall(Input.GetTouch(0).position);
            }
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            transform.LookAt(GOHandler.opPokemonPos);
            throwball2();
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
        //transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0.0f, (Camera.main.nearClipPlane) * 1.5f));
        //transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, Camera.main.nearClipPlane + 0.1f));

        newPosition = transform.position;
        thrown = holding = false;

       

        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0f, 200f, 0f);
        transform.SetParent(GOHandler.pokeballPos.transform);
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




        /*
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
        */
    }

    void throwball2()
    {
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(0.0f, 0.0f, 300.0f);

        holding = false;
        thrown = true;

        GameManager.Instance.mainPlayerRef.inventory.removePokeball(this.pokeballCode, 1);

        Invoke("Reset", 5.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.gameObject.GetComponent<Pokemon>() != null && collision.transform.gameObject.GetComponent<Pokemon>().PoolType == PoolType.POKEMON)
        {
            StartCoroutine(catchAnim(collision.transform.gameObject));
        }
        else
        {
            Debug.Log("not pokemon");
        }
    }

    IEnumerator catchAnim(GameObject pokemon)
    {
        //DISABLE POKEMON
        GameObject.FindObjectOfType<PokemonPool>().itemPool.ReleasePoolable(pokemon,
            new StructHandler.OnReleaseStruct()
            {
                parent = GOHandler.transform,
                position = Vector3.zero
            });

        //KAARTEHAN
        _rigidbody.AddForce(Vector3.up * 2.0f);
        yield return new WaitForSeconds(0.25f);
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.25f);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(2f);

        //CHECK IF CATCH IS SUCCESSFUL
        bool isCaught = encounterSystemRef.catchPokemon(this.pokeballCode);
        if (isCaught)
        {
            Debug.Log("POKEMON CAUGHT");
            // Add pokemon to the 'caughtPokemon' list
            Pokedex.Instance.caughtPokemon[pokemon.GetComponent<Pokemon>().pokemonCode] = true;
            // Add pokemon to party
            GameManager.Instance.mainPlayerRef.AddPokemonToParty(pokemon.GetComponent<Pokemon>().pokemonCode);

            StepCount.Instance.canCount = true;
            StepCount.Instance.steps++;
            GameManager.Instance.panelController.setUIPanelActive(GameManager.Instance.panelController.catchPanel);
            GameManager.Instance.animController.openAnim(GameManager.Instance.animController.catchPokemon);
            yield break;
        }
        else
        {
            Debug.Log("POKEMON NOT CAUGHT");
            encounterSystemRef.requestPokeball(this.pokeballCode);
            Reset();
        }

        //REQUEST FOR POKEMON IF NOT CAUGHT
        GameObject.FindObjectOfType<PokemonPool>().itemPool.RequestPoolable(pokemon.GetComponent<Pokemon>().pokemonCode,
            new StructHandler.OnRequestStruct()
            {
                parent = GOHandler.opPokemonPos.transform,
                position = GOHandler.opPokemonPos.transform.position
            });

        yield break;
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
