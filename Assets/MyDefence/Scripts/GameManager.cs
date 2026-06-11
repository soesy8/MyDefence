using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private bool isGameOver = false;   //게임 오버 체크



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

        #region Cheating
        void MoneyCheat()
        {
            //10만 골드 지급
            GameData.AddGold(100000);
            Debug.Log($"+ 100,000 Gold");
        }

        void GameOver()
        {
            //게임 오버 처리
            Debug.Log("Game Over!");
            isGameOver = true;

            //페널티
            //게임오버 UI 보여주기
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