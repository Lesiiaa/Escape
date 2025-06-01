using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private NotebookManager notebookManager;

    private void Start()
    {
        notebookManager = Object.FindFirstObjectByType<NotebookManager>();
    }

    void Update()
    {
        if (notebookManager != null && notebookManager.IsOpen()) return;

        if (Input.GetKeyDown(KeyCode.R))    //open menu (r)
        {
            // find an active scene called MainMenu
            bool menuAlreadyOpen = false;

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == "MainMenu")
                {
                    menuAlreadyOpen = true;
                    break;
                }
            }

            if (!menuAlreadyOpen)
            {
                Time.timeScale = 0f;
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            }
        }
    }
}
