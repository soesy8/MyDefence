using UnityEngine;
using TMPro;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 웨이브 숫자 텍스트 카운트 애니메이션 연출
    /// </summary>
    public class WavesTextUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI wavesText;

        private Coroutine countCoroutine;

        private void OnEnable()
        {
            if (countCoroutine != null)
            {
                StopCoroutine(countCoroutine);
            }

            countCoroutine = StartCoroutine(CountWaveText());
        }

        private IEnumerator CountWaveText()
        {
            int targetWave = GameData.Waves;

            float duration = 1f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                float percent = elapsedTime / duration;

                int currentWave = Mathf.RoundToInt(
                    Mathf.Lerp(0, targetWave, percent));

                wavesText.text = currentWave.ToString();

                yield return null;
            }

            wavesText.text = targetWave.ToString();
        }
    }
}