using BaseGame.Sngletons;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeReference] protected AudioSource musicSource;
    [SerializeReference] protected AudioSource effectSource;
    public AudioClip musicSound, effectSound;
    protected override void Awake()
    {
        base.Awake();
        PlayMusicSound();
    }

    public void PlayMusicSound()
    {
        if (musicSound != null) musicSource.clip = musicSound;
        musicSource.Play();
    }

    public void StopMusicSound()
    {
        musicSource.Stop();
    }

    public void PlayEffectSound(AudioClip effectSound) 
    {
        if (effectSound != null) effectSource.clip = effectSound;
        effectSource.Play();
    }

    public void StopEffectSound() 
    {
        effectSource.Stop();
    }

    public void ChangeVolumnMusic(float value)
    {
        musicSource.volume = value;
    }

    public void ChangeVolumnEffect(float value)
    {
        effectSource.volume = value;
    }

    public void OnClickMusicBtn()
    {
        if(musicSource.isPlaying) 
        {
            StopMusicSound();
        }
        else
        {
            PlayMusicSound();
        }
    }
}
