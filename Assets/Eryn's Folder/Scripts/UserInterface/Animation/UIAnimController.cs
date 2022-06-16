using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimController : MonoBehaviour
{
    //List of Animation Controllers

    public Animator startEncounter;
    public Animator catchPokemon;

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
}
