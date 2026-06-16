using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임 오브젝트가 항상 카메라를 바라보도록 한다
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {
        //Variables
        //메인 카메라 객체
        private Camera mainCamera;

        //Unity Event Method
        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            //항상 카메라를 바라본다
            //transform.LookAt(mainCamera.transform.position);

            //카메라의 x 포지션을 오브젝트의 x 포지션을 동일하게 한다
            Vector3 targetPosition = new Vector3(transform.position.x,
                mainCamera.transform.position.y, mainCamera.transform.position.z);
            transform.LookAt(targetPosition);

        }


    }
}