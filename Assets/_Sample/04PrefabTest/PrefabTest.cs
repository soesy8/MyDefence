using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MySample
{

    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //생성할 프리팹 오브젝트 가져오기
        public GameObject prefabs;

        //타이머 변수 선언 - 2개
        private float countdown = 0f;       //시간(Time.deltaTime) 누적 변수
        public float tileTimer = 1f;       //타이머 기준 시간

        //코루틴 반복 변수
        public int times = 10;      //코루틴 메서드 반복 횟수
        #endregion

        #region Unity Evnet Method
        private void Start()
        {
            // [1] 프리팹 게임 오브젝트의 사본 만들기
            //Instantiate(prefabs);

            // [2] 지정된 위치(5,0.05, 8)에 프리팹 게임 오브젝트의 사본 만들기
            //Instantiate(prefabs, new Vector3(5f, 0.05f, 8f), Quaternion.identity);
            //Vector3 position = new(5f, 0.05f, 8f);
            //Instantiate(prefabs, position, Quaternion.identity);

            // [3] 맵타일 찍기 (가로 10 x 세로 10, 타일 간격 5)
            //GenerateMapTile(10, 10);
            //GenerateMapTile(10, 10, transform);     //부모 지정

            // [4] 10x10 맵타일 중 랜덤한 타일 하나 찍기
            /*for (int i = 0; i < 10; i++)
            {
                GenerateRandomTile();       //랜덤 위치의 타일 생성
            }*/

            // [5] 타이머 초기화
            countdown = tileTimer;

            // [6] 랜덤 위치에 1초마다 타일 1개씩 찍기 - 10개
            //타일 1개 찍고, 1초 딜레이 > 1개 찍고, 1초 딜레이 > ...
            //코루틴 메서드
            Debug.Log("StartCoroutine");
            StartCoroutine(DelayTile());
            Debug.Log("EndCoroutine");
        }

        IEnumerator DelayTile()
        {
            int j = 0;
            while (j < times)
            {
                GenerateRandomTile();
                Debug.Log($"{j+1}번째 타일");
                yield return new WaitForSeconds(1.0f);
                j++;
            }
        }

        private void Update()
        {
            // [5] 랜덤 위치에 1초마다 타일 1개씩 찍기
            //1초 타이머
            /*countdown += Time.deltaTime;
            if (countdown >= tileTimer)
            {
                //타이머 기능 실행 - 타일 찍기
                GenerateRandomTile();

                //타이머 출력
                countdown = 0f;
            }*/

            /*if (countdown <= 0f)
            {
                //타이머 기능 실행 - 타일 찍기
                GenerateRandomTile();

                Debug.Log("1초 경과.");

                //타이머 초기화
                countdown = tileTimer;
            }
            countdown -= Time.deltaTime;*/
        }

        #endregion

        #region Custom Method
        //매개변수로 가로, 세로 타일 갯수를 입력받아 맵타일 찍는 함수
        void GenerateMapTile(int row, int colum)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    //생성하면서 위치 지정
                    float xPos = i * 5f;
                    float zPos = j * -5f;

                    Vector3 tilePos = new(xPos, 0.05f, zPos);
                    Instantiate(prefabs, tilePos, Quaternion.identity);
                }

            }
        }

        //매개변수로 생성되는 맵타일의 부모 오브젝트, 가로, 세로 타일 갯수를 입력받아 맵타일 찍는 함수
        void GenerateMapTile(int row, int colum, Transform parent)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    //생성하면서 위치 지정
                    float xPos = i * 5f;
                    float zPos = j * -5f;

                    Vector3 tilePos = new(xPos, 0.05f, zPos);
                    Instantiate(prefabs, tilePos, Quaternion.identity, parent);

                    //생성 후 위치 지정
                    //GameObject go = Instantiate(prefabs, parent);
                    //go.transform.position = new(xPos, 0.05f, zPos);
                }

            }
        }


        void GenerateRandomTile()
        {
            int randRow = Random.Range(-10, 10);
            int randColum = Random.Range(-10, 10);

            Vector3 position = new(randRow, 0.05f, randColum);
            Instantiate(prefabs, position, Quaternion.identity);
        }
        #endregion


    }

}
/*





*/