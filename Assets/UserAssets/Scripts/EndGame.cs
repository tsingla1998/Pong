using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace EndGameNamespace
{
    public class EndGame : MonoBehaviour
    {
        public TextMeshProUGUI textObject;
        public static string textString;

        void Start()
        {
            textObject.text = textString;
        }
        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Move back to main scene
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
