using UnityEngine;

namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        #region Variables
        //이동 관련 변수
        public Transform target; // 이동할 종점(Target)의 위치
        public float speed = 5f;  // 이동 속도
        private float curSpeed; // 현재 이동 속도
        private float slowAmount = 1f; // 슬로우 계수 변수
        private float slowTimer = 0f; // 슬로우 타이머 변수
        
        //추가 데미지 변수
        private float laserHitTiime = 0f;

        //체력 관련 변수
        [SerializeField] private float maxHp = 100f;   //최대 체력
        private float hp;     //현재 체력

        //죽음 효과 관련 변수
        [SerializeField] private GameObject deathEffectPrefab;  //죽음 효과 프리팹
        [SerializeField] private int rewardGold = 50;   //보상 골드
        #endregion

        #region Unity Evnet Method
        void Start()
        {
            hp = maxHp;   //hp 초기화
            curSpeed = speed; //현재 속도 초기화
        }

        void Update()
        {
            if (slowTimer > 0)
            {
                slowTimer -= Time.deltaTime;
            }
            else
            {
                slowAmount = 1f;
            }

            curSpeed = speed * slowAmount;

            // Target이 설정되어 있다면 이동하기
            if (target != null)
            {
                Vector3 dir = (target.position - transform.position).normalized;
                // 현재 위치에서 target 위치로 speed 속도로 이동
                //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                transform.Translate(curSpeed * Time.deltaTime * dir);

                // 도착 판정 (거리가 아주 가까워지면 도착한 것으로 간주)
                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    // 종점에 도착 완료했으므로 오브젝트 파괴 (Kill)
                    Destroy(gameObject);
                }
            }


        }
        #endregion

        #region Custom Method
        //데미지를 받는 메서드
        public void TakeDamage(float damage)
        {
            hp -= damage;

            if (hp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            GameData.AddGold(rewardGold);

            if (deathEffectPrefab)
            {
                GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
            }

            Destroy(gameObject);

        }

        public void Slow(float percent, float duration)
        {
            //슬로우 수치
            slowAmount = 1f - percent;

            //슬로우 지속시간
            slowTimer = duration;
        }

        public void BonusDamage(float damage, float interval)
        {
            laserHitTiime += Time.deltaTime;

            if (laserHitTiime >= interval)
            {
                TakeDamage(damage);
                Debug.Log($"추가 데미지: {damage}");
                ResetLaserHit();
            }
        }

        public void ResetLaserHit() 
        { 
            laserHitTiime = 0f;
            Debug.Log("레이저 히트 타이머 초기화");
        }
        #endregion
    }
}