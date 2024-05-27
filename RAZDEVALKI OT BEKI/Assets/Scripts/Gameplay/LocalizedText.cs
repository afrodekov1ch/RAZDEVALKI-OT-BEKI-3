using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key; // Ключ для локализованного текста
    private Text textComponent; // Приватная переменная для компонента Text

    void Start()
    {
        // Инициализация компонента Text
        textComponent = GetComponent<Text>();

        if (textComponent == null)
        {
            Debug.LogError("Text component not found on this GameObject. Please attach this script to a GameObject with a Text component.");
            return;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        if (textComponent != null)
        {
            // Получение перевода из LanguageManager и обновление текста
            textComponent.text = LanguageManager.Instance.GetTranslation(key);
        }
        else
        {
            Debug.LogError("Text component is null. Ensure the Text component is properly assigned.");
        }
    }
}
