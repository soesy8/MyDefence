using UnityEngine;
using MyDefence;

namespace MySample
{
    /// <summary>
    /// 데미지 테스트 예제용 탄환 클래스
    /// </summary>
    public class BulletTest : Bullet
    {
        #region Var
        [SerializeField] private float atkDamage = 50f;
        #endregion

        #region Custom Method
        protected override void Damage(GameObject targetEnemy)
        {
            //Debug.Log($"{targetEnemy.ToString()}에게 {atkDamage} 데미지 주기");
            //Destroy(targetEnemy);

            //데미지 입는 기능이 있는지 체크
            //IDamageable의 인스턴스 가져오기
            IDamageable damageable = targetEnemy.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(atkDamage);
            }

            //데미지 주기
            //Monster의 객체 가져오기
            /*Monster monster = targetEnemy.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(atkDamage);
            }*/

            /*Mob mob = targetEnemy.GetComponent<Mob>();
            if (mob != null)
            {
                mob.TakeDamage(atkDamage);
            }*/
        }
        #endregion
    }
}