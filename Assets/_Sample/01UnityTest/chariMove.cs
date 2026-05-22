using UnityEngine;

namespace ChiarMove
{
    public class chariMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }
        [SerializeField]                //인스펙터 창에서 수정 가능
        private float moveSpeed = 5f;   //속도를 관리하는 변수

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
