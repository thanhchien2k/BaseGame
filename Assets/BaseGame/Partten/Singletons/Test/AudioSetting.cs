using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private Slider music_Slider;
    [SerializeField] private Slider effect_Slider;

    private void Awake()
    {
        music_Slider.onValueChanged.AddListener(OnChangVolumnMusic);
        effect_Slider.onValueChanged.AddListener(OnChangVolumnEffect);
    }

    private void OnChangVolumnMusic(float value)
    {
        AudioManager.Instance.ChangeVolumnMusic(value);
    }

    private void OnChangVolumnEffect(float value)
    {
        AudioManager.Instance.ChangeVolumnEffect(value);
    }

    public void OnClickMusicBtn()
    { 
        AudioManager.Instance.OnClickMusicBtn();
    }
    public void OnClickEffectBtn()
    {
        AudioManager.Instance.StopEffectSound();
    }

    private void OnDestroy()
    {
        music_Slider.onValueChanged.RemoveListener(OnChangVolumnMusic);
    }
}
