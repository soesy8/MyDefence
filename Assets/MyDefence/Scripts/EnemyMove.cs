using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    //필드
    public Transform target;
    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GoNDestroy());   //코루틴 함수 선언
    }

    IEnumerator GoNDestroy()    //코루틴 함수 사용
    {
        while (target != null)      //타겟이 존재할 때만 작동
        {
            //이동거리 변수
            //목표까지의 거리 변수
            float moveStep = moveSpeed * Time.deltaTime;
            float curDistance = Vector3.Distance(transform.position, target.position);

            if (moveStep >= curDistance)    //이동할 거리 >= 목표까지의 거리
            {
                transform.position = target.position;   //오브젝트를 목표 위치로 이동
                Destroy(gameObject);                    //파괴
                Debug.Log("파괴");
                yield break;                            //코루틴 함수 종료
            }
            Vector3 dir = (target.position - transform.position).normalized;    //이동방향 계산
            //transform.position += moveSpeed * Time.deltaTime * dir;
            transform.Translate(moveSpeed * Time.deltaTime * dir);              //이동로직
            Debug.Log("움직이는 중");

            yield return null;                                                  //코루틴 함수 종료
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
