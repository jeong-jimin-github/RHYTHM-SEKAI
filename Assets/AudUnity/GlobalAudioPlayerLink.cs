using UnityEngine;

namespace AudUnity
{
    /// <summary>
    /// A class for calling the global audio player in the scene from the unity editor (buttons, etc...)
    /// If you want to call the global audio player from script, just call the static class GlobalAudioManager
    /// </summary>
    [AddComponentMenu(LocalAudioPlayer.menuCategory + "Global Audio Player Link")]
    public class GlobalAudioPlayerLink : MonoBehaviour
    {
        LocalAudioPlayer audioPlayer;

        private void Awake() =>
            audioPlayer = GlobalAudioPlayer.Player;

        public void Play(string soundName) => audioPlayer.Play(soundName);
        public void PlayDelayed(string soundName, float delay) => audioPlayer.PlayDelayed(soundName, delay);
        public void Stop(string soundName) => audioPlayer.Stop(soundName);
        public void Pause(string soundName) => audioPlayer.Pause(soundName);
        public void UnPause(string soundName) => audioPlayer.UnPause(soundName);
        public void SetVolume(string name, float volume) => audioPlayer.SetVolume(name, volume);
        public void SetMute(string name, bool mute) => audioPlayer.SetMute(name, mute);
        public void SetLoop(string name, bool loop) => audioPlayer.SetLoop(name, loop);
    }
}
