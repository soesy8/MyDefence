using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타워가 타겟팅한 타겟의 정보를 받아줄 변수
        public GameObject target;

        //총알 속도
        public float bulletSpeed = 70.0f;
        #endregion


        #region Unity Event Method
        void Update()
        {
            //nullcheck
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            //날아갈 방향
            Vector3 dir = (target.transform.position - transform.position).normalized;
            
            //총알 방향 설정
            transform.LookAt(target.transform.position);

            //충돌 판정 연산
            if (CheckPassPosition() == true)
            {
                Debug.Log("명중");
                Destroy(target);        //적 파괴
                Destroy(gameObject);    //탄 파괴
            }

            //이동
            transform.Translate(bulletSpeed * Time.deltaTime * dir, Space.World);

        }

        #endregion


        #region Custom Method
        //이동 시 타겟까지 남은 거리와 이번 프레임에 이동 거리를 비교하여 충돌판정
        public bool CheckPassPosition()
        {
            //Enemy와 Bullet 사이의 거리 연산
            float distance = Vector3.Distance(transform.position, target.transform.position);

            //이번 프레임 이동 거리
            float distanceThisFrame = Time.deltaTime * bulletSpeed;

            if (distance <= distanceThisFrame)
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}