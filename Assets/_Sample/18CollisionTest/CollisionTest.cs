using UnityEngine;

namespace MySample
{
    /// <summary>
    /// Collision 충돌 체크 예제 클래스
    /// </summary>
    public class CollisionTest : MonoBehaviour
    {
        public float movePower = 3f;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter : {collision.gameObject.tag}");
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();

            if (moveObject != null)
            {
                moveObject.MoveLeft(movePower);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionStay : {collision.gameObject.tag}");
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"OnCollisionExit : {collision.gameObject.tag}");
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();

            if (moveObject != null)
            {
                moveObject.MoveLeft(movePower);
            }
        }

    }
}