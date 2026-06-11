using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 게임 데이터 변수를 관리하는 클래스
    /// 게임머니, 목숨
    /// </summary>
    public class GameData : MonoBehaviour
    {
        //초기 소지 재화
        //public static int money = 400;

        #region Variables
        private static int gold;        //소지금
        [SerializeField] private int startGold = 400;     //초기 소지금
        public static Action OnGoldChanged;     //골드 변환 알림

        private static int life;        //목숨
        [SerializeField] private int startLife = 10;      //초기 목숨
        private static int maxLife;
        public static Action OnLifeChanged;     //목숨 변환 알림
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Gold => gold;

        //목숨 읽기 전용 속성
        public static int Life => life;
        #endregion

        #region Unity Event Method
        void Awake()
        {
            //초기화
            if (gold == 0)
            {
                gold = startGold;       //초기 소지금 지급
            }

            if (life == 0)
            {
                life = startLife;       //초기 목숨
                maxLife = startLife;    //최대 목숨
            }

            //초기값 자동 갱신
            OnGoldChanged?.Invoke();
            OnLifeChanged?.Invoke();
            //Debug.Log($"Start Gold : Get {gold}gold.");
        }
        #endregion

        #region Custom Method
        //골드 추가
        public static void AddGold(int amount)
        {
            gold += amount;
            OnGoldChanged?.Invoke();    //골드 변환 알림
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
            OnGoldChanged?.Invoke();    //골드 변환 알림
            return true;
        }

        //소지금 체크, 결재 가능 여부 bool형 반환
        public static bool HasGold(int amount)
        {
            return gold >= amount;
        }

        //목숨 추가
        public static void AddLife(int amount)
        {
            life += amount;
            //maxLife 체크
            if (life >= maxLife)
            {
                life = maxLife;
            }
            OnLifeChanged?.Invoke();    //목숨 변환 알림
        }


        //목숨 감소, 목숨이 0이하가 되면 게임 오버
        public static void LoseLife(int amount = 1)
        {
            life -= amount;
            OnLifeChanged?.Invoke();    //목숨 변환 알림
            if (life <= 0)
            {
                Debug.Log("Game Over");
                //게임 오버 처리
            }
        }

        #endregion
        /*public static GameData Instance { get; private set; }

        public int money = 400;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }*/
    }
}