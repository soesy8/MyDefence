using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타원 건설을 관리하는 싱글톤 클래스
    /// 구조 자체는 공식임
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Variables
        //선택한 타워 게임 오브젝트 - 타일에 설치할 프리팹 오브젝트
        //private GameObject selectedTower;

        //serializable 클래스 사용
        public TowerBlueprint machineGunPrefab;
        public TowerBlueprint rocketLauncherPrefab;

        //선택한 타워 프리팹 오브젝트를 저장할 변수
        private TowerBlueprint selectedTowerBlueprint;

        //타워 프리펩
        //public GameObject towerPrefab;
        #endregion

        #region Custom Method
        //선택한 타워 프리팹 오브젝트 반환
        public TowerBlueprint GetSelectedTower()
        {
            return selectedTowerBlueprint;
        }

        //외부에서 호출하여 타워를 선택해줄 메서드
        public void SetSelectTower(TowerBlueprint blueprint)
        {
            selectedTowerBlueprint = blueprint;
            //Debug.Log("머신건 타워를 선택 하였습니다!!");
        }
        #endregion




        /*#region Unity Event Method
        *//*private void Start()
        {
            //머신건 프리팹 선택
            selectedTower = towerPrefab;
        }*//*
        #endregion*/
    }
}