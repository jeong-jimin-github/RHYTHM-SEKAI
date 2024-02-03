using System.Collections.Generic;
using UnityEngine;
using static AudUnity.AudUtility;

namespace AudUnity
{
    /// Properties --------------------------------------------------------------------
    /// - SoundsCount         - Amount of sounds in audio player
    /// -------------------------------------------------------------------------------
    /// 
    /// Methods -----------------------------------------------------------------------
    /// - Play                - Plays a sound
    /// - PlayDelayed         - Plays a sound with a delay specified in seconds
    /// - Stop                - Stops a sound
    /// - Pause               - Pauses a sound
    /// - UnPause             - UnPauses a sound
    /// 
    /// - SetMute             - Mutes or unmutes a sound
    /// - SetVolume           - Sets a sound's volume
    /// - SetLooping          - Turns on or off sound's looping option
    /// 
    /// - IsPlaying           - Check if a sound is currently playing
    /// 
    /// - AddSounds           - Adds sounds to player
    /// - AddSound            - Adds a sound to player
    /// - RemoveSound         - Removes a sound from the player
    /// - TryRemoveSound      - Removes a sound from the player only if it exists
    /// - GetSoundAudioSource - Returns an AudioSource component by a given sound name
    /// -------------------------------------------------------------------------------
    /// 
    /// <summary>
    /// <para>A component that takes an "AudioLibrary" object and initializes the sounds it stores.</para> 
    /// <para>You can call the Audio Player to play/stop these sounds in your game.</para>
    /// </summary>
    [AddComponentMenu(menuCategory + "Local Audio Player")]
    public class LocalAudioPlayer : MonoBehaviour
    {
        protected internal const string menuCategory = "AudUnity/";
        protected internal const string audioSourcesContainerObjName = "AudioPlayerObject";

        GameObject _audioSourcesContainer;
        GameObject AudioSourcesContainer
        {
            get => _audioSourcesContainer ??= InitializeAudioSourcesContainer();
        }

        string _currentLibraryName;
        string CurrentLibraryName
        {
            get => _currentLibraryName ??= string.Empty;
            set => _currentLibraryName = value;
        }

        /// <summary>
        /// Amount of sounds in audio player
        /// </summary>
        public int SoundsCount { get => audioSources.Count; }

        /// <summary>
        /// The linked Audio Library the Audio Player initializes on Awake()
        /// </summary>
        [Tooltip("The linked audio library will be initialized by the Audio Player on Awake()")]
        [SerializeField] internal AudioLibrary[] linkedAudioLibraries;

        /// <summary>
        /// A private dictionary lining between sound names and their audio sources
        /// </summary>
        private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
        private HashSet<int> referencedAudioLibraries = new HashSet<int>();
        private HashSet<int> soundsHashes = new HashSet<int>();

        void OnLoadLibrary(AudioLibrary lib) =>
            CurrentLibraryName = lib.name;

        void OnInitialize()
        {
            audioSources = new Dictionary<string, AudioSource>();
            referencedAudioLibraries = new HashSet<int>();
            soundsHashes = new HashSet<int>();
        }

        void Awake() =>
            Initialize();

        /// <summary>
        /// Initializes an Audio Player by adding its linked Audio Library
        /// </summary>
        internal virtual void Initialize() =>
            InitializeAudioPlayer(this);

        internal void InitializeAudioPlayer(LocalAudioPlayer p)
        {
            p.OnInitialize();
            p.ResetAudioSourcesContainer();
            p.AddSounds(p.linkedAudioLibraries);
        }

        Transform GetAudioSourcesContainer() => gameObject.transform.Find(audioSourcesContainerObjName);

        GameObject InitializeAudioSourcesContainer()
        {
            var current = GetAudioSourcesContainer();
            if (current != null) 
                return current.gameObject;

            var newObj = new GameObject(audioSourcesContainerObjName);
            newObj.transform.parent = transform;
            return newObj;
        }

        internal void ResetAudioSourcesContainer()
        {
            _audioSourcesContainer = null;
            var container = GetAudioSourcesContainer();
            if (container != null)
                DestroyImmediate(container.gameObject);
        }

        /// <summary>
        /// Adds sounds to the Audio Player from an array of audio libraries
        /// </summary>
        /// <param name="libraries">An array of audio libraries</param>
        public void AddSounds(AudioLibrary[] libraries)
        {
            if (libraries != null)
                for (int i = 0; i < libraries.Length; i++)
                    AddSounds(libraries[i]);
        }

        /// <summary>
        /// Adds sounds to the Audio Player from an Audio Library
        /// </summary>
        /// <param name="library">An audio library</param>
        public void AddSounds(AudioLibrary library)
        {
            if (library != null && 
                referencedAudioLibraries.Add(library.GetInstanceID()))
            {
                OnLoadLibrary(library);
                AddSounds(library.sounds);
                AddSounds(library.audioLibraries);
            }
        }

        /// <summary>
        /// Adds sounds to the Audio Player from an array of sounds
        /// </summary>
        /// <param name="s">An array of sounds</param>
        public void AddSounds(Sound[] soundPresets)
        {
            if (soundPresets != null && soundPresets.Length > 0)
            {
                // create an audio source component for each sound preset and set its settings
                for (int i = 0; i < soundPresets.Length; i++)
                {
                    if (soundPresets[i] == null)
                    {
                        LogErrorSoundNull(i, CurrentLibraryName);  
                        continue;
                    }

                    if (!soundsHashes.Add(soundPresets[i].sound.soundName.GetHashCode()))
                    {
                        LogErrorSoundAlreadyExists(soundPresets[i]);
                        continue;
                    }

                    AddSound(soundPresets[i].sound);
                }
            }
        }

        /// <summary>
        /// Adds a sound to the Audio Player
        /// </summary>
        /// <param name="s">The sound you want to add</param>
        public void AddSound(SoundData s)
        {
            var source = AudioSourcesContainer.AddComponent<AudioSource>();

            // apply propeties
            source.clip = s.clip;
            source.outputAudioMixerGroup = s.mixer;

            source.priority = s.priority;
            source.volume = s.volume;
            source.pitch = s.pitch;
            source.panStereo = s.stereoPan;
            source.spatialBlend = s.spatialBlend;
            source.reverbZoneMix = s.reverbZoneMix;

            source.mute = s.mute;
            source.bypassEffects = s.bypassEffects;
            source.bypassListenerEffects = s.bypassEffects;
            source.bypassReverbZones = s.bypassReverbZones;
            source.playOnAwake = s.playOnAwake;
            source.loop = s.loop;

            if (s.playOnAwake)
                source.Play();

            // add to audio sources list
            audioSources.Add(s.soundName, source);
        }

        /// <summary>
        /// Adds sound the Audio Player
        /// </summary>
        /// <param name="s">A sound</param>
        public void AddSound(Sound s) => AddSound(s.sound);

        /// <summary>
        /// Removes a sound by a given name
        /// </summary>
        /// <param name="name">The name of the sound you want to remove</param>
        public void RemoveSound(string name)
        {
            AudioSource source = audioSources[name];
            source.Stop();
            audioSources.Remove(name);
            Destroy(source);
        }

        /// <summary>
        /// Removes a sound if it exists
        /// </summary>
        /// <param name="name">The name of the sound you want to remove</param>
        /// <returns>true if the sound has been removed</returns>
        public bool TryRemoveSound(string name)
        {
            if (SoundExists(name))
            {
                RemoveSound(name);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Plays a sound by a given name
        /// </summary>
        /// <param name="soundName">A string containing the name of the sound</param>
        public void Play(string soundName) => audioSources[soundName].Play();

        /// <summary>
        /// Plays a sound with a delay specified in seconds by a given name
        /// </summary>
        /// <param name="soundName">A string containing the name of the sound</param>
        public void PlayDelayed(string soundName, float delay) => audioSources[soundName].PlayDelayed(delay);

        /// <summary>
        /// Stops a sound by a given name
        /// </summary>
        /// <param name="soundName">A string containing the name of the sound</param>
        public void Stop(string soundName) => audioSources[soundName].Stop();

        /// <summary>
        /// Pauses a sound by a given name
        /// </summary>
        /// <param name="soundName">A string containing the name of the sound</param>
        public void Pause(string soundName) => audioSources[soundName].Pause();

        /// <summary>
        /// UnPauses a sound by a given name
        /// </summary>
        /// <param name="soundName">A string containing the name of the sound</param>
        public void UnPause(string soundName) => audioSources[soundName].UnPause();

        /// <summary>
        /// Sets the volume of a sound by a given name
        /// </summary>
        /// <param name="name">A string containing the name of the sound</param>
        /// <param name="volume">The desired volume - from 0 to 1</param>
        public void SetVolume(string name, float volume)
        {
            if (!string.IsNullOrEmpty(name))
                audioSources[name].volume = volume;
        }

        /// <summary>
        /// Mutes or unmutes a sound by a given name
        /// </summary>
        /// <param name="name">The name of the sound you want to mute/unmute</param>
        /// <param name="mute">true = mute, false = unmute</param>
        public void SetMute(string name, bool mute) => audioSources[name].mute = mute;

        /// <summary>
        /// Turns on or off sound's looping option
        /// </summary>
        /// <param name="name">The name of the sound</param>
        /// <param name="loop"></param>
        public void SetLoop(string name, bool loop) => audioSources[name].loop = loop;

        /// <summary>
        /// Check if a sound is currently playing
        /// </summary>
        /// <param name="name">The name of the sound</param>
        /// <returns>true if the sound is currently playing</returns>
        public bool IsPlaying(string name) => audioSources[name].isPlaying;

        /// <summary>
        /// Check if a sound is exists in the player
        /// </summary>
        /// <param name="name">The name of the sound</param>
        /// <returns>true if the sound exists</returns>
        public bool SoundExists(string name) => audioSources[name] == null ? false : true;

        /// <summary>
        /// Returns an AudioSource component by a given sound name
        /// </summary>
        /// <param name="name">The name of the sound</param>
        /// <returns>AudioSource component of the sound</returns>
        public AudioSource GetSoundAudioSource(string name) => audioSources[name];
    }
}
