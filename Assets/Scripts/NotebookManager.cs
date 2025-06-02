using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour
{
    public GameObject notebookUI;                  
    public TMP_InputField inputField;              
    public Button closeButton;                     
    public ScrollRect scrollRect;                  //Scroll component to reset scroll on open
    public Footsteps footstepsScript;              

    public RectTransform layoutRoot;               //Used to force layout refresh

    private bool isOpen = false;                   
    public GameObject passwordPanel;               

    void Start()
    {
        //Load previously saved note content (if any)
        inputField.text = PlayerPrefs.GetString("NotebookNote", "");

        //Register listeners for the close button and input text changes
        closeButton.onClick.AddListener(CloseNotebook);
        inputField.onValueChanged.AddListener(delegate { RefreshLayout(); });
    }

    void Update()
    {
        //Block notebook opening if the password panel is active
        if (passwordPanel != null && passwordPanel.activeSelf)
            return;

        //Toggle notebook on 'N' key
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isOpen)
                OpenNotebook();
        }
    }

    void OpenNotebook()
    {
        //Show the notebook and unlock cursor
        notebookUI.SetActive(true);
        isOpen = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Reset scroll position to the top
        scrollRect.verticalNormalizedPosition = 0;
        RefreshLayout();
    }

    public void CloseNotebook()
    {
        notebookUI.SetActive(false);
        isOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Save current note content
        PlayerPrefs.SetString("NotebookNote", inputField.text);
        PlayerPrefs.Save();
    }

    private void RefreshLayout()
    {
        //Force the layout system to update (especially useful for text changes)
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
