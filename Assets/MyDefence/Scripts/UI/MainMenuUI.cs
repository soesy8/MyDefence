using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenuUI : MonoBehaviour
    {
        public void PlayButton()
        {
            Debug.Log("Play");
            SceneManager.LoadScene("PlayScene");
        }

        public void QuitButton()
        {
            Debug.Log("Quit");
        }
    }
}