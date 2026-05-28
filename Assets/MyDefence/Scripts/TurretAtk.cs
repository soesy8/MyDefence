using UnityEngine;

namespace MyDefence
{
    public class TurretAtk : MonoBehaviour
    {
        //Enemy를 추적하는 Turret의 회전을 관리하는 클래스
        #region Variables
        //타겟할 적
        private Transform target;
        #endregion


        #region Unity Event Method
        void Update()
        {
            //태그로 적 찾기
            GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");

            //null check
            if (enemyObj == null)
            {
                target = null;
                return;
            }

            //null check 후 적이 존재하면 타겟 고정
            target = enemyObj.transform;

            //Enemy와 turret 사이의 방향 연산
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookEnemy = Quaternion.LookRotation(dir);

            //방향 대입해서 회전
            transform.rotation = lookEnemy;
        }

        #endregion


        #region Custom Method

        #endregion
    }
}