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

    void Update()
    {
        LookAtCamera();
    }

    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        info = Pokedex.Instance.pokemonInfo[pokemonCode];
    }

    public override void onRelease()
    {

    }

    public override void onActivate()
    {

    }

    public void LookAtCamera()
    {
        // normalize cam position
        Vector3 norm = mainCamera.transform.position.normalized;
        // change orientation based on the direction
        float angle = Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg - 270F;
        // Add smooth rotation 
        transform.rotation = Quaternion.Slerp
            (transform.rotation, Quaternion.Euler(0.0f, angle, 0.0f), rotate_interval);
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
