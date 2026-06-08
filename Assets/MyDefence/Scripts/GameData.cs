using UnityEngine;

namespace MyDefence
{
    public class GameData : MonoBehaviour
    {
        public static int money = 400;

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