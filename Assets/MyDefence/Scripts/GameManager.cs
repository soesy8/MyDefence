using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Methods
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("showmethemoney");
                ShowMeTheMoney();
            }
        }
        #endregion

        #region Cheating
        void ShowMeTheMoney()
        {
            //치팅 체크
            if (isCheating == false) return;


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