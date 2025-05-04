using UnityEngine;

public class EscapeMenuController : MonoBehaviour
{
    public GameObject menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = menuUI.activeSelf;
            menuUI.SetActive(!isActive);
            Time.timeScale = isActive ? 1f : 0f;
        }
    }
}
