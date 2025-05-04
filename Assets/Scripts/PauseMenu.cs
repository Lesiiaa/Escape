using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private NotebookManager notebookManager;

    private void Start()
    {
        notebookManager = FindObjectOfType<NotebookManager>();
    }

    void Update()
    {
        if (notebookManager != null && notebookManager.IsOpen()) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }
    }
}
