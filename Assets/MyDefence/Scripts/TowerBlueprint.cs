using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 타워의 속성 데이터를 관리하는 직렬화된 클래스
    /// </summary>
    //타워의 원본 프리팹과 가격을 저장하는 클래스
    [Serializable]
    public class TowerBlueprint
    {
        public GameObject towerPrefab;      //타원 건설에 필요한 프리팹 오브젝트
        public int cost;                    //타워 건설에 필요한 가격
    }
}