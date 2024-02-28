using Microsoft.CodeAnalysis.Scripting;

public class ScriptSDK
{
    public Action<ScriptArg>? init = null;
    public Action<ScriptArg>? update = null;
    public Action<ScriptArg>? exit = null;
}