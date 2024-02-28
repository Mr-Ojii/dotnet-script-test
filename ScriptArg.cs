using System.Diagnostics;

public class ScriptArg
{
    public ScriptArg(bool non)
    {
        isDebug = non;
    }
    public readonly bool isDebug = false;
    public void Info(string str) => Trace.TraceInformation(str);
    public void Warn(string str) => Trace.TraceWarning(str);
    public void Error(string str) => Trace.TraceError(str);
}