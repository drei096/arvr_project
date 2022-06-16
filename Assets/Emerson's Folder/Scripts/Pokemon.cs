using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : APoolable
{
    // Pokemon Info; editable
    public StructHandler.PokemonInfo info;
    public PokemonCode pokemonCode;
    public int exp;
    public int level;

    private Camera mainCamera;
    // how smooth the rotation of the player should be
    float rotate_interval = 0.1f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        LookAtCamera();
    }

    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokemonInfo[pokemonCode];
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

    public void LookAtCamera()
    {
        // normalize cam position
        Vector3 norm = mainCamera.transform.position.normalized;
        // if this is the player's pokemon, then it should be facing backward
        if (transform.parent.tag == "PokemonPlPos")
        {
            // change orientation based on the direction
            float angle = Mathf.Atan2(norm.z, norm.x) * Mathf.Rad2Deg - 270F;
            // Add smooth rotation 
            transform.localRotation = Quaternion.Slerp
                (transform.localRotation, Quaternion.Euler(0.0f, -angle, 0.0f), rotate_interval);
        }
        else
        {
            // change orientation based on the direction
            float angle = Mathf.Atan2(norm.z, norm.x) * Mathf.Rad2Deg - 90F;
            // Add smooth rotation 
            transform.localRotation = Quaternion.Slerp
                (transform.localRotation, Quaternion.Euler(0.0f, -angle, 0.0f), rotate_interval);
        }
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
