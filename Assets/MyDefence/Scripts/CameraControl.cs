using UnityEngine;

namespace MyDefence
{
    public class CameraControl : MonoBehaviour
    {
        #region Variables
        
        private Camera thisCamera;
        //카메라 이동 속도
        public float moveSpeed = 10.0f;

        //화면 크기 값
        private int screenWidth = Screen.width;
        private int screenHeight = Screen.height;

        //화면 바깥 두께 판정
        public float scrnEdge = 20f;

        //줌인 속도
        public float zoomSpeed = 10.0f;

        //카메라 이동 제어 변수 - 토글키 변수
        private bool isCannotMove = false;      //true : 이동 불가, false : 이동 가능
        #endregion

        #region Unity Event Method
        void Start()
        {
            //카메라 컴포넌트 가져오기
            thisCamera = GetComponent<Camera>();
        }

        void Update()
        {
            //카메라 이동 기능 막기 - esc
            //토글버튼 누르면 카메라 이동을 막는다 : isCannotMove:false > isCannotMove:true
            //토글버튼 다시 누르면 카메라가 이동한다 : isCannotMove:true > isCannotMove:false
            if (Input.GetButtonDown("Esc Toggle"))
            {
                //Debug.Log("Esc Toggle Key Down");
                //isCannotMove = (isCannotMove == true) ? false : true;
                isCannotMove = !isCannotMove;
            }

            //isCannotMove true : 이동 불가 , false : 이동 가능
            if (isCannotMove) { return; }       //return 이하 명령문을 실행하지 않는다

            //이동 값 초기화
            Vector3 moveDirection = Vector3.zero;

            //키보드 방향 입력
            moveDirection.x += Input.GetAxisRaw("Horizontal");
            moveDirection.z += Input.GetAxisRaw("Vertical");

            //마우스 위치 값
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            //마우스가 화면 안에 위치했을 때만 작동
            bool isMouseInScreen = mouseX >= 0 && mouseX <= screenWidth && mouseY >= 0 && mouseY <= screenHeight;

            /*if (isMouseInScreen)
            {
                if (mouseX < scrnEdge) moveDirection.x -= 1f;
                if (mouseX > screenWidth - scrnEdge) moveDirection.x += 1f;
                if (mouseY < scrnEdge) moveDirection.z -= 1f;
                if (mouseY > screenHeight - scrnEdge) moveDirection.z += 1f;
            }*/

            // 3. 최종 이동 (대각선 속도 보정 포함)
            transform.position += moveSpeed * Time.deltaTime * moveDirection.normalized;

            //마우스가 화면 안에 위치했을 때만 작동
            if (isMouseInScreen)
            {
                //스크롤 값을 입력받아 줌 기능 구현
                float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                thisCamera.fieldOfView -= scroll;
            }
            
            //Mathf.Clamp(값, 최소치, 최대치)를 사용해 20~60 사이로 고정
            thisCamera.fieldOfView = Mathf.Clamp(thisCamera.fieldOfView, 20.0f, 60.0f);

            
        }
    }
        #endregion

        #region 폐기
        /*//전후좌우 키 입력받기
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            //마우스 위치 추적
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;


            //입력받은 값에 따라 이동방향 계산
            Vector3 dir = new Vector3(h, 0, v);
            //카메라 이동
            transform.position += moveSpeed * Time.deltaTime * dir.normalized;


            //마우스 위치 및 키 입력을 통한 카메라 이동
            //왼쪽으로 이동
            if (mouseX < edgeMargin || h < 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.left.normalized; }

            //오른쪽으로 이동 / (화면 가로 크기 - 여백)보다 클 때
            if (mouseX > screenWidth - edgeMargin || h > 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.right.normalized; }

            //뒤로 이동
            if (mouseY < edgeMargin || v < 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.back.normalized; }

            //앞으로 이동 / (화면 세로 크기 - 여백)보다 클 때
            if (mouseY > screenHeight - edgeMargin || v > 0)
            { transform.position += moveSpeed * Time.deltaTime * Vector3.forward.normalized; }*/

        /*//스크롤 기능 구현
            float scroll = Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;

            //줌인 최대치
            if (thisCamera.fieldOfView <= 20.0f && scroll < 0)
            {
                thisCamera.fieldOfView = 20.0f;
            }
            //줌아웃 최대치
            else if (thisCamera.fieldOfView >= 60.0f && scroll > 0)
            {
                thisCamera.fieldOfView = 60.0f;
            }
            //줌 인/아웃 기능
            else
            {
                thisCamera.fieldOfView += scroll;
            }*/
        #endregion
}