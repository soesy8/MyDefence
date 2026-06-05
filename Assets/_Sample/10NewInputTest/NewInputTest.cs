using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MySample
{
    public class NewInputTest : MonoBehaviour
    {
        #region Variables
        //New Input System에서 만들어진 크래스의 객체 선언
        private NewActionsTest inputActions;

        //moveSpeed
        public float moveSpeed = 10.0f;

        //화면 바깥 두께 판정
        public float scrnEdge = 20f;

        //화면 크기 값
        private int screenWidth = Screen.width;
        private int screenHeight = Screen.height;

        private bool isCannotMove = false;      //true : 이동 불가, false : 이동 가능
        #endregion



        #region Unity Event Method
        private void Awake()
        {
            //참조
            //New Input System에서 만들어진 클래스의 객체 생성
            inputActions = new NewActionsTest();

        }

        void OnEnable()
        {
            //New Input System에서 만들어진 클래스의 객체 활성화
            inputActions.Enable();

            inputActions.Camera.EscToggle.performed += Toggle;
            //inputActions.Camera.EscToggle.started += Toggle;
            //inputActions.Camera.EscToggle.cancled += Toggle;
        }

        void OnDisable()
        {
            //New Input System에서 만들어진 클래스의 객체 비활성화
            inputActions.Disable();
            inputActions.Camera.EscToggle.performed -= Toggle;
        }

        void Update()
        {
            //isCannotMove true : 이동 불가 , false : 이동 가능
            if (isCannotMove) { return; }       //return 이하 명령문을 실행하지 않는다

            //wasd, arrow 입력 값을 받아와서 카메라 이동
            //값 읽어들이기 : 객체이름.액션맵이름.액션이름.ReadValue<데이터타입>();
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x, inputVector.y

            //이동방향 * Time.deltaTime * Speed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
            //transform.position += moveSpeed * Time.deltaTime * dir;

            /*Vector2 mousePos = inputActions.Camera.MousePosition.ReadValue<Vector2>();
            float mouseX = mousePos.x;
            float mouseY = mousePos.y;
            //마우스 이동 스크립트 명령문 입력
            //...
            if (mouseX < scrnEdge) transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            if (mouseX > screenWidth - scrnEdge) transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            if (mouseY < scrnEdge) transform.position += Vector3.back * Time.deltaTime * moveSpeed;
            if (mouseY > screenHeight - scrnEdge) transform.position += Vector3.forward * Time.deltaTime * moveSpeed;*/



        }
        #endregion



        #region Custom Method
        public void Toggle(InputAction.CallbackContext context)
        {
            //context.started 누르기 시작했을 때
            //context.cancled 눌렀다 뗐을 때
            //context.performed 눌렀을 때 1회 호출

            Debug.Log("Pushed Toggle Key");
            isCannotMove = !isCannotMove;
        }
        #endregion

    }
}

/*
New Input System

1. Input Action Editor 창 세팅하기 ( Action Map 설계 )
- Action Map 설정(정의) - Player, UI, Camera
- Actions 설정(정의, input 값과 바인딩) - Move, Jump

2. 게임 중 유저 인풋 값을 New Input System 가져와서 적용하기
 1) 스크립트를 이용하여 값 가져오기
- Input Action Editor 창에서 설정한 값을 Class 파일로 만들어서 처리
- 만들어진 Class의 객체(인스턴스)를 생성해서 인풋 처리

 2) SendMessage 방법
- PlayerInput 컴포넌트를 대상 오브젝트에 추
가한다
- Actions에 설계한 Actions를 등록한다 (인스펙터 창에 드래그햐여 바인딩)
- Behaviour를 SendMessages로 설정한다
- 스크립트에 유저 인풋 값을 받아오는 함수를 만든다 (규칙에 맞게 만든다)
: 함수이름 : On + 액션이름(InputValue value)


 3) Unity Event 등록 방법
- PlayerInput 컴포넌트를 대상 오브젝트에 추가한다
- Actions에 설계한 Actions를 등록한다 (인스펙터 창에 드래그햐여 바인딩)
- Behaviour를 Invoke Unity Events로 설정한다
- 스크립트에 유저 인풋 값을 받아오는 함수를 만든다 (규칙에 맞게 만든다)
: 함수 이름 규칙이 없음, 매개변수는 규칙이 있다
public void 함수이름(InputAction.CallbackContext context)
- 만든 함수를 Actions에 대응하는 이벤트에 등록한다
...

*/