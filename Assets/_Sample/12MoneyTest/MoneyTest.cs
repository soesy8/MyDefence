using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MySameple
{
    public class MoneyTest : MonoBehaviour
    {
        //var
        private int gold = 3000;

        [SerializeField]
        private TextMeshProUGUI goldText;

        
        [SerializeField]private Image smallPurchaseButtonImage;
        [SerializeField]private Image largePurchaseButtonImage;


        public GameObject buttonColor;
        

        void Start()
        {
            Gold = gold;
        }

        public int Gold
        {
            get { return gold; }
            private set
            {
                gold = value;
                goldText.text = $"Gold : {gold}";

                UpdateButtonColors();
            }
        }

        private void UpdateButtonColors()
        {
            // 1000원 상품 버튼 검사
            if (Gold >= 1000)
                smallPurchaseButtonImage.color = Color.white; // 구매 가능
            else
                smallPurchaseButtonImage.color = Color.red;   // 구매 불가

            // 9000원 상품 버튼 검사
            if (Gold >= 9000)
                largePurchaseButtonImage.color = Color.white; // 구매 가능
            else
                largePurchaseButtonImage.color = Color.red;   // 구매 불가
        }

        //Custom Method
        public void SaveMoney()
        {
            Debug.Log("+1000");
            Gold +=  1000;
            Debug.Log(gold);
        }
        public void SmallPurchase()
        {
            if (Gold < 1000)
            {
                Debug.Log("not enough gold");
                return;
            }
            Debug.Log("-1000");
            Gold -= 1000;
            Debug.Log(gold);
        }
        public void LargePurchase()
        {
            if (Gold < 9000)
            {
                Debug.Log("not enough gold");
                return;
            }
            Debug.Log("-9000");
            Gold -= 9000;
            Debug.Log(gold);
        }
    }
}