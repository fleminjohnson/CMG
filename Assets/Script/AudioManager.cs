using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame
{
    public class AudioManager : SingletonBehaviourDontDestroy<AudioManager>
    {
        [SerializeField]
        private AudioSource audioSource; // The AudioSource component to play sounds
        [SerializeField]
        private List<AudioClip> audioClips = new List<AudioClip>(); // List to store different audio clips

        // Start is called before the first frame update
        void Start()
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component if not already attached
            }
        }

        // Play a sound by name
        public void PlaySoundOneShot(string name)
        {
            AudioClip clip = audioClips.Find(c => c.name == name);
            if (clip != null)
            {
                audioSource.PlayOneShot(clip); // Play the found clip
            }
        }

        // Stop the current playing sound
        public void StopSound()
        {
            audioSource.Stop();
        }

        // Add more methods as needed for managing audio, like adjusting volume, etc.
    }
}
