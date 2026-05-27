using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI를 다루기 위해 필요합니다

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy 프리팹
    public Transform spawnPoint;   // 시작지점 위치
    public Transform targetPoint;  // 종점 위치
    public Text countdownText;     // 화면 상단에 띄울 UI Text

    private int waveNumber = 1;    // 현재 웨이브 번호 (1마리, 2마리...)

    void Start()
    {
        // 게임이 시작되면 적을 생성하는 코루틴을 실행합니다
        StartCoroutine(SpawnWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        while (true) // 무한히 반복하여 웨이브 진행
        {
            // [기능 3] 현재 웨이브 수만큼 Enemy 스폰 (1 -> 2 -> 3...)
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f); // 뭉쳐서 나오지 않게 약간의 간격을 둡니다
            }

            waveNumber++; // 다음 웨이브 때는 스폰 수 증가

            // [기능 2 & 4] 6초 타이머 및 UI 카운트다운 구현
            float timer = 6f;
            while (timer > 0)
            {
                countdownText.text = "Next Wave in: " + timer.ToString("F1") + "s";
                yield return null; // 다음 프레임까지 대기
                timer -= Time.deltaTime; // 시간 차감
            }
        }
    }

    void SpawnEnemy()
    {
        // 시작지점에 Enemy 생성
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // 생성된 Enemy에게 목표지점(Target)을 알려줍니다
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.target = targetPoint;
        }
    }
}