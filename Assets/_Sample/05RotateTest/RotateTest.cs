using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 회전 테스트 예제 스크립트
    /// </summary>
    public class RotateTest : MonoBehaviour
    {
        #region 변수
        //회전 속도
        public float turnSpeed = 5f;
        public float moveSpeed = 5f;

        //회전 값 변수
        //private float x = 0;

        //목표 오브젝트
        public Transform target;
        
        #endregion

        #region 유니티 이벤트 함수
        private void Start()
        {
            //transform.rotation = Quaternion.Euler(0f, 90f, 0f);   //y축 회전 : 오른쪽을 바라봄
            //transform.rotation = Quaternion.Euler(90f, 0f, 0f);   //x축 회전 : 앞으로 숙여 아래를 바라봄
            //transform.rotation = Quaternion.Euler(90f, 0f, 0f);     //z축 회전 : 오른쪽으로 누워 앞을 바라봄


        }

        private void Update()
        {
            //축 회전
            //x += 1;
            //transform.rotation = Quaternion.Euler(x, 0, 0);     //x축 회전
            //transform.rotation = Quaternion.Euler(0, x, 0);     //y축 회전
            //transform.rotation = Quaternion.Euler(0, 0, x);     //z축 회전

            // [1] Rotate - 지구의 자전
            //transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            // [1-1] RotateAround - 지구의 공전
            //transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

            // [2] 원하는(목표) 방향을 회전 
            /*Vector3 dir = target.position - transform.position;
            //목표 방향에 해당되는 회전 값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            //트랜스폼의 회전 값을 구한 회전 값에 대입
            //transform.rotation = lookRotation;

            //transform.rotation (0,0,0) => lookRotation; (0,41,0)
            //Quaternion Lerp(Quaternion a, Quaternion b, float t);
            //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation , Time.deltaTime * 0.5f);
            
            Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation , Time.deltaTime * 0.5f);
            //Quaternion으로 부터 오일러 값(xyz) 구하기
            Vector3 euler = qRotation.eulerAngles;
            //y축 회전하는 회전 값을 구한다
            transform.rotation = Quaternion.Euler(0f, euler.y, 0f);*/

            //이동 dir * Time.deltaTime * speed
            Vector3 dir = (target.position - transform.position).normalized;        //방향 구하기
            transform.rotation = Quaternion.LookRotation(dir);                      //오브젝트 방향 대입

            /*Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 0.5f);
            Vector3 euler = qRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, euler.y, 0f);*/

            //회전하면서 이동해서 이상해짐. Space.World로 적용하면 정삭적으로 이동함
            //transform.Translate(moveSpeed * Time.deltaTime * dir, Space.Self);

            transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.Self);     //오브젝트 이동

        }
        #endregion
    }
}

/*
float t는 0 ~ 1 의 범위를 가짐 ( 0% ~ 100% 라고 생각하면 편할듯)
transform.rotation = Lerp( a, b, t );       / Lerp( 현재 회전치 , 목표 회전치, 진행도 )
a = 0, b = 10, t = 0.1(10%)> 10 의 10% = 1  >  a = 1, b = 10, t = 0.1
> 9의 10% = 0.9 > a = 1.9 .. > 8.1 의 10% = 0.81 > a = 2.71 , .. 회전 값이 변하는 속도가 점점 줄어듦



*/