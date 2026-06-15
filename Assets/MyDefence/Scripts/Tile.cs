using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //빌드 매니저 싱글톤 인스턴스
        private BuildManager buildManager;

        public Material hoverTileMaterial;
        private Renderer rendPrefab;
        private Material originMaterial;

        private GameObject towerOnTile;
        public TowerBlueprint towerBlueprint;

        public GameObject tileUI;

        private bool isUpgrade = false;
        #endregion

        public bool IsUpgrade => isUpgrade;

        public GameObject buildEffectPrefab;
        public GameObject sellEffectPrefab;


        #region Unity Event Method
        void Start()
        {
            //참조 - 변수를 private으로 돌리고 컴포넌트를 가져와서 사용
            buildManager = BuildManager.Instance;
            rendPrefab = GetComponent<Renderer>();

            //필드 초기화 - 기존 메테리얼 저장
            if (rendPrefab != null)
            {
                originMaterial = rendPrefab.material;
            }

            isUpgrade = false;
        }

        //타일 위에 마우스가 위치했을 때
        void OnMouseEnter()
        {
            //클릭 투과 현상 방지
            if (EventSystem.current.IsPointerOverGameObject()) { return; }

            if (buildManager.GetSelectedTower() != null)
            {
                if (rendPrefab != null && hoverTileMaterial != null)
                {
                    //Debug.Log("들어옴");
                    rendPrefab.material = hoverTileMaterial;
                }
            }
        }

        //타일 위에서 마우스가 나갔을 때
        void OnMouseExit()
        {
            if (rendPrefab != null && hoverTileMaterial != null)
            {
                //Debug.Log("나감");
                //원래 색상으로 변경
                rendPrefab.material = originMaterial;
            }
        }

        //타일을 클릭했을 때
        void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            // 설치 모드
            if (buildManager.GetSelectedTower() != null)
            {
                BuildTower();
                //BuildEffect();
                return;
            }

            // 선택 모드
            if (towerOnTile != null)
            {
                if (buildManager.SelectedTile == this)
                {
                    buildManager.SelectedTile = null;
                    buildManager.tileUI.Hide();
                    return;
                }

                buildManager.SelectedTile = this;
                buildManager.tileUI.Show(this);
                /*buildManager.SelectedTile = this;
                buildManager.tileUI.Show(this);
                //Debug.Log("타일 선택");*/
            }

            /*//클릭 투과 현상 방지
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (buildManager.GetSelectedTower() == null) return;

            if (GameData.Gold < buildManager.GetSelectedTower().cost)
            {
                Debug.Log($"돈이 부족합니다.");
                buildManager.SetSelectTower(null);
                return;
            }

            BuildTower();*/
        }
        #endregion

        #region Custom Method
        public void BuildTower()
        {
            if (towerOnTile != null) return;

            TowerBlueprint blueprint = buildManager.GetSelectedTower();

            GameObject tower
                    = Instantiate(blueprint.towerPrefab, transform.position + new Vector3(0, 0.05f, 0),
                    Quaternion.identity);
            towerOnTile = tower;
            towerBlueprint = blueprint;

            GameData.UseGold(blueprint.cost);

            buildManager.SetSelectTower(null);
        }

        public void UpgradeTower()
        {
            if (towerBlueprint.upgradeTowerPrefab == null)
                return;

            if (GameData.Gold < towerBlueprint.upgradeCost)
                return;

            isUpgrade = true;
            Destroy(towerOnTile);

            GameObject tower = Instantiate(
                towerBlueprint.upgradeTowerPrefab,
                transform.position + new Vector3(0, 0.05f, 0),
                Quaternion.identity);

            //BuildEffect();

            towerOnTile = tower;

            GameData.UseGold(towerBlueprint.upgradeCost);

            buildManager.SetSelectTower(null);

        }

        public void SellTower()
        {
            GameData.AddGold(towerBlueprint.GetSellCost());
            //SellEffect();
            Destroy(towerOnTile);

            isUpgrade = false;
            towerOnTile = null;
            //Debug.Log("타워 판매 기능");
        }

        public void BuildEffect()
        {
            /*if (buildEffectPrefab != null)
            {
                //GameObject effectGo = Instantiate(this, transform.position, Quaternion.identity);
                //Destroy(effectGO, 2f);
            }*/
        }

        public void SellEffect()
        {
            /*if (sellEffectPrefab != null)
            {
                //GameObject effectGo = Instantiate(this, transform.position, Quaternion.identity);
                //Destroy(effectGO, 2f);
            }*/
        }
        #endregion
    }
}