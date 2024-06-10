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
        russianTexts["videoup"] = "+5 за видео";
        englishTexts["videoup"] = "+5 for video";
        russianTexts["forclick"] = "+5 за клик";
        englishTexts["forclick"] = "+5 for click";
        russianTexts["buyclick"] = "+1 за клик, ЦЕНА: 25";
        englishTexts["buyclick"] = "+1 for click, PRICE: 25";
        russianTexts["autoclick"] = "+3 автоклик";
        englishTexts["autoclick"] = "+3 autoclick";
        russianTexts["buyautoclick"] = "+1 автоклик, ЦЕНА: 100";
        englishTexts["buyautoclick"] = "+1 autoclick, PRICE: 100";
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
