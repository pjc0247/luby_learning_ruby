using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Slacker.Exports;

[Subscribe("hibot")]
public void OnStartTutorial(Message msg){
  Levels.OnLevel_1(msg.sender);
  SetLevel(msg.sender, 1);
}            

// for debugging purpose
[Subscribe("jump")]
public void OnJump(Message msg) {
  var level = GetLevel(msg.sender);
  SetLevel(msg.sender, level + 1);
  
  Slack.SendMessage($"@{msg.sender}", $"youvejumptedtolevel {level + 1}");
}

[Subscribe("```((.|\n)+)```")]
public void OnMultilineScript(Message msg) {
  OnSubmit(msg);
}
[Subscribe("^`([^`].+)`$")]
public void OnScript(Message msg) {
  OnSubmit(msg);
}

// TODO : 리플렉션 부분 모듈 분리해서 깔끔하게 하기
public void OnSubmit(Message msg) {
  var originalCode = msg.matchData.Groups[1].Value; 
  var code = originalCode;
  var level = GetLevel(msg.sender);
  
  var prescriptFunc = typeof(Levels).GetMethod($"Prescript_{level}");
  if (prescriptFunc != null) {
    var prescript = (string)prescriptFunc.Invoke(null, new object[] {msg.sender});
    Console.WriteLine(prescript);
    code = prescript + "\r\n" + code;
  }
  
  ExecScript(code, (result) => {
    Slack.SendMessage($"@{msg.sender}", "*실행결과*\n```\n" + result + "```");
  
    var handler = typeof(Levels).GetMethod($"OnSubmit_{level}");
    if (handler != null) {
      var pass = handler.Invoke(
        null,
        new object[] {msg.sender, originalCode.Trim(), result.Trim()});
      
      if ((bool)pass == true) {
        Console.WriteLine("PASS");
        SetLevel(msg.sender, level + 1);
        
        var initializer = typeof(Levels).GetMethod($"OnLevel_{level + 1}");
        initializer?.Invoke(null, new object[] {msg.sender});
      }
      else {
        Console.WriteLine("FAILE");
      }
    }
  });
}

