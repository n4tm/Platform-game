using UnityEngine;

namespace GameController
{
    public class Score : MonoBehaviour
    {
        public int totalScore;
        public static Score instance;

        private void Start()
        {
            instance = this;
        }
    }
}
