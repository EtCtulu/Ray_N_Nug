using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager s_Singleton;

    public List<AudioClip> sfx = new List<AudioClip>();
    public List<AudioClip> ambiance = new List<AudioClip>();
    public List<AudioClip> musique = new List<AudioClip>();

    public AudioClip ambiance1;
    public AudioClip ambiance2;
    public AudioClip ambiance3;
    public AudioClip ambiance4;
    public AudioClip musicFuite;

    public AudioClip dash;
    public AudioClip TP;
    public AudioClip Saut;
    public AudioClip crounch;
    public AudioClip glissade;
    public AudioClip stun;
    public AudioClip pas;
    public AudioClip doubleSaut;
    public AudioClip hack;
    public AudioClip atterissage;

    private void Awake()
    {
        sfx.Add(ambiance1);
        ambiance.Add(crounch);
        musique.Add(atterissage);

        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
        DontDestroyOnLoad(this);
    }


    public void PlayNewSound(AudioClip clip, float volume)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume = volume;
        Destroy(audioSource, clip.length);
    }

    /*public Sound[] Sfx;
    public Sound[] Musique;
    public Sound[] Ambiance;

    public static SoundManager instance;

    void Start()
    {
        GetComponent<SoundManager>().Play("test01");
        GetComponent<SoundManager>().Play("test02");
        GetComponent<SoundManager>().Play("test03");
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound sfx in Sfx )
        {
            sfx.source = gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.clip;

            sfx.source.volume = sfx.volume;
            sfx.source.pitch = sfx.pitch;
            sfx.source.loop = sfx.loop;
        }
        /*foreach (Sound ambiance in Ambiance)
        {
            ambiance.source = gameObject.AddComponent<AudioSource>();
            ambiance.source.clip = ambiance.clip;

            ambiance.source.volume = ambiance.volume;
            ambiance.source.pitch = ambiance.pitch;
            ambiance.source.loop = ambiance.loop;
        }
        foreach (Sound musique in Musique)
        {
            musique.source = gameObject.AddComponent<AudioSource>();
            musique.source.clip = musique.clip;

            musique.source.volume = musique.volume;
            musique.source.pitch = musique.pitch;
            musique.source.loop = musique.loop;
        }
    }

    public void Play(string name)
    {
        Sound sfx = Array.Find(Sfx, Sound => Sound.name == name);
        Sound ambiance = Array.Find(Ambiance, Sound => Sound.name == name);
        Sound musique = Array.Find(Musique, Sound => Sound.name == name);

        sfx.source.Play();
        ambiance.source.Play();
        musique.source.Play();
    }

    public void PlaySound()
    {

    }*/
}
