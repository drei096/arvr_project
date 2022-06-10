using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrainer : APoolable
{
    public StructHandler.TrainerInfo trainerInfo;
    public TrainerCode trainerCode;

    public void ResetPokemonParty()
    {

    }
    public void RandomAttack()
    {

    }
    public override void initialize()
    {
        this.transform.SetParent(this.poolRef.poolableLocation);
        //trainerInfo = Pokedex.Instance.trainerInfo[trainerCode];
    }

    public override void onRelease()
    {

    }

    public override void onActivate()
    {

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
