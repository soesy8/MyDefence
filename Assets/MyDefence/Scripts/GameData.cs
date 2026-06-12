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
        #region Variables
        private static int gold;        //소지금
        [SerializeField] private int startGold = 400;     //초기 소지금
        public static Action OnGoldChanged;     //골드 변환 알림

        private static int wave;
        public static Action OnWaveChanged;

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

        //웨이브 속성
        //public static int Wave { get; set; }
        public static int Wave
        {
            get { return wave; }
            set { wave = value; }
        }
        #endregion


        #region Unity Event Method
        void Awake()
        {
            ResetData();
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
        //시작 및 재시작 시 데이터 초기화
        public void ResetData()
        {
            gold = startGold;
            life = startLife;
            maxLife = startLife;

            OnGoldChanged?.Invoke();
            OnLifeChanged?.Invoke();
            OnWaveChanged?.Invoke();
        }
        //웨이브 카운트 증가
        public static void NextWave()
        {
            wave++;
            OnWaveChanged?.Invoke();
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