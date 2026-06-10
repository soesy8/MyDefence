using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        protected GameObject _target;

        [SerializeField]
        protected float bulletSpeed = 70.0f;

        [SerializeField]
        protected GameObject ImpactPrefab;

        [SerializeField]
        protected int atk = 50;
        #endregion

        #region Property
        public GameObject Target
        {
            get { return _target; }
            set { _target = value; }
        }
        #endregion

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
            if (ImpactPrefab)
            {
                GameObject effectGo = Instantiate(ImpactPrefab, transform.position, Quaternion.identity);

                Destroy(effectGo, 2.0f);
            }

            Damage(Target);
            Destroy(gameObject);
        }

        protected virtual void Damage(GameObject enemy)
        {
            Enemy targetEnemy = enemy.GetComponent<Enemy>();

            if (targetEnemy == null) { return; }

            targetEnemy.TakeDamage(atk);
        }
    }
}