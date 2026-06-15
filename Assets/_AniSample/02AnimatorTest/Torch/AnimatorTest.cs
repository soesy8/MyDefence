using UnityEngine;
using System.Collections;

namespace MySample
{
    /// <summary>
    /// 라이트 애니메이션을 1초마다 랜덤하게 플레이 시킨다
    /// Animator의 매개변수 LightMode 값을 랜덤하게 세팅
    /// </summary>
    public class AnimatorTest : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        //라이트모드 매개변수
        private int lightMode = 0;
        //타이머
        //private float timer;

        [SerializeField] private float changeInterval = 1f;
        #endregion


        #region Unity Event Method
        private void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            StartCoroutine(FlameRoutine());
            //InvokeRepeating("RandomFlameAnimation", 0f, 1f);
        }
        #endregion


        #region Custom Method
        private IEnumerator FlameRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(changeInterval);

                ChangeLightMode();
            }
        }

        private void ChangeLightMode()
        {
            int nextMode;

            do
            {
                nextMode = Random.Range(0, 3);
            }

            while (nextMode == lightMode);

            lightMode = nextMode;

            animator.SetInteger("LightMode", lightMode);
            /*if (lightMode == 0)
            {
                lightMode++;
            }
            else if (lightMode == 2)
            {
                lightMode--;
            }
            else
            {
                lightMode += Random.value > 0.5f ? 1 : -1;
            }

            animator.SetInteger("LightMode", lightMode);*/
        }
        #endregion
    }
}