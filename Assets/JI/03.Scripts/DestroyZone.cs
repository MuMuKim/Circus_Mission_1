using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BALL")) //닿은 오브젝트의 태그가 BALL(공)일 경우
        {
            collision.gameObject.SetActive(false); //대상을 비활성화 시킨다.
        }
    }
}
