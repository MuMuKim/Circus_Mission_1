using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public BallCtrl ballCtrl; //BallCtrl 스크립트를 담을 변수
    
    public void ResetScore() //스코어를 리셋시킬 함수
    {
        //스코어를 0으로 만든 후,
        ballCtrl.score = 0; 
        //스코어를 String으로 형변환 후, 스코어텍스트에 담는다.
        ballCtrl.scoreText.text = ballCtrl.score.ToString();
    }
}
