using UnityEngine;

namespace AudUnity
{
    /// <summary>
    /// <para>A scriptable object, that stores sounds and references other audio libraries.</para>
    /// <para>To use an audio library inside a game create an Audio Manager component and drag the library to the field "linked sound library".</para> 
    /// </summary>
    [CreateAssetMenu(fileName = "Audio Library", menuName = LocalAudioPlayer.menuCategory + "Audio Library", order = 1)]
    public class AudioLibrary : ScriptableObject
    {
        /// <summary>
        /// Sound presets referenced in audio library
        /// </summary>
        public
        Sound[] sounds;

        /// <summary>
        /// Other libraries referenced in audio library
        /// </summary>
        public
        AudioLibrary[] audioLibraries;
    }
}
