using UnityEngine;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 범위 안에 있는 가장 가까운 적
        private GameObject target;
        //타워 공격 범위
        public float atkRange = 7.0f;

        //터렛의 회전 속도
        public Transform partToRotate;
        public float turnSpeed = 10.0f;

        //SearchTimer 0.2sec
        public float searchTimer = 0.25f;
        private float countdown = 0f;

        //attackSpeedTimer
        public float atkTimer = 1.0f;
        private float atkCountdown = 0.0f;

        public GameObject bullet;
        public Transform firePoint;

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
                //타이머 실행문 - 탄 발사
                Debug.Log("Pew");
                //instantiate로 탄환 생성
                GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity, partToRotate);
                //탄환 이동 목표 주입
                Bullet shootBullet = newBullet.GetComponent<Bullet>();
                shootBullet.target = target;
                //타이머 초기화
                atkCountdown = 0f;
            }



        }
        
        
        //해당(스크립트가 붙어있는) 오브젝트를 선택했을 때만
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(transform.position, attackRange);
            Gizmos.DrawWireSphere(transform.position, atkRange);
        }

        //항상 기즈모를 그린다
        /*private void OnDrawGizmos()
        {

        }*/



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


        #endregion

    }
}