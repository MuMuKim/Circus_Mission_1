using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCtrl : MonoBehaviour
{

    public Text scoreText; //스코어를 나타내는 UI텍스트

    public int currentScore; //나타낼 현재 점수
    public int score; //획득한 점수

    int targetMove = 1; //위치에 힘을 담을 변수

    public GameObject scoreEffect; //공이 바구니에 닿을 당시 나타내는 이펙트
    

    void Update()
    {
        if(transform.localPosition.x > 3f) //바구니의 x값이 3보다 크면 targetMove를 -1로
        {
            targetMove = -1;
        }
        else if(transform.localPosition.x < -3f) //바구니의 x값이 -3보다 targetMove를 1로
        {
            targetMove = 1;
        }

        //x축으로 0.5의 속도로 움직이며, targetMove의 정수값에 따라 방향을 바꾼다.
        transform.Translate(Vector3.right * 0.5f * Time.deltaTime * targetMove);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BALL")) //닿은 오브젝트의 태그가 BALL(공)일 경우
        {
            GameObject effect = Instantiate(scoreEffect); //이펙트를 생성해 변수에 담아놓은 후,
            effect.transform.position = collision.transform.position; //이펙트를 나타낼 위치

            collision.gameObject.SetActive(false); //대상을 비활성화 시킨다.
            
            score++; //점수를 1올린다.
            currentScore = score; //나타낼 현재점수에 획득한 점수를 담는다.
            scoreText.text = currentScore.ToString(); //현재점수의 Int값을 String으로 형변환 시킨 후, 스코어 텍스트에 담는다.
            print(score); //디버그
        }
    }
}
