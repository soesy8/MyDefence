using UnityEngine;

namespace MyDefence
{
    public class RocketLuncher : MonoBehaviour
    {
        #region Var
        //공격 범위 안에 있는 가장 가까운 적
        private GameObject target;
        //타워 공격 범위
        private float atkRange = 14.0f;

        //터렛의 회전 속도
        public Transform partToRotate;
        private float turnSpeed = 10.0f;

        //SearchTimer 0.2sec
        private float searchTimer = 0.25f;
        private float countdown = 0f;

        //attackSpeedTimer
        [SerializeField] private float atkTimer = 4.0f;
        private float atkCountdown = 0.0f;

        //탄환 원본 및 발사 위치 변수
        public GameObject rocketPrefab;
        public Transform launchPoint;
        #endregion



        #region Unity Event Method
        void Update()
        {
            //0.2초 마다 한 번씩 공격 범위 안에 있는 가장 가까운 적 찾기
            countdown += Time.deltaTime;
            if (countdown >= searchTimer)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = 0f;
            }

            //타겟을 못찾았을 경우
            if (target == null)
                return;

            //lockon
            LockOn();

            //타겟팅이 되면 공격
            atkCountdown += Time.deltaTime;

            if (atkCountdown >= atkTimer)
            {
                //타이머 실행문 - 로켓 발사
                //Debug.Log("Launch");
                Launch();                //발사과정 함수로 묶음

                //타이머 초기화
                atkCountdown = 0f;
            }



        }
        #endregion



        #region Custom Method
        //터렛에서 가장 가까운 적 찾아 타겟으로 설정
        void UpdateTarget()
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closest = null;              //가장 가까운 enemy
            float minDistance = Mathf.Infinity;     //기준 값

            foreach (GameObject enemy in enemies)
            {
                //적과 터렛의 거리 구하기
                float distance = Vector3.Distance(enemy.transform.position, transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = enemy;                //최소 거리에 해당하는 적
                }
            }

            //closest 검증
            if (closest != null && minDistance <= atkRange)
            {
                target = closest;
            }
            else
            {
                target = null;
            }

        }

        void LockOn()
        {
            //터렛(가장 가까운 enemy의 움직임에 따라 터렛 헤드가 타겟 방향으로 회전
            Vector3 dir = (target.transform.position - partToRotate.position).normalized;

            //목표 방향에 해당되는 회전 값 구하기
            Quaternion lookEnemy = Quaternion.LookRotation(dir);
            partToRotate.rotation = Quaternion.Lerp(partToRotate.rotation, lookEnemy, Time.deltaTime * turnSpeed);
        }

        //탄환 발사
        void Launch()
        {
            //instantiate로 탄환 생성
            GameObject rocketGo = Instantiate(rocketPrefab, launchPoint.position, launchPoint.rotation, launchPoint);

            //탄환 이동 목표 주입
            //탄환 오브젝트에 부착되어 있는 Bullet 클래스의 인스턴스 가져오기
            Rocket rocket = rocketGo.GetComponent<Rocket>();

            //nullcheck
            if (rocket != null)
            {
                rocket.Target = target;
            }
        }
        #endregion
    }
}