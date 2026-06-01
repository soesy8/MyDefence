using UnityEngine;
using System.Collections;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        //변환할 메테리얼 변수 선언
        public Material selectTileMaterial;
        public Renderer rendPrefab;

        //원래 색상 변수 선언
        private Color originalColor;

        //타워 프리팹 변수 선언
        [SerializeField]
        private GameObject _towerPrefab;

        //타일에 설치된 타워를 저장할 변수
        private GameObject towerOnTile;
        #endregion


        #region Unity Event Method
        void Start()
        {
            //시작 시 기존 메테리얼 저장
            if (rendPrefab != null)
            {
                originalColor = rendPrefab.material.color;
            }
        }

        //타일 위에 마우스가 위치했을 때
        void OnMouseEnter()
        {
            if (rendPrefab != null && selectTileMaterial != null)
            {
                //Debug.Log("들어옴");
                rendPrefab.material.color = selectTileMaterial.color;
            }
        }

        //타일 위에서 마우스가 나갔을 때
        void OnMouseExit()
        {
            if (rendPrefab != null && selectTileMaterial != null)
            {
                //Debug.Log("나감");
                //원래 색상으로 변경
                rendPrefab.material.color = originalColor;
            }
        }

        //타일을 클릭했을 때
        void OnMouseDown()
        {
            //Debug.Log("클릭");
            //타워 생성 - 타워 프리팹이 할당되어 있는지 확인 및 중복 확인
            if (TowerPrefab != null && towerOnTile == null)
            {
                //타워 생성
                GameObject tower
                = Instantiate(TowerPrefab, transform.position + new Vector3(0,0.05f,0) ,
                Quaternion.identity);
                towerOnTile = tower;
            }


        }
        #endregion


        #region Custom Method
        public GameObject TowerPrefab
         {
             get { return _towerPrefab; }
             set { _towerPrefab = value; }
         }
        #endregion
    }
}