using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임 오버 관련 변수
        private bool isGameOver = false;   //게임 오버 체크
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private TextMeshProUGUI waveText;

        //일시정지 관련 변수
        [SerializeField] private GameObject pauseUI;
        private bool isPaused = false;

        [SerializeField] private GameData gameData;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Methods
        void Start()
        {
            isGameOver = false;
        }
        void Update()
        {
            if (isGameOver) return;

            //게임 오버 체크
            if (GameData.Life <= 0)
            {
                GameOver();
            }

            //일시정지
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }



            //치트키
            //골드 치트키
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Money Cheat");
                MoneyCheat();
            }
            //게임오버 치트키
            if (Input.GetKeyDown(KeyCode.O))
            {
                GameOver();
            }
        }
        #endregion


        #region Custom Method
        //일시정지 - 게임 재시작 버튼
        public void ContinueGame()
        {
            ResumeGame();
            Debug.Log("Continue");
        }
        //일시정지, 게임오버 - 메인 메뉴 버튼
        public void GoToMainMenu()
        {
            ResumeGame();
            gameOverUI.SetActive(false);
            Debug.Log("Goto Main");
        }
        //게임오버 - 다시하기 버튼
        public void ReStartGame()
        {
            ResumeGame();
            gameData.ResetData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //ESC - Pause메뉴창 띄우기
        private void TogglePause()
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
        //게임 일시 정지
        private void PauseGame()
        {
            isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        //게임 일시 정지 해제
        private void ResumeGame()
        {
            isPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
        //게임 오버
        void GameOver()
        {
            //게임 오버 처리
            Debug.Log("Game Over!");
            isGameOver = true;

            waveText.text = $"{GameData.Wave} Waves Survied";

            //페널티
            //게임오버 UI 보여주기
            gameOverUI.SetActive(true);

            Time.timeScale = 0f;
        }
        #endregion


        #region Cheating
        void MoneyCheat()
        {
            //10만 골드 지급
            GameData.AddGold(100000);
            Debug.Log($"+ 100,000 Gold");
        }

        

        //레벨치팅
        void LevelCheat()
        {
            //치팅 체크
            if (isCheating == false) return;

            //level++;
        }
        #endregion
    }
}