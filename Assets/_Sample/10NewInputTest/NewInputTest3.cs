using UnityEngine;
using UnityEngine.InputSystem;

namespace MySample
{
    /// <summary>
    /// 게임 중 유저 인풋 값을 New Input System 가져와서 적용하기
    /// 2) Unity Event 방법
    /// </summary>
    public class NewInputTest3 : MonoBehaviour
    {
        #region Var
        //New Input System에서 만들어진 크래스의 객체 선언
        private NewActionsTest inputActions;

        //moveSpeed
        public float moveSpeed = 10.0f;
        private Vector2 inputVector = Vector2.zero;

        //화면 바깥 두께 판정
        public float scrnEdge = 20f;

        //화면 크기 값
        private int screenWidth = Screen.width;
        private int screenHeight = Screen.height;

        private Vector2 mousePos;

        private bool isCannotMove = false;      //true : 이동 불가, false : 이동 가능
        #endregion



        #region Unity Event Method
        private void Update()
        {
            if (isCannotMove) { return; }       //return 이하 명령문을 실행하지 않는다

            //wasd, arrow 입력값을 받아와서 카메라 이동
            //이동방향 * Time.deltaTime * Speed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
            //transform.position += moveSpeed * Time.deltaTime * dir;

            float mouseX = mousePos.x;
            float mouseY = mousePos.y;
            //마우스 이동 스크립트 명령문 입력
            //...
            if (mouseX < scrnEdge) transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            if (mouseX > screenWidth - scrnEdge) transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            if (mouseY < scrnEdge) transform.position += Vector3.back * Time.deltaTime * moveSpeed;
            if (mouseY > screenHeight - scrnEdge) transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

        }
        #endregion

        #region Custom Method
        //전후좌우 wasd, arrow 입력 처리
        public void OnMove(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        //마우스 위치 입력처리
        public void OnMousePosition(InputAction.CallbackContext context)
        {
            mousePos = context.ReadValue<Vector2>();
        }

        //토글 버튼 입력 처리
        public void OnEscToggle(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("toggle on/off");
                isCannotMove = !isCannotMove;
            }
        }
        #endregion
    }
}