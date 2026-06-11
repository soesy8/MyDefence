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

        //레이저 임팩트 파티클/라이트 인스턴스 가져오기
        public ParticleSystem laserImpact;
        public Light laserLight;

        //레이저 데미지 관련 변수
        [SerializeField] private float atkDamage = 30f;     //초당 데미지
        //[SerializeField] private float bonusDamage = 15f;   //추가 데미지
        //[SerializeField] private float bonusDamageInterval = 1.5f;  //추가 데미지 간격

        [SerializeField] private float slowDebuff = 0.4f; //레이저 슬로우
        [SerializeField] private float slowDuration = 1f; // 슬로우 지속시간
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = false;
            laserLight.enabled = false;
            laserImpact.Stop();
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
                    laserLight.enabled = false;
                    lineRenderer.enabled = false;
                    laserImpact.Stop();
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
            //적에게 데미지 주기
            Enemy enemy = target.GetComponent<Enemy>();

            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                //enemy.ResetLaserHit();
                laserImpact.Play();
                laserLight.enabled = true;
            }

            //라인 렌더러 그리기 - 시작지점, 엔드지점 설정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);

            //레이저 타격 이펙트 위치와 회전 설정
            Vector3 dir = (firePoint.position - target.transform.position).normalized;
            laserImpact.transform.position = target.transform.position + dir / 2;
            laserImpact.transform.rotation = Quaternion.LookRotation(dir);
            //laserImpact.LookAt(firePoint);


            if (enemy != null)
            {
                enemy.TakeDamage(atkDamage * Time.deltaTime);

                enemy.Slow(slowDebuff, slowDuration);

                //enemy.BonusDamage(bonusDamage, bonusDamageInterval);
            }
        }


        #endregion
    }
}