using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour
{
    public GameObject notebookUI;
    public TMP_InputField inputField;
    public Button closeButton;
    public MonoBehaviour[] scriptsToDisable;
    public ScrollRect scrollRect;
    public Footsteps footstepsScript;

    public RectTransform layoutRoot;

    private bool isOpen = false;
    private const string NoteKey = "PlayerNote";

    void Start()
    {
  
        inputField.text = PlayerPrefs.GetString(NoteKey, "");

        closeButton.onClick.AddListener(CloseNotebook);

        inputField.onValueChanged.AddListener(delegate { RefreshLayout(); });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isOpen)
                OpenNotebook();
        }
    }

    void OpenNotebook()
    {
        notebookUI.SetActive(true);
        isOpen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        foreach (var s in scriptsToDisable)
            s.enabled = false;

        scrollRect.verticalNormalizedPosition = 0;
        RefreshLayout();
    }

    public void CloseNotebook()
    {
        notebookUI.SetActive(false);
        isOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (var s in scriptsToDisable)
            s.enabled = true;

        PlayerPrefs.SetString(NoteKey, inputField.text);
        PlayerPrefs.Save();
    }

    private void RefreshLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
    }

    public bool IsOpen()
    {
        return isOpen;
    }

}
