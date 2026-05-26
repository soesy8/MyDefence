using UnityEngine;
using System.Collections;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        //전역변수 선언 / 프리팹, 이동 목적지, 생성 간격
        public GameObject enemyPrefab;
        public Transform target;
        public float spawnDelay = 5f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //코루틴 메서드 선언
            StartCoroutine(SpawnRoutine());
        }

        //코루틴 메서드 구현
        IEnumerator SpawnRoutine()
        {
            //while문을 사용해 게임 플레이 중 계속 실행
            while (true)
            {
                //Instantiate를 사용하여 오브젝트 생성 기능 구현
                //GameObject 오브젝트이름 = Instantiate(프리팹, 생성위치, 회전값)
                //EnemyMove 스크립트를 참조, if문을 사용하여 이동로직 구현


                //코루틴의 지연기능 사용
            }

        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}