using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Slacker.Exports;

public string ExecScript(string script){
  var name = Path.GetTempFileName();
  var startInfo = new ProcessStartInfo();
  string result = "";
  
  File.WriteAllText(name, script);
  
  startInfo.UseShellExecute = false;
  startInfo.RedirectStandardError = true;
  startInfo.RedirectStandardOutput = true;
  startInfo.FileName = "ruby.exe";
  startInfo.WindowStyle = ProcessWindowStyle.Hidden;
  startInfo.Arguments = name;

  try {
    using (var p = Process.Start(startInfo)) {
      p.WaitForExit();
        
      result += p.StandardOutput.ReadToEnd ();
      result += "\r\n";
      result += p.StandardError.ReadToEnd ();
    }
  }
  catch(Exception e) {
    Console.WriteLine(e);
  }
  
  return result;
}