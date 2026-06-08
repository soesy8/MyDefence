using UnityEngine;

namespace MyDefence
{
    public class Rocket : Bullet
    {
        [SerializeField]
        private float damageRange = 3.5f;

        protected override void HitTarget()
        {
            if (ImpactPrefab)
            {
                GameObject effectGo = Instantiate(ImpactPrefab, transform.position, Quaternion.identity);

                Destroy(effectGo, 2.0f);
            }

            Explosion();

            Destroy(gameObject);
        }

        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRange);

            foreach (Collider hit in hitColliders)
            {
                if (hit.CompareTag("Enemy"))
                {
                    Damage(hit.gameObject);
                }
            }
        }
    }
}