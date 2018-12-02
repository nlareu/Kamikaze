public interface IScriptExecuter
{
    bool Executing { get; }

    void ExecuteScript();
}