using System.IO;
﻿using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Scripting;

DefaultTraceListener? dtl = (DefaultTraceListener?)Trace.Listeners["Default"];
if (dtl != null)
    dtl.LogFileName = Path.Combine(Directory.GetCurrentDirectory(), "ScriptText.log");

string a = """
using System;
Console.WriteLine("Hello");

init = (a) => {
    a.Info("i");
};

update = (a) => {
    a.Info("u");
};

exit = (a) => {
    a.Info("e");
};

""";

var b = CSharpScript.Create(a, null, typeof(ScriptSDK));
ScriptSDK sdk = new();
await b.RunAsync(sdk);
ScriptArg arg = new(false);

if (sdk.init != null && sdk.update != null && sdk.exit != null)
{
    Trace.WriteLine("init script");
    Trace.Indent();
    if (sdk.init != null)
        sdk.init(arg);
    Trace.Unindent();
    Trace.WriteLine("update script");
    Trace.Indent();
    if (sdk.update != null)
        sdk.update(arg);
    Trace.Unindent();
    Trace.WriteLine("exit script");
    Trace.Indent();
    if (sdk.exit != null)
        sdk.exit(arg);
    Trace.Unindent();
}

