using UnityEngine;
using TMPro; // 👈 TextMeshPro를 쓰기 위해 반드시 필요합니다!

namespace MyDefence
{
    public class MoneyUI : MonoBehaviour
    {
        // 텍스트 컴포넌트를 담을 상자
        private TextMeshProUGUI moneyText;

        void Start()
        {
            // 이 오브젝트에 붙어있는 TextMeshPro 컴포넌트를 가져옵니다.
            moneyText = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            // 🔎 매 프레임마다 GameData.money의 값을 감시해서 UI에 그려줍니다.
            if (moneyText != null)
            {
                moneyText.text = $"Gold : {GameData.Gold}";
            }
        }
    }
}