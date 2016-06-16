using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Slacker.Exports;

[Bootstrap]  
public void OnInitLevelData() {
  try{
    var tmp = Persistent.levels;
    
    if (! tmp is Dictionary<string, int>)
      throw new Exception();
  }
  catch {
    Console.WriteLine("Create Level Data");
    Persistent.levels = new Dictionary<string, int>();
  }
}

public void SetLevel(string user, int level) {
  Persistent.levels[user] = level;
}
public int GetLevel(string user) {
  if (Persistent.levels.ContainsKey(user))
    return Persistent.levels[user];
  return 0;
}