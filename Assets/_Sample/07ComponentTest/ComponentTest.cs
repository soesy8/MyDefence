using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 컴포넌트 객체(인스턴스) 가져오기 연습
    /// </summary>
    public class ComponentTest : MonoBehaviour
    {
        #region Variables
        //게임 오브젝트(또는 트랜스폼)의 인스턴스 가져오는 방법
        public GameObject targetGameObject;
        public Transform targetTransform;
        // [3] public으로 개체(TargetTest 인스턴스) 변수 선언하고 인스펙터 창에서 드래그로 가져온다
        public TargetTest cTest;
        #endregion
        #region Unity Event Method
        void Start()
        {
            // [1] 게임 오브젝트(또는 트랜스폼)의 인스턴스 가져오기
            //gameObject : ComponentTest 스크립트가 붙어있는 게임 오브젝트의 객체(인스턴스)
            //transform : ComponentTest 스크립트가 붙어있는 트랜스폼의 객체(인스턴스)

            // [1-1]
            //ComponentTest 스크립트와 같은 오브젝트에 함께 부착되어 있는 TargetTest 클래스의 인스턴스 접근
            //TargetTest aTest = gameObject.GetComponent<TargetTest>();
            //TargetTest bTest = gameObject.GetComponent<TargetTest>();
            TargetTest eTest = this.GetComponent<TargetTest>(); //같은 오브젝트에 함께 부작되어 있는 컴포넌트 인스턴스 접근
            //TargetTest eTest = GetComponent<TargetTest>();

            //TargetTest 클래스의 인스턴스 가져오기
            //MonoBehaviour를 상속받은 클래스는 new를 통해 인스턴스 생성하지 않는다
            /*TargetTest cTest = new TargetTest();
            Debug.Log(cTest.a);*/

            //TargetTest 스크립트가 붙어있는 게임 오브젝트의 인스턴스를 가져와서 접근한다
            /*TargetTest gTest = targetGameObject.GetComponent<TargetTest>();
            Debug.Log(gTest.a);
            gTest.SetB(50);
            Debug.Log(gTest.GetB());*/

            //TargetTest 스크립트가 붙어있는 트랜스폼의인스턴스를 가져와서 접근한다
            /*TargetTest tTest = targetTransform.GetComponent<TargetTest>();
            Debug.Log(tTest.a);
            gTest.SetB(70);
            Debug.Log(tTest.GetB());*/

            //TargetTest 스크립트가 붙어있는 게임 오브젝트에서 직접 TargetTest 클래스의 인스턴스 접근
            /*Debug.Log(cTest.a);
            gTest.SetB(110);
            Debug.Log(cTest.GetB());*/

            //TargetTest 스크립트가 붙어있는 게임 오브젝트(트랜스폼)의 인스턴스
            //cTest.gameObject
            //cTest.transform
            //cTest.gameObject.GetComponent<컴포넌트이름>()
            //cTest.transform.GetComponent<컴포넌트이름>()
        }

        #endregion

    }
}


/*
게임 오브젝트(또는 트랜스폼)의 인스턴스 가져오는 방법
[1] 게임 오브젝트에 스크립트를 부착하여 부착한 스크립트에서 this.gameObject, this.transform으로 접근
[2] public으로 개체 변수를 선언하고 인스펙터 창에서 가져온다

컴포넌트(MonoBehaviour를 상속받은 클래스)의 인스턴스를 가져오는 방법
[1] 게임 오브젝트(또는 트랜스폼)의 인스턴스를 가져와서 인스턴스이름.GetComponent<컴포넌트이름>();
[2] public으로 개체(TargetTest 인스턴스) 변수 선언하고 인스펙터 창에서 드래그로 가져온다
*/