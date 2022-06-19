using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimController : MonoBehaviour
{
    //List of Animation Controllers

    public Animator startEncounter;
    public Animator catchPokemon;
    public Animator battleStart;
    public Animator inventory;

    public void triggerAnim(Animator anim)
    {
        anim.SetTrigger("Start");
    }

    public void openAnim(Animator anim)
    {
        anim.SetBool("Open", true);
    }

    public void closeAnim(Animator anim)
    {
        anim.SetBool("Open", false);
    }

    public void singularButtonOpenClose(Animator anim)
    {
        anim.SetBool("Open", !anim.GetBool("Open"));
    }
}
