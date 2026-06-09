using UnityEngine;

namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        public Transform target; // 이동할 종점(Target)의 위치
        public float speed = 5f;  // 이동 속도
        [SerializeField] private int maxHp = 100;   //최대 체력
        [SerializeField] private int rewardGold = 50;   //보상 골드
        private int hp;     //현재 체력
        [SerializeField] private GameObject deathEffectPrefab;

        void Start()
        {
            hp = maxHp;   //hp 초기화
        }
        
        //데미지를 받는 메서드
        public void TakeDamage(int damage)
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


        void Update()
        {
            // Target이 설정되어 있다면 이동하기
            if (target != null)
            {
                Vector3 dir = (target.position - transform.position).normalized;
                // 현재 위치에서 target 위치로 speed 속도로 이동
                //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                transform.Translate(speed * Time.deltaTime * dir);

                // 도착 판정 (거리가 아주 가까워지면 도착한 것으로 간주)
                if (Vector3.Distance(transform.position, target.position) < 0.1f)
                {
                    // 종점에 도착 완료했으므로 오브젝트 파괴 (Kill)
                    Destroy(gameObject);
                }
            }
        }
    }
}