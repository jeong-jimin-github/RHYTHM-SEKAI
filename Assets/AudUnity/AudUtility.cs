using static UnityEngine.Debug;

namespace AudUnity
{
    internal static class AudUtility
    {  
        static internal void LogErrorSoundNull(int index, string libraryName) =>
            LogErrorFormat("The sound at index \"{0} \", in the audio library \"{1}\" is null", index, libraryName);

        static internal void LogErrorSoundAlreadyExists(Sound s) => 
            LogErrorFormat("Could not add a Sound named: <{0}> because there is already a sound in this audio player with that name", s.sound.soundName);
    }
}
