using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //ne fait pas la difference entre un bruitage et une musique 
    public AudioClip[] playList;

    public AudioSource audioSource;

    //quelle music et en train de joue
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instanceAudioManager;

    public void Awake()
    {
        if (instanceAudioManager != null)
        {
            Debug.LogWarning("Il a plus d'une instance de AudioManager dans la scene");
            return;
        }
        instanceAudioManager = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = playList[0];
        audioSource.Play();
        
    }

    // passe a la music suivent  
    void Update()
    {
        if (!audioSource.isPlaying) {
            PlayNextSong();
        }
    }
    public void PlayNextSong() { 
        musicIndex = (musicIndex+1) % playList.Length;
        audioSource.clip = playList[musicIndex];
        audioSource.Play();
    }

    //music - clip , vector - position
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos) {

        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource =tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup=soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO,clip.length);
        return audioSource;
    }
}
