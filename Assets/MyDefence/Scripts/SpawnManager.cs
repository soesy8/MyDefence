using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI를 다루기 위해 필요합니다
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Enemy 프리팹
    public Transform spawnPoint;    // 시작지점 위치
    public Transform targetPoint;   // 종점 위치
    public Text countdownText;      // 화면 상단에 띄울 UI Text
    public Text nextWaveText;       // 화면 상단에 띄울 UI Text

    //public TextMeshProUGUI nextWaveText;     // 화면 상단에 띄울 UI Text

    private int waveNumber = 0;     // 현재 웨이브 번호 (1마리, 2마리...)

    void Start()
    {
        // 게임이 시작되면 적을 생성하는 코루틴을 실행합니다
        StartCoroutine(SpawnWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        while (true) // 무한히 반복하여 웨이브 진행
        {
            // 다음 웨이브 때는 스폰 수 증가
            waveNumber++;

            // 화면 상단의 n번째 웨이브 표시
            nextWaveText.text = $"Wave : {waveNumber}";
            //nextWaveText.text = string.Format("{0:00.00}", waveNumber); //실수(소수점) 이하 출력
            

            // [기능 3] 현재 웨이브 수만큼 Enemy 스폰 (1 -> 2 -> 3...)
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy();
                // 뭉쳐서 나오지 않게 약간의 간격을 둡니다
                yield return new WaitForSeconds(0.5f);
            }

            // [기능 2 & 4] 5초 타이머 및 UI 카운트다운 구현
            float timer = 5f;
            while (timer > 0)
            {
                countdownText.text = $"남은 시간 : {timer:F2}s";
                //countdownText.text = string.Format("{0:00.00}", timer); //실수(소수점) 이하 출력
                //countdownText.text = Mathf.Round(countdown).ToStringj();  //정수(반올림하여)출력
                yield return null; // 다음 프레임까지 대기
                timer -= Time.deltaTime; // 시간 차감
            }
        }
    }

    void SpawnEnemy()
    {
        #region 지금은 필요없는 기능
        //만약에 필드에 남은 enemy의 수나 게임 오버를 체크할 때 쓸 수는 있지만
        //현재는 굳이 필요가 없는 기능
        //어차피 인게임에서는 안보이는 부분이기 때문에
        //GameObject spawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        //GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawner.transform);
        #endregion
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