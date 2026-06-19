using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        //웨이브 카운트 텍스트 UI
        public TextMeshProUGUI wavesText;
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        #region Unity Event Method
        //UI 활성화시 호출
        private void OnEnable()
        {
            //웨이브 카운트 텍스트 데이터 연결
            wavesText.text = GameData.Waves.ToString() + " WAVE SURVIVED";
        }
        #endregion

        #region Custom Method
        //메인메뉴 버튼 클릭시 호출
        public void MainMenu()
        {
            Debug.Log("Goto MainMenu");
            Time.timeScale = 1.0f;
            fader.FadeTo(loadToScene);
        }

        //리스타트 버튼 클릭시 호출
        public void ReStart()
        {
            //Debug.Log("ReStart!!!");
            //현재 플레이하고 있는 씬을 다시 로드한다
            Time.timeScale = 1.0f;
            fader.FadeTo(SceneManager.GetActiveScene().buildIndex);            
        }
        #endregion
    }
}