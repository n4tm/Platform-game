using UnityEngine;
using UnityEngine.SceneManagement;

namespace Etc
{
    public class End : MonoBehaviour
    {
        public GameObject endGame;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                endGame.SetActive(true);
            }
        }

        public void RestartGame()
        {
            endGame.SetActive(false);
            SceneManager.LoadScene("lvl_1");
        }
    }
}
