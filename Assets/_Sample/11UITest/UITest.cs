using UnityEngine;
using TMPro;

namespace MySample
{
    /// <summary>
    /// UI 샘플 예제 - 버튼 호출 함수 구현
    /// </summary>
    public class UITest : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI ScoreText;
        private int score = 0;

        public int Score
        {
            get { return score; }
            private set
            {
                score = value;
                ScoreText.text = $"SCORE : {score}";
            }
        }

        #region Custom Method
        //Fire 버튼 클릭 시 호출되는 함수 - public void 버튼이름()
        //Fire 버튼에 등록되는 함수
        public void Fire()
        {
            Debug.Log("Fire Botton Pressed");
        }

        public void Jump()
        {
            Debug.Log("Jump Botton Pressed. Score +10.");
            score += 10;
        }
        #endregion

        //#region Unity Event Method
        //#endregion
    }

}