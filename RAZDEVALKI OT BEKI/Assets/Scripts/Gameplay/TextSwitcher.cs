using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    public Button switchButton;

    void Start()
    {
        switchButton.onClick.AddListener(SwitchText);
    }

    void SwitchText()
    {
        LanguageManager.Instance.SwitchLanguage();
    }
}
