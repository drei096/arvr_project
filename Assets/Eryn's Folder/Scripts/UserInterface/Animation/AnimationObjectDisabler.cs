using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObjectDisabler : MonoBehaviour
{
    public void disableThis()
    {
        this.gameObject.SetActive(false);
    }
    
    public void enableThis()
    {
        this.gameObject.SetActive(true);
    }
}
