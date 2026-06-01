using UnityEngine;
using System.Collections;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables
        // [이전 단계 기억나시죠?] 색상 변경을 위한 변수들을 여기에 선언해 둡니다.
        public Material selectTileMaterial;
        public Renderer rend;
        private Color originalColor;
        #endregion


        #region Unity Event Method
        void Start()
        {
            // 시작할 때 원래 색상을 안전하게 기억해 둡니다.
            if (rend != null)
            {
                originalColor = rend.material.color;
            }
        }

        // 💡 유니티가 감지할 수 있도록 public을 붙이고 Unity Event Method 구역으로 이동합니다!
        public void OnMouseEnter()
        {
            Debug.Log("들어옴");
            if (rend != null && selectTileMaterial != null)
            {
                rend.material.color = selectTileMaterial.color;
            }
        }

        public void OnMouseExit()
        {
            Debug.Log("나감");
            if (rend != null)
            {
                // 💡 마우스가 나갔을 때 원래 색상으로 돌려놓는 코드를 여기에 작성합니다.
                rend.material.color = originalColor;
            }
        }
        #endregion


        #region Custom Method
        // (기존에 있던 마우스 함수는 위로 옮겼으니 여기서는 비워두거나 삭제하시면 됩니다!)
        #endregion
    }
}