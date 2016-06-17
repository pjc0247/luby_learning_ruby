using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Slacker.Exports;

public void ExecScript(string script, Action<string> callback) {
  var worker = new Thread(() => {
    var name = Path.GetTempFileName();
    var startInfo = new ProcessStartInfo();
    string result = "";
    
    File.WriteAllText(name, script);
    
    startInfo.UseShellExecute = false;
    startInfo.RedirectStandardError = true;
    startInfo.RedirectStandardOutput = true;
    startInfo.FileName = "ruby.exe";
    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    startInfo.Arguments = "-T3 " + name;

    try {
      Console.WriteLine("StartCode");
      using (var p = Process.Start(startInfo)) {
        if (p.WaitForExit(2000)) {
          result += p.StandardOutput.ReadToEnd ();
          result += "\r\n";
          result += p.StandardError.ReadToEnd ();  
        }
        else
          result = "TimeOut";
          Console.WriteLine(result);
      }
    } 
    catch(Exception e) {
      Console.WriteLine(e);
    }
    
    Bot.RunOnBotContext(() => {
      callback(result);
    });  
  });
  worker.Start();
} 