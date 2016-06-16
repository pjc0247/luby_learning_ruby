using System;
using System.Collections.Generic;
using Slacker.Exports;

// LEVEL 2
// 변수
class Levels {
  public static string Prescript_2(string sender) {
    return @"x = 5";
  }
  
  public static void OnLevel_2(string sender) {
    var script = @"
*Level 2 : 변수 사용하기*
.
```
# x는 1234라는 값을 저장합니다.
x = 1234
puts x

# 쌍따옴표를 사용하면 문자열을 나타낼 수 있습니다. 
y = ""hello""
puts y
```
.
>>> *따라 해 보기*
이번 레벨은 아래의 코드를 가지고 시작합니다.
`x = 5`
.
`x`값을 `puts`를 이용해 출력하는 코드를 작성해 보세요.
";
    
    Slack.SendMessage($"@{sender}", script);
  }

  public static bool OnSubmit_2(string sender, string code, string result) {
    if (code == "puts x")
      return true;
    return false;
  }
}