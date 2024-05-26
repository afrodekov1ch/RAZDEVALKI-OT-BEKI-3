using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    private bool isRussian;
    private Dictionary<string, string> russianTexts = new Dictionary<string, string>();
    private Dictionary<string, string> englishTexts = new Dictionary<string, string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDictionaries();
            LoadLanguageSetting();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeDictionaries()
    {
        // Добавьте здесь все пары ключ-значение для перевода
        russianTexts["settings"] = "Настройки";
        englishTexts["settings"] = "Settings";
        russianTexts["videoup"] = "+5$ за видео";
        englishTexts["videoup"] = "+5$ for the video";
        // Добавьте больше пар ключ-значение для других текстов
    }

    void LoadLanguageSetting()
    {
        isRussian = PlayerPrefs.GetInt("isRussian", 1) == 1;
        UpdateAllTexts();
    }

    void SaveLanguageSetting()
    {
        PlayerPrefs.SetInt("isRussian", isRussian ? 1 : 0);
    }

    public void SwitchLanguage()
    {
        isRussian = !isRussian;
        SaveLanguageSetting();
        UpdateAllTexts();
    }

    void UpdateAllTexts()
    {
        LocalizedText[] allTexts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText text in allTexts)
        {
            text.UpdateText();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAllTexts();
    }

    public string GetTranslation(string key)
    {
        if (isRussian)
        {
            if (russianTexts.ContainsKey(key))
                return russianTexts[key];
        }
        else
        {
            if (englishTexts.ContainsKey(key))
                return englishTexts[key];
        }
        return key; // Вернуть ключ, если перевод не найден
    }
}
