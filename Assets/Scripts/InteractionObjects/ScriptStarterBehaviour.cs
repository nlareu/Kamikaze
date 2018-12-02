using UnityEngine;

public class ScriptStarterBehaviour : MonoBehaviour, IScriptStarter
{
    public bool Started { get; private set;}

    public ScriptStarterBehaviour()
    {
        this.Started = false;
    }

    public void StartScript()
    {
        if (this.Started == false)
        {
            this.gameObject.SetActive(true);

            this.Started = true;
        }
    }

    public void StopScript()
    {
        if (this.Started == true)
        {
            this.Stop();

            this.Started = false;
        }
    }

    protected virtual void Stop()
    { }
}