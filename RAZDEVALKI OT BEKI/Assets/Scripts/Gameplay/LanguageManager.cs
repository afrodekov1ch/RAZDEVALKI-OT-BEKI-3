using UnityEngine;
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
        russianTexts["settings"] = "Настройки";
        englishTexts["settings"] = "Settings";
        russianTexts["pause"] = "Пауза";
        englishTexts["pause"] = "Pause";
        russianTexts["shop"] = "Магазин";
        englishTexts["shop"] = "Shop";
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
        Debug.Log("Translating key: " + key);
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
        Debug.LogWarning("Translation not found for key: " + key);
        return key;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
