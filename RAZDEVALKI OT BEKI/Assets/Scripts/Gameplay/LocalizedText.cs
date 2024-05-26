using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key; // Ключ для поиска перевода

    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<Text>();
        }
        textComponent.text = LanguageManager.Instance.GetTranslation(key);
    }
}
