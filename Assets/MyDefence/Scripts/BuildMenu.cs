using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Var
        public GameObject machinegunPrefab;
        public GameObject rocketLauncherPrefab;
        #endregion

        #region Custom Method
        //머신건 설치 버튼
        public void MachineGun()
        {
            BuildManager.Instance.SelectTower(machinegunPrefab);
            Debug.Log("Machinegun 을 선택");
        }

        public void RocketLauncher()
        {
            BuildManager.Instance.SelectTower(rocketLauncherPrefab);
            Debug.Log("RocketLauncher 를 선택");
        }
        #endregion
    }

}