using UnityEngine;
using System;

namespace MyDefence
{
    //타워의 원본 프리팹과 가격을 저장하는 클래스
    [Serializable]
    public class TowerBlueprint
    {
        public GameObject towerPrefab;
        public int cost;
    }
}