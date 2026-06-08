using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        protected GameObject _target;

        public GameObject Target
        {
            get { return _target; }
            set { _target = value; }
        }

        [SerializeField]
        protected float bulletSpeed = 70.0f;

        [SerializeField]
        protected GameObject bulletImpactPrefab;

        protected virtual void Update()
        {
            if (Target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir =
                (Target.transform.position - transform.position).normalized;

            if (CheckPassPosition())
            {
                HitTarget();
                return;
            }

            transform.Translate(
                bulletSpeed * Time.deltaTime * dir, Space.World);
        }

        protected bool CheckPassPosition()
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);

            float distanceThisFrame = Time.deltaTime * bulletSpeed;

            return distance <= distanceThisFrame;
        }

        // 자식 클래스에서 재정의 가능
        protected virtual void HitTarget()
        {
            if (bulletImpactPrefab)
            {
                GameObject effectGo = Instantiate(bulletImpactPrefab, transform.position, Quaternion.identity);

                Destroy(effectGo, 2.0f);
            }

            Destroy(Target);
            Destroy(gameObject);
        }

        protected void Damage(GameObject enemy)
        {
            Destroy(enemy);
        }
    }
}