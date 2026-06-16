using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 지정된 시간마다 이펙트를 재생시키는 클래스
    /// </summary>
    public class IntervalParticlePlay : MonoBehaviour
    {
        //플레이 할 파티클 이펙트 인스턴스(객체)
        public ParticleSystem particleEffect;
        
        //인터벌 타임
        [SerializeField] private float plyaTimer = 5f;
        //시작 딜레이
        [SerializeField]
        private float delayTime = 0f;

        private void Start()
        {
            InvokeRepeating("PlayParticleSystem", delayTime, plyaTimer);
        }

        
        void PlayParticleSystem()
        {
            if (particleEffect == null) return;

            particleEffect.Play();
        }







        /* [SerializeField] private GameObject effectPrefab;
         [SerializeField] private float interval = 5f;
         [SerializeField] private GameObject playPoint;

         // Start is called once before the first execution of Update after the MonoBehaviour is created
         void Start()
         {
             InvokeRepeating(nameof(PlayEffect), interval, interval);
         }

         private void PlayEffect()
         {
             GameObject effectGo = Instantiate(effectPrefab, playPoint.transform.position, playPoint.transform.rotation);
             Destroy(effectGo, 1f);
         }*/
    }
}