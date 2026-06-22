using UnityEngine;

namespace MySample
{
    /// <summary>
    /// Trigger 충돌 체크 예제 클래스
    /// </summary>
    public class TriggerTest : MonoBehaviour
    {
        public float movePower = 3f;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter : {other.tag}");
            MoveObject moveObject = other.GetComponent<MoveObject>();

            if (moveObject != null)
            {
                moveObject.MoveRight(movePower);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay : {other.tag}");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit : {other.tag}");
            MoveObject moveObject = other.GetComponent<MoveObject>();

            if (moveObject != null)
            {
                moveObject.MoveRight(movePower);
            }
        }
    }
}