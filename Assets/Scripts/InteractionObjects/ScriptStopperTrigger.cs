using System.Collections.Generic;
using UnityEngine;

public class ScriptStopperTrigger : MonoBehaviour {

    public List<ScriptStarterBehaviour> Targets;
    public string TriggerTag;

    // Use this for initialization
    void Start () {
        if (this.Targets.Count == 0)
            throw new System.Exception("Targets must be set.");
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == this.TriggerTag)
            this.Targets.ForEach(item => item.StopScript());
    }
}
