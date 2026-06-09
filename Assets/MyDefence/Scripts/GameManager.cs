using UnityEngine;

namespace MyDefence
{
    public class GameManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown("m"))
            {
                GameData.AddGold(100000);
            }
        }
    }
}