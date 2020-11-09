using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    LevelLoader levelLoader;
    int index;
    #region
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    instance = new GameObject("Created SoundManager", typeof(SoundManager)).GetComponent<SoundManager>();
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    private void Start()
    {
        index = GameObject.Find("LevelLoader").GetComponent<LevelLoader>().scenIndex;
        FindSong();
    }
    /// <summary>
    /// Looking for song in "SoundBank" audioClip array for same index as the scene
    /// </summary>
    private void FindSong()
    {
        switch (index)
        {
            case 0:
                Instance.PlayMusic(GameAssets.instance.audioClips[index]);
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource soundEffectSource;
    private bool firstSourceOfmusic;

    private void Awake()
    {
        //Dont destroy this object
        DontDestroyOnLoad(this.gameObject);
        //Create audio sources + save as references
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        soundEffectSource = this.gameObject.AddComponent<AudioSource>();
        //loop music
        musicSource.loop = true;
        musicSource2.loop = true;
    }
    public void PlayMusic(AudioClip audioClip)
    {

        //Check wich of the music sources that is playing atm
        AudioSource activeSource = (firstSourceOfmusic) ? musicSource : musicSource2;

        activeSource.clip = audioClip;
        activeSource.Play();
    }
    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        //Check wich of the music sources that is playing atm
        AudioSource activeSource = (firstSourceOfmusic) ? musicSource : musicSource2;
        StartCoroutine(SwapMusicWithFade(activeSource, newClip,transitionTime));
    }
    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
    //Method for playing soundeffect and adjust volume
    public void PlaySoundEffect(AudioClip clip, float volume)
    {
        soundEffectSource.PlayOneShot(clip, volume);
    }
    private IEnumerator SwapMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        //Check if the source is playing
        if (!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;

        //Fade out
        for (t= 0; t<transitionTime; t+= Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();

        //Fade in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume =  (t / transitionTime);
            yield return null;
        }
    }

    //private static AudioClip GetAudioClip(Song song)
}
