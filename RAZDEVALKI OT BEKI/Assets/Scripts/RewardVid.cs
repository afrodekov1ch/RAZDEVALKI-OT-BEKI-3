using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardVid : MonoBehaviour
{
    [SerializeField] private Button[] RewardButton;
    private int auto;
    private int power;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    private void Awake()
    {
        RewardButton[1].onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
        RewardButton[0].onClick.AddListener(delegate { ExampleOpenRewardAd(0); });
    }

    private void Update()
    {
        auto = PlayerPrefs.GetInt("auto");
        power = PlayerPrefs.GetInt("power");
    }

    void Rewarded(int id)
    {
        if (id == 0)
        {
            power += 5;
            PlayerPrefs.SetInt("power", power);
        }
        if (id == 1)
        {
            auto += 5;
            PlayerPrefs.SetInt("auto", auto);
        }
    }
    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
