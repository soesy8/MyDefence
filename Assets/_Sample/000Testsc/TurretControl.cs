using UnityEngine;

namespace MyDefence
{
    public class TurretControl : MonoBehaviour
    {
        //Enemy를 추적하는 Turret의 회전을 관리하는 클래스
        #region Variables
        //타겟할 적
        private Transform target;
        //터렛 사거리 변수
        private float attackRange = 7.0f;
        #endregion

        #region Unity Event Method
        void Update()
        {
            //태그로 적을 배열로 가져오기
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject targetEnemy = null;              //가까운 적을 기억할 변수
            float shortestDistance = Mathf.Infinity;    //비교 값

            foreach (GameObject enemy in enemies)
            {
                //적과의 거리 계산
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

                //적과의 거리 <= 사거리 && 적과의 거리 < 비교값
                if (enemyDistance <= attackRange && enemyDistance < shortestDistance)
                {
                    shortestDistance = enemyDistance;
                    targetEnemy = enemy;
                }
            }

            //타겟이 된다면 실행
            if (targetEnemy != null)
            {
                //사거리 체크 후 적이 존재하면 타겟 고정
                target = targetEnemy.transform;

                //Enemy와 turret 사이의 방향 연산
                Vector3 dir = (target.position - transform.position).normalized;
                Quaternion lookEnemy = Quaternion.LookRotation(dir);

                //방향 대입해서 회전
                transform.rotation = lookEnemy;
            }
            else
            {
                target = null;
            }

        }

        #endregion
    }
}