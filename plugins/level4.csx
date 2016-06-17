using System;
using System.Collections.Generic;
using Slacker.Exports;

// LEVEL 4
// 조건문
class Levels {
  private static Dictionary<string, string> level4_expectedResult { get; set; }
    = new Dictionary<string, string>();
    
  public static string Prescript_4(string sender) {
    int n = (new Random()).Next(10, 40);
    level4_expectedResult[sender] = n / 2 > 10 ? "1" : "2";
    return $"x = {n}";
  }
  
  public static void OnLevel_4(string sender) {
    var script = @"
*Level 4 : 조건문*
.
`if` 는 주어진 조건이 맞는지 틀린지를 검사합니다.
만약 주어진 조건이 *맞을* 경우 `if` 아래줄부터 `end` 사이의 코드를 실행합니다.
.
```
x = 10

if x > 5
  # if 아래에 조건이 맞을 경우 실행될 코드를 작성합니다.
  #
  # 보통 이 영역에서는 가독성을 위해서
  # 문장 앞에 스페이스(' ') 2개를 넣고 시작합니다.
  puts ""x는 5보다 커요""
  
end # 코드 작성이 끝났으면 `end`를 통해 if 영역이 끝났음을 알립니다.
```
.
`else` 는 `if` 에서 주어진 조건이 *틀릴* 경우의 코드를 작성할 수 있도록 해 줍니다.
`if ~ end` 사이에 `else`를 적고 그 아래 코드를 작성하면 해당 부분의 코드는 조건이 틀릴때 실행됩니다.
```
x = 3

if x > 5
  puts ""x는 5보다 커요""
else
  puts ""x는 5보다 같거나 작아요""
end
```
.
>>> *따라 해 보기*
이번 레벨은 무작위 `x`값이 주어집니다. 
`x = ??? # 랜덤값`
.
주어진 `x`를 2로 나눈 값이 10보다 크면 `1`을, 그렇지 않으면 `2`를 출력하는 코드를 작성해 보세요.
( 여러 줄의 코드를 실행시키려면 backstrick('`')을 3번 입력하여 감싸주세요. )
  ";
    
    Slack.SendMessage($"@{sender}", script);
  }

  public static bool OnSubmit_4(string sender, string code, string result) {
    if (level4_expectedResult.ContainsKey(sender) && result == level4_expectedResult[sender]) {
      level4_expectedResult.Remove(sender);
      return true;
    }
    return false;
  }
}