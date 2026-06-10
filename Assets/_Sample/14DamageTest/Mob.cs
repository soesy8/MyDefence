using UnityEngine;

namespace MySample
{
/// <summary>
/// 데미지 주기 예제 클래스
/// </summary>
    public class Mob : MonoBehaviour, IDamageable
    {
        #region Var
        [SerializeField]                //인스펙터 창에서 표시하여 디버깅 하기 위해
        private float hp;         //체력, 현재 체력

        [SerializeField]                //인스펙터 창에서 표시하여 디버깅 하기 위해
        private float maxHp = 100;      //체력 초기값, 최대 체력

        #endregion

        #region Unity Event Method
        void Start()
        {
            //초기화
            hp = maxHp;
        }
        #endregion

        #region Custom Method
        //데미지 받기
        public void TakeDamage(float damage)
        {
            hp -= damage;
            Debug.Log("현재체력 : {hp}");

            if (hp <= 0)
            {
                //킬
                Destroy(gameObject);
            }
        }
        #endregion
    }
}