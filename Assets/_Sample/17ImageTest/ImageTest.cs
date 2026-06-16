using UnityEngine;
using UnityEngine.UI;

namespace MySample
{
    /// <summary>
    /// 이미지 필 타입 예제 클래스
    /// 스킬 버튼 쿨타임 구현
    /// </summary>
    public class ImageTest : MonoBehaviour
    {
        public Button skillButton;

        //스킬 쿨 작동
        private bool isCharge = false;

        [SerializeField]
        private float coolTime = 5f;
        private float countdown = 0f;

        private void Update()
        {

            if (isCharge)
            {
                countdown += Time.deltaTime;
                if (countdown >= coolTime)
                {
                    //타이머 기능 작동
                    skillButton.interactable = true;

                    isCharge = false;
                }
                //countdown으로 fillamount 구현
                // 0 ~ 5 : 0 ~ 1
                skillButton.image.fillAmount = countdown / coolTime;
            }

            
        }

        //스킬버튼 클릭
        public void SkillButton()
        {
            Debug.Log("스킬 사용");

            //스킬 기능 구현

            //쿨타임 초기화
            skillButton.interactable = false;
            isCharge = true;
            countdown = 0f;
        }



    }
}