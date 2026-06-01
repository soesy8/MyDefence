using UnityEngine;

namespace MySample
{
    /// <summary>
    /// MonoBehaviour를 상속받는 클래스의 싱글톤 패턴
    /// </summary>
    public class SingletonMono : MonoBehaviour
    {
        #region Unity Event Method
        void Start()
        {
            SingletonClass.Instance.number = 10;
            Debug.Log(SingletonClass.Instance.number.ToString());
        }
        #endregion
    }
}