using UnityEngine;

namespace MyDefence
{
    public class Camera : MonoBehaviour
    {
        #region Variables
        //카메라 이동 속도
        public float moveSpeed = 10.0f;

        //화면 크기 값
        private int screenWidth = Screen.width;
        private int screenHeight = Screen.height;

        //화면 바깥 두께
        public float edgeMargin = 20f;
        #endregion

        #region Unity Event Method
        void Update()
        {
            //전후좌우 키 입력받기
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            //마우스 위치 추적
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;


            /*//입력받은 값에 따라 이동방향 계산
            Vector3 dir = new Vector3(h, 0, v);
            //카메라 이동
            transform.position += moveSpeed * Time.deltaTime * dir.normalized;*/


            //마우스 위치 및 키 입력을 통한 카메라 이동
            //왼쪽으로 이동
            if (mouseX < edgeMargin || h < 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.left; }

            //오른쪽으로 이동 / (화면 가로 크기 - 여백)보다 클 때
            if (mouseX > screenWidth - edgeMargin || h > 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.right; }

            //뒤로 이동
            if (mouseY < edgeMargin || v < 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.back; }

            //앞으로 이동 / (화면 세로 크기 - 여백)보다 클 때
            if (mouseY > screenHeight - edgeMargin || v > 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.forward; }

        }
        #endregion
    }
}