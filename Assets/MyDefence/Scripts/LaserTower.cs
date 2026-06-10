using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 레이저 타워를 관리하는 클래스, tower 상속 받는다
    /// 레이저 빔 쏘기
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //라인 렌더러 인스턴스 - 레이저 빔
        private LineRenderer lineRenderer;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            lineRenderer = GetComponent<LineRenderer>();
        }

        protected override void Update()
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
            {
                //레이저 빔 끄기
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
                return;

            }

            //lockon
            LockOn();

            //레이저 빔 쏘기
            ShootLaser();
        }
        #endregion

        #region Custom Method
        void ShootLaser()
        {
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }

            //라인 렌더러 그리기 - 시작지점, 엔드지점 설정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);


            /*//라인 렌더러의 시작점과 끝점 설정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);
            //적에게 데미지 주기
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(atk * Time.deltaTime);
            }*/
        }
        #endregion
    }
}