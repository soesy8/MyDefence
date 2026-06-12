using UnityEngine;
using System.Collections;

namespace MySample
{
    /// <summary>
    /// 라이트 애니메이션을 1초마다 랜덤하게 플레이 시킨다
    /// </summary>
    public class AnimatorTest : MonoBehaviour
    {
        #region Var
        //애니메이터 컴포넌트의 객체 변수?
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
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            StartCoroutine(FlameRoutine());
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