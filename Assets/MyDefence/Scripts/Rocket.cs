using UnityEngine;

namespace MyDefence
{
    public class Rocket : MonoBehaviour
    {
        #region Variables
        //타워가 타겟팅한 타겟의 정보를 받아줄 변수
        private GameObject _target;

        //타겟을 private으로 돌리고 property를 이용해 값을 저장하고 가져옴
        public GameObject Target
        {
            get { return _target; }
            set { _target = value; }
        }

        //총알 속도
        public float rocketSpeed = 50.0f;

        //데미지 범위
        private float damageRange = 3.5f;

        //타격 효과
        public GameObject rocketImpactPrefab;   //임팩트 파티클 게임 오브젝트
        #endregion


        #region Unity Event Method
        void Update()
        {
            //nullcheck - 타겟이 null이면 총알 파괴
            if (Target == null)
            {
                Destroy(gameObject);
                return;
            }

            //날아갈 방향
            Vector3 dir = (Target.transform.position - transform.position).normalized;

            //충돌 판정 연산
            if (CheckPassPosition() == true)
            {
                HitTarget();                    //적 처치 및 탄환 파괴
            }

            //이동
            transform.Translate(rocketSpeed * Time.deltaTime * dir, Space.World);

        }

        #endregion


        #region Custom Method
        //이동 시 타겟까지 남은 거리와 이번 프레임에 이동 거리를 비교하여 충돌판정
        public bool CheckPassPosition()
        {
            //Enemy와 Rocket 사이의 거리 연산
            float distance = Vector3.Distance(transform.position, Target.transform.position);

            //이번 프레임 이동 거리
            float distanceThisFrame = Time.deltaTime * rocketSpeed;

            if (distance <= distanceThisFrame)
            {
                return true;
            }

            return false;
        }

        //명중 시 파괴
        void HitTarget()
        {
            if (rocketImpactPrefab)     //!= null 과 같은 의미
            {
                //로켓이 적을 타격할 때 로켓이 부서져서 파편이 날아가는 효과
                GameObject effectGo = Instantiate(rocketImpactPrefab, transform.position, Quaternion.identity);
                //킬 예약
                Destroy(effectGo, 2.0f);
            }

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRange);
            foreach (Collider hit in hitColliders)
            {
                //hit.tag == "Enemy" 와 같은 기능
                if (hit.CompareTag("Enemy"))
                {
                    //범위 내의 적 파괴
                    Destroy(hit.gameObject);
                }
            }
            Destroy(gameObject);    //탄 파괴
        }
        #endregion
    }
}