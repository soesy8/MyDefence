using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        //BuildManager 싱글톤 인스턴스
        private BuildManager buildManager;
        #endregion

        #region Unity Event Method
        void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
        }
        #endregion

        #region Custom Method
        //머신건 타워 버튼 클릭 시 호출 - public void Selected버튼이름(), Click버튼이름() 등
        public void SelectedMachineGun()
        {
            buildManager.SetSelectTower(buildManager.machineGunPrefab);
            Debug.Log("Machinegun 선택");
        }
        public void ClickRocketLauncher()
        {
            buildManager.SetSelectTower(buildManager.rocketLauncherPrefab);
            Debug.Log("RocketLauncher 선택");
        }

        //레이저 타워 추가 예정
        public void ClickLaserTower()
        {
            buildManager.SetSelectTower(buildManager.laserTowerPrefab);
            Debug.Log("LaserTower 선택");
        }
        #endregion


        /* #region Var
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
         #endregion*/
    }

}