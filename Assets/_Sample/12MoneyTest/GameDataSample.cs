using UnityEngine;

namespace MySample
{
    public class GameDataSample : MonoBehaviour
    {
        #region Variables
        private static int gold;        //소지금

        public int startGold = 1000;     //초기 소지금
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Gold
        {
            get { return gold; }
        }
        #endregion

        #region Unity Event Method
        void Start()
        {
            //초기화
            gold = startGold;       //초기 소지금 지급

            Debug.Log($"Start Gold : Get {gold}gold.");
        }
        #endregion

        #region Custom Method
        //골드 추가
        public static void AddGold(int amount)
        {
            gold += amount;
        }

        //골드 사용, 사용 여부를 bool 반환
        public static bool UseGold(int amount)
        {
            //소지금 체크
            if (gold < amount)
            {
                Debug.Log("Not Enough Money");
                return false;
            }
            gold -= amount;
            return true;
        }

        //소지금 체크, 결재 가능 여부 bool형 반환
        public static bool HasGold(int amount)
        {
            return gold >= amount;
        }

        #endregion
    }
}