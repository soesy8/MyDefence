using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class InfoUI : MonoBehaviour
    {
        // 텍스트 컴포넌트를 담을 상자
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private TextMeshProUGUI lifeText;

        void Start()
        {
            UpdateGoldUI(); // 초기 UI 업데이트
            UpdateLifeUI(); // 초기 UI 업데이트

            GameData.OnGoldChanged += UpdateGoldUI;
            GameData.OnLifeChanged += UpdateLifeUI;

            // 이 오브젝트에 붙어있는 TextMeshPro 컴포넌트를 가져옵니다.
            //moneyText = GetComponent<TextMeshProUGUI>();
            //lifeText = GetComponent<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            GameData.OnGoldChanged -= UpdateGoldUI;
            GameData.OnLifeChanged -= UpdateLifeUI;
        }

        private void UpdateGoldUI()
        {
            moneyText.text = $"Gold : {GameData.Gold}";
        }

        private void UpdateLifeUI()
        {
            lifeText.text = $"Life : {GameData.Life}";
        }

        /*void Update()
        {
            // 🔎 매 프레임마다 GameData.money의 값을 감시해서 UI에 그려줍니다.
            if (moneyText != null)
            {
                moneyText.text = $"Gold : {GameData.Gold}";
                moneyText.text = $"Gold : {GameData.Life}";
            }
        }*/
    }
}