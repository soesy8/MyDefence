using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MySample
{
    //게임 오브젝트의 이동
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지점 변수 선언 및 초기화
        //private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        //이동 목표 위치에 있는 오브젝트의 트랜스폼 객체 생성
        public Transform target;

        //이동 속도 변수 선언 및 초기화
        public float moveSpeed = 2f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.gameObject, gameObject : MoveTest 스크립트가 붙어있는 게임 오브젝트의 객체
            //this.gameObject.transform, gameObjct.transform, this.transform
            //    : MoveTest 스크립트가 붙어있는 게임 오브젝트의 트랜스폼의 객체(인스턴스)
            //this.transform, transform
            //this.transform.position = new Vector3(7f, 1f, 8f);
            //this.gameObject.transform.position = new Vector3(7f, 1f, 8f);

            //this.transform.position = targetPosition;

            //this.gameObject << 생략 가능
            //transform.position = target.position;
            //Debug.Log($"타겟의 위치 : {target.position}");

        }

        // Update is called once per frame
        void Update()
        {
            //현재 오브젝트의 위치 = (현재 위치, 이동할 위치, 속도*프레임)
            //현재 위치에서 이동할 위치를 향해 속도*프레임 속도로 이동 
            //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            //플레이어의 위치를 앞으로 이동 : z축 값이 증가한다
            //transform.position 연산
            //transform.position.z = transform.position.z + 1.0f; error
            //transform.position = transform.position + new Vector3(0f, 0f, 1f);
            //transform.position += new Vector3(0f, 0f, 1f);

            //앞, 뒤, 좌, 우, 위, 아래
            //transform.position += Vector3.forward;    //앞 Vector3(0f,0f,1f)
            //transform.position += Vector3.back;    //뒤 0,0,-1
            //transform.position += Vector3.left;    //좌 -1,0,0
            //transform.position += Vector3.right;    //우  1,0,0
            //transform.position += Vector3.up;    //위 0,1,0
            //transform.position += Vector3.down;    //아래 0,-1,0

            //Vector3.one : Vector3(1f,1f,1f); - 단위벡터
            //Vector3.zero : Vector3(0f,0f,0f); - 초기값

            //앞으로 이동
            //transform.position += Vector3.forward * Time.deltaTime;     //Vector3(0f,0f,1f) * 한 프레임에 걸리는 시간
            //transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

            //이동 요소
            //방향 : 이동할 방향 지정
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해주는 기능
            //속도(speed) : 이동의 빠르기를 지정

            //Translate
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

            //타겟까지 이동 (방향, Time.deltaTime, 속도)
            //이동 방향 구하기 : 목표지점 - 현재지점, 도착위치 - 시작위치
            //dir.normalized : dir방향으로 크기 1인 벡터, 단위벡터, 정규화된 벡터
            //dir.magnitude : dir의 크기, 벡터의 크기, 길이
            Vector3 dir = target.position - transform.position;
            Debug.Log($"dir : {dir}");
            Debug.Log($"dir.normalized : {dir.normalized}");
            Debug.Log($"dir.magnitude : {dir.magnitude}");
            //transform.Translate(moveSpeed * Time.deltaTime * dir.normalized);
            //transform.Translate(moveSpeed * Time.deltaTime * dir.normalized, Space.Self);
            transform.Translate(moveSpeed * Time.deltaTime * dir.normalized, Space.World);

            //Space.Self, Space.Wolrd
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);



        }
    }
}

/*
n 프레임 : 초당 n번 실행(보여주기)
20 프레임 : 초당 20번 실행
20 프레임이면 1 프레임 당 걸리는 시간 : 1 / 20 = 0.05sec

Time.deltaTime : 실제 한 프레임에 걸리는 시간

성능이 좋은 pc
10 프레임
- Time.deltaTime을 고려하지 않을 경우 1초에 10만큼 이동
- Time.deltaTime을 고려하는 경우 (*Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime : 0.1f
update문 10번 실행


성능이 나쁜 pc
2 프레임
-Time.deltaTime을 고려하지 않을 경우 1초에 2만큼 이동
-Time.deltaTime을 고려하는 경우 (*Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime : 0.5f
update문 2번 실행
*/