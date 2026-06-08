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
            buildManager = BuildManager.Instance;
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
            //클릭 투과 현상 방지
            if (EventSystem.current.IsPointerOverGameObject()) { return; }

            //타워 생성 - 타워 프리팹이 할당되어 있는지 확인
            if (buildManager.GetSelectedTower() != null)
            {
                //Debug.Log("클릭");
                //중복 확인
                if (towerOnTile == null)
                {
                    //타워 생성
                    GameObject tower
                    = Instantiate(buildManager.GetSelectedTower(), transform.position + new Vector3(0, 0.05f, 0),
                    Quaternion.identity);
                    towerOnTile = tower;
                    //Debug.Log($"{BuildManager.Instance.GetSelectedTower().name}를 생성");

                    //타워를 설치 후 다시 선택한 타워를 null로 변경
                    buildManager.SetSelectTower(null);
                }
            }
            //else { Debug.Log("타워를 설치하지 못했습니다."); }
        }
        #endregion
    }
}