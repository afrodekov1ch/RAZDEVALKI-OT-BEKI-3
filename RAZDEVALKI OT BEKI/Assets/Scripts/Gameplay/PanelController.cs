using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelActive;
    public Button enableButton;
    public Button disableButton;

    void Start()
    {
        enableButton.onClick.AddListener(EnablePanel);
        disableButton.onClick.AddListener(DisablePanel);

        SceneManager.sceneLoaded += OnSceneLoaded;

        panel.SetActive(false);
        isPanelActive = false;
    }

    void OnEnable()
    {
        isPanelActive = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isPanelActive = false;
        panel.SetActive(false);
    }

    public void EnablePanel()
    {
        if (!isPanelActive)
        {
            isPanelActive = true;
            panel.SetActive(true);
        }
    }

    public void DisablePanel()
    {
        if (isPanelActive)
        {
            isPanelActive = false;
            panel.SetActive(false);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}