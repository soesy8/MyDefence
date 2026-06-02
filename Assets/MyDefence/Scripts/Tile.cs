using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //변환할 메테리얼
        public Material hoverTileMaterial;
        
        //타일 오브젝트의 렌더러 컴포넌트 인스턴스
        private Renderer rendPrefab;

        //기존 메테리얼
        private Material originMaterial;

        /*//생성할 타워 프리팹
        [SerializeField]
        private GameObject _towerPrefab;*/

        //타일에 설치된 타워를 저장할 변수
        private GameObject towerOnTile;
        #endregion



        #region Unity Event Method
        void Start()
        {
            //참조 - 변수를 private으로 돌리고 컴포넌트를 가져와서 사용
            rendPrefab = GetComponent<Renderer>();

            //필드 초기화 - 기존 메테리얼 저장
            if (rendPrefab != null)
            {
                originMaterial = rendPrefab.material;
            }
        }

        //타일 위에 마우스가 위치했을 때
        void OnMouseEnter()
        {
            if (rendPrefab != null && hoverTileMaterial != null)
            {
                //Debug.Log("들어옴");
                rendPrefab.material = hoverTileMaterial;
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
            //Debug.Log("클릭");
            //타워 생성 - 타워 프리팹이 할당되어 있는지 확인 및 중복 확인
            if (BuildManager.Instance.GetSelectedTower() != null && towerOnTile == null)
            {
                //타워 생성
                GameObject tower
                = Instantiate(BuildManager.Instance.GetSelectedTower(), transform.position + new Vector3(0,0.05f,0) ,
                Quaternion.identity);
                towerOnTile = tower;
            }


        }
        #endregion



        #region Custom Method
        
        #endregion
    }
}