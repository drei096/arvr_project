using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolFunctions
{
    //What will happen to the currentPoolObject after it was spawn in the world?
    public void onRequestGo(StructHandler.OnRequestStruct info);
    //What will happen to the currentPoolObject after it was release in the world?
    public void onReleaseGo(StructHandler.OnReleaseStruct info);
}