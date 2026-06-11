using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 목숨 텍스트 출력
    /// </summary>
    public class DrawLifeUI : MonoBehaviour
    {
        //목숨 텍스트 UI
        public TextMeshProUGUI lifeText;

        void Update()
        {
            lifeText.text = GameData.Life.ToString();
        }
    }
}