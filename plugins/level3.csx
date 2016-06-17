using System;
using System.Collections.Generic;
using Slacker.Exports;

// LEVEL 3
// 사칙 연산, 괄호
class Levels {
  public static string Prescript_3(string sender) {
    return @"x = 5";
  }
  
  public static void OnLevel_3(string sender) {
    var script = @"
*Level 3 : 기본적인 연산자 사용하기*
.
```
# 간단한 덧셈 연산이 가능합니다.
puts 5 + 5 # 10

# 괄호를 사용하여 덧셈을 먼저 계산하도록 지정할 수 있습니다.
puts (1 + 1) * 3 # 6

# 변수를 이용한 계산 또한 가능합니다.
a = 10
puts a + 20 # 30
```
.
>>> *따라 해 보기*
이번 레벨 또한 이전과 같이 아래의 코드를 가지고 시작합니다.
`x = 5`
.
`x`를 이용하여 어떤 방법으로든 25를 출력해 보세요.
  ";
    
    Slack.SendMessage($"@{sender}", script);
  }

  public static bool OnSubmit_3(string sender, string code, string result) {
    if (result == "25")
      return true;
    return false;
  }
}