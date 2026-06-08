using UnityEngine;

namespace MyDefence
{
    public class Rocket : Bullet
    {
        [SerializeField]
        private float damageRange = 3.5f;

        public GameObject rocketImpactPrefab;

        protected override void HitTarget()
        {
            if (rocketImpactPrefab)
            {
                GameObject effectGo = Instantiate(rocketImpactPrefab, transform.position, Quaternion.identity);

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
                    Destroy(hit.gameObject);
                }
            }
        }
    }
}