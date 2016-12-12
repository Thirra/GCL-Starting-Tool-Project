using UnityEngine;
using System.Collections;

namespace GameManagement
{
    public class SoundManager : MonoBehaviour
    {
        //Audio sources
        public AudioSource soundEffectsSource;
        public AudioSource musicSource;

        //SoundManager instance
        public static SoundManager instance;

        private void Start()
        {
            //Checks to see if there is an instance already present
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {

        }

        public void PlayMusic(AudioClip audio)
        {
            musicSource.clip = audio;
            musicSource.Play();
        }

        public void PlaySoundEffect(AudioClip audio)
        {
            soundEffectsSource.PlayOneShot(audio);
        }
    }
}

