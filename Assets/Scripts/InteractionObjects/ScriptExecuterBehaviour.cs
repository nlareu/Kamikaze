using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptExecuterBehaviour : MonoBehaviour, IScriptExecuter
{
    public bool Executing { get; protected set;}

    public ScriptExecuterBehaviour()
    {
        this.Executing = false;
    }

    public void ExecuteScript()
    {
        if (this.Executing == false)
            this.Executing = true;
    }    
}