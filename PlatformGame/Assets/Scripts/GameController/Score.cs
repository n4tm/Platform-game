using UnityEngine;
using UnityEngine.UI;

namespace GameController
{
    public class Score : MonoBehaviour
    {
        public int totalScore;
        public Text scoreText;
        public static Score instance;

        private void Start()
        {
            instance = this;
            DontDestroyOnLoad(transform.parent.gameObject);
        }

        public void UpdateScoreText()
        {
            scoreText.text = totalScore.ToString();
        }
    }
}
