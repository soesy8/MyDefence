using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Var
        public GameObject machinegunPrefab;
        public GameObject anotherTowerPrefab;
        #endregion

        #region Custom Method
        //머신건 설치 버튼
        public void MachineGun()
        {
            BuildManager.Instance.SelectTower(machinegunPrefab);
            Debug.Log("Machinegun 을 선택");
        }

        public void AnotherTower()
        {
            BuildManager.Instance.SelectTower(anotherTowerPrefab);
            Debug.Log("RocketLuncher 를 선택");
        }
        #endregion
    }

}