using MySample;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MySameple
{
    public class MoneyTest : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI goldText;

        //구매 버튼 인스턴스
        public Button button1000;
        public Button button9000;

        //public GameObject buttonColor;
        
        // Unity Event Method
        void Update()
        {
            //버튼 상태에 따라 색 변환
            if (GameDataSample.HasGold(1000))
            {
                button1000.image.color = Color.white;
            }
            else
            {
                button1000.image.color = Color.red;
            }

            if (GameDataSample.HasGold(9000))
            {
                button9000.interactable = true;
            }
            else
            {
                button9000.interactable = false;
            }

            //소지금 텍스트 UI
            goldText.text = $"{GameDataSample.Gold} Gold";
        }

        #region Custom Method
        public void Save1000()
        {
            GameDataSample.AddGold(1000);
            Debug.Log("+ 1000 Gold");
        }
        public void Purchase1000()
        {
            if (GameDataSample.UseGold(1000))
            {
                Debug.Log("- 1000 Gold");
            }
        }

        public void Purchase9000()
        {
            if (GameDataSample.UseGold(9000))
            {
                Debug.Log("- 9000 Gold");
            }
        }
        #endregion
    }
}