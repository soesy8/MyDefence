using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        private float moveX;

        //좌우키 입력 받았을 때 이동시키는 힘
        [SerializeField] private float movePower = 10f;

        //오브젝트 색깔 바꾸기
        private Material material;
        private Color originColor;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            material = GetComponent<Renderer>().material;
            originColor = material.color;
        }

        private void Update()
        {
            //input
            moveX = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            //인풋 방향으로 주어진 힘으로 이동
            rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);
        }
        #endregion

        public void MoveLeft(float power)
        {
            rb.AddForce(Vector3.left * power, ForceMode.Impulse);
        }

        public void MoveRight(float power)
        {
            rb.AddForce(Vector3.right * power, ForceMode.Impulse);
        }

        public void ChangeMoveColor()
        {
            material.color = Color.red;
        }

        public void ChangeOriginColor()
        {
            material.color = originColor;
        }
    }
}