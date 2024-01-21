using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace AudUnity
{
    /// <summary>
    /// A class containing every property of a sound
    /// </summary>
#if UNITY_EDITOR
    [CanEditMultipleObjects]
#endif
    [System.Serializable]
    public class SoundData
    {
        /// <summary>
        /// For the spaces in the inspector
        /// </summary>
        internal const int spaceBetweenCategories = 20;

        /// <summary>
        /// The name of the sound
        /// </summary>
        [Tooltip("Pick a name for your sound")]
        public string soundName;

        /// <summary>
        /// The AudioClip containg the audio of the sound
        /// </summary>
        [Tooltip("The audio clip of the sound")]
        public AudioClip clip;

        /// <summary>
        /// The mixer in which the sound will be played
        /// </summary>
        [Tooltip("Choose the mixer in which the sound will be played")]
        public AudioMixerGroup mixer;

        [Space(spaceBetweenCategories)]
        [Range(0, 255)]
        public int priority;
        [Range(0f, 1f)]
        public float volume;
        [Range(-3f, 3f)]
        public float pitch;
        [Range(-1f, 1f)]
        public float stereoPan;
        [Range(0, 1f)]
        public float spatialBlend;
        [Range(0, 1.1f)]
        public float reverbZoneMix;

        [Space(spaceBetweenCategories)]
        public bool mute;
        public bool bypassEffects;
        public bool bypassListenerEffects;
        public bool bypassReverbZones;

        // <summary>
        /// Determines if the sound shoud be played on Awake()
        /// </summary>
        [Tooltip("Turn on if you want the sound to be played automatically when Awake is being called")]
        public bool playOnAwake;

        /// <summary>
        /// Determines if the sound should loop when it is played
        /// </summary>
        [Tooltip("Turn on if you want the sound to loop after it has been played")]
        public bool loop;

        public SoundData(string soundName, AudioClip clip, int priority, float volume, float pitch, float stereoPan, float spatialBlend, float reverbZoneMix, bool loop, bool playOnAwake, AudioMixerGroup mixer,
            bool bypassReverbZones, bool bypassEffects, bool bypassListenerEffects, bool mute)
        {
            this.soundName = soundName ?? "Empty sound name";
            this.clip = clip;
            this.mixer = mixer;

            this.priority = priority;
            this.volume = volume;
            this.pitch = pitch;
            this.stereoPan = stereoPan;
            this.spatialBlend = spatialBlend;
            this.reverbZoneMix = reverbZoneMix;

            this.mute = mute;
            this.bypassEffects = bypassEffects;
            this.bypassListenerEffects = bypassListenerEffects;
            this.bypassReverbZones = bypassReverbZones;
            this.loop = loop;
            this.playOnAwake = playOnAwake;
        }

        public SoundData(string name)
            : this(name, null, 128, 1f, 1f, 0f, 0f, 1f, false, false, null, false, false, false, false) { }

        public SoundData()
            : this("") { }
    }
}
