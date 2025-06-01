using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if player falls of the map on the fall zone, end game 
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene("MainMenu");
        }
    }
}
