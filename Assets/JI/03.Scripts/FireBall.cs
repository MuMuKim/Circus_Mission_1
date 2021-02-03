using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject ball; // 공 프리팹
    public Transform ballPosition; // 공을 발사할 위치
    public float speed = 4f; // 공이 날아갈 속도

    int poolSize = 10; // 공의 제한 갯수
    GameObject[] poolIndex;// 공(오브젝트)들을 담을 배열

    void Start()
    {
        // 공을 10개 담을 공간을 만든다. 
        poolIndex = new GameObject[poolSize]; 

        //오브젝트 풀
        for (int i = 0; i < poolSize; i++) //배열의 사이즈 만큼 전수검사한다.
        {
            //배열안에 공들을 생성시킨 후, 발사위치에 위치시킨다.
            poolIndex[i] = Instantiate(ball, ballPosition.position, ballPosition.rotation); 
           
            // 공들을 비활성화 시킨다.
            poolIndex[i].SetActive(false);
        }
    }

    public void Fire()
    {
        for (int i = 0; i < poolSize; i++) //배열의 사이즈 만큼 전수검사한다.
        {
            if(poolIndex[i].gameObject.activeSelf == false) //배열안에 담아있는 공의 상태가 비활성화 상태라면
            {
                //공을 발사위치로 위치 시킨 후,
                poolIndex[i].gameObject.transform.position = ballPosition.position;
                poolIndex[i].gameObject.transform.rotation = ballPosition.rotation;

                //배열안에 있는 공을 활성화 시킨다.
                poolIndex[i].gameObject.SetActive(true);

                //공의 Rigidbody컴포넌트를 받아와 velocity값을 공의 Y축으로 speed 변수의 속도만큼 발사한다.
                poolIndex[i].gameObject.GetComponent<Rigidbody>().velocity = poolIndex[i].gameObject.transform.up * speed;

                //돌아가 다시 전수검사를 시작한다.
                break; 
            }
        }
    }
}
