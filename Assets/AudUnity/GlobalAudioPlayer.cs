using UnityEngine;
using static UnityEngine.Debug;

namespace AudUnity
{
    [AddComponentMenu(menuCategory + "Global Audio Player")]
    public class GlobalAudioPlayer : LocalAudioPlayer
    {
        /// <summary>
        /// The global audio player
        /// </summary>
        public static LocalAudioPlayer Player
        {
            get
            {
                if (globalAudioPlayer == null)
                    globalAudioPlayer = InitializeGlobalPlayer();
                return globalAudioPlayer;
            }
        }

        private static LocalAudioPlayer globalAudioPlayer;
        
        /// <summary>
        /// Used to initialize the global audio player
        /// </summary>
        private static LocalAudioPlayer InitializeGlobalPlayer()
        {
            var globalPlayerComponent = FindObjectOfType<GlobalAudioPlayer>();
            if (globalPlayerComponent != null) 
                return globalPlayerComponent; 

            var gameObject = Camera.main.gameObject;
            return gameObject.GetComponent<GlobalAudioPlayer>() ?? gameObject.AddComponent<GlobalAudioPlayer>();
        }

        internal override void Initialize() =>
            InitializeAudioPlayer(Player);

        public static new void AddSounds(AudioLibrary[] libraries) => Player.AddSounds(libraries);
        public static new void AddSounds(AudioLibrary library) => Player.AddSounds(library);
        public static new void AddSounds(Sound[] sounds) => Player.AddSounds(sounds);
        public static new void AddSound(SoundData s) => Player.AddSound(s);
        public static new void AddSound(Sound s) => Player.AddSound(s.sound);

        public static new void RemoveSound(string name) => Player.RemoveSound(name);
        public static new bool TryRemoveSound(string name) => Player.TryRemoveSound(name);

        public static new void Play(string soundName) => Player.Play(soundName);
        public static new void PlayDelayed(string soundName, float delay) => Player.PlayDelayed(soundName, delay);
        public static new void Stop(string soundName) => Player.Stop(soundName);
        public static new void Pause(string soundName) => Player.Pause(soundName);
        public static new void UnPause(string soundName) => Player.UnPause(soundName);

        public static new void SetVolume(string name, float volume) => Player.SetVolume(name, volume);
        public static new void SetMute(string name, bool mute) => Player.SetMute(name, mute);
        public static new void SetLoop(string name, bool loop) => Player.SetLoop(name, loop);

        public static new bool IsPlaying(string name) => Player.IsPlaying(name);
        public static new bool SoundExists(string name) => Player.SoundExists(name);
        public static new AudioSource GetSoundAudioSource(string name) => Player.GetSoundAudioSource(name);

        private void OnValidate()
        {
            var globalPlayers = FindObjectsOfType<GlobalAudioPlayer>();
            if (globalPlayers.Length > 1)
                LogError("You have more than one GlobalAudioPlayer in a scene");
        }
    }
}
