using System;
using System.Collections.Generic;
using Slacker.Exports;

// LEVEL 1
// 기본 출력 : puts
class Levels {
  public static void OnLevel_1(string sender) {
    var script = @"
*Level 0 : 봇의 사용방법*
  코드를 제출할 때에는 backtrick(`)문자로 코드를 감쌉니다.
  예) _`이곳에 코드를 작성합니다.`
  .
  만약 여러줄의 코드를 작성하고 싶다면 backtrick을 세번(```) 입력하여 코드를 감쌉니다.
  예)
  ```

      ```
      ㅁㄴㅇㄹㅇㄱ 이ㅓ거대체어케쓰는거야
      ```

  ```
.
*Level 1 : 화면에 출력하기*
  .
  puts는 화면에 값을 출력하는 역할을 합니다.
  .
>>> *따라 해 보기*
  `puts 1234` 를 입력해보세요.
  ";
    
    Slack.SendImage($"@{sender}", 
        "http://iwanttolearnruby.com/images/ruby-style-guide.gif");
    Slack.SendMessage($"@{sender}", script);
  }

  public static bool OnSubmit_1(string sender, string code, string result) {
    Console.WriteLine("OnSubmit" + code);
    if (code == "puts 1234") {
      Slack.SendImage($"@{sender}", 
        "http://clipartix.com/wp-content/uploads/2016/04/Congratulations-clipart-3.jpg");
      return true;
    }
    return false;
  }
}
 
