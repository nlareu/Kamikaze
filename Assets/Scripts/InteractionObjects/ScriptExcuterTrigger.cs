using UnityEngine;

public class ScriptExcuterTrigger : MonoBehaviour {

    public ScriptExecuterBehaviour Target;
    public string TriggerTag;

    // Use this for initialization
    void Start () {
        if (this.Target == null)
            throw new System.Exception("Target must be set.");
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == this.TriggerTag)
            this.Target.ExecuteScript();
    }
}
