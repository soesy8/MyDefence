using UnityEngine;
namespace MySample
{
    /// <summary>
    /// old input test 예제
    /// </summary>
    public class OldInputTest : MonoBehaviour
    {
        #region Variables


        #endregion



        #region Unity Event Method
        private void Start()
        {
            //스크린 크기 값 가져오기
            Debug.Log($"Screen Width : {Screen.width}");
            Debug.Log($"Screen Height : {Screen.height}");

        }


        void Update()
        {
            //키 입력 체크 - w키 입력
            /*if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("w 키 키다운");
            }

            if (Input.GetKeyDown("w"))
            {
                Debug.Log("w 키 누름");
            }

            if (Input.GetKeyUp("w"))
            {
                Debug.Log("w 키 뗌");
            }*/

            //GetButton - InputManager에 정의되어 있는 Buttons(Axes) 의 이름을 가져와서 사용한다
            //버튼의 이름은 문자열로 가져온다
            /*if (Input.GetButton("Jump"))
            {
                Debug.Log("Jump(스페이스바) 중");
            }

            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump(스페이스바) 누름");
            }

            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("Jump(스페이스바) 뗌");
            }*/

            /*//GetAxis - InputManager에 정의되어 있는 Axes(Buttos) 의 이름을 가져와서 사용한다
            //a, left : -1 ~ 0
            //d , right : 0 ~ 1
            float hValue = Input.GetAxis("Horizontal");
            Debug.Log($"Horaizontal GetAxis value : {hValue}");

            //s, down : -1 ~ 0
            //w, up : 0 ~ 1
            float vValue = Input.GetAxis("Vertical");
            Debug.Log($"Vertical GetAxis value : {vValue}");*/

            //스크린상의 마우스 위치 값 가져오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            Debug.Log($"x : {mouseX}, y : {mouseY}");


        }

        #endregion

    }
}