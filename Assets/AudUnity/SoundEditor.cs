using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace AudUnity
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Sound))]
    internal class SoundEditor : Editor
    {
        const string btxt_autoNameObject = "Name by Scriptable Object name";
        const string btxt_autoNameClip = "Name by Audio Clip name";
        const string btxt_play = "Play";
        const string btxt_stop = "Stop";
        const string objName_play = "Played Sound By Sound Editor";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Sound sound = (Sound)target;
            GUILayout.Space(SoundData.spaceBetweenCategories);

            if (GUILayout.Button(btxt_autoNameObject))
                sound.NameByObject();

            if (sound.sound.clip != null && GUILayout.Button(btxt_autoNameClip))
                sound.NameByClip();

            GUILayout.BeginHorizontal();
 
            if (GUILayout.Button(btxt_play))
                PlayNow(sound);

            var playObject = GameObject.Find(objName_play);
            if (playObject != null && GUILayout.Button(btxt_stop))
                DestroyImmediate(playObject);

            GUILayout.EndHorizontal();
        }

        static void PlayNow(Sound sound)
        {
            var gameObject = GameObject.Find(objName_play) ?? new GameObject(objName_play);
            var getComp = gameObject.GetComponent<AudioSource>();
            var source = getComp != null ? getComp : gameObject.AddComponent<AudioSource>();
            var s = sound.sound;

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

            source.Play();
        }

        static internal void ReplayIfIsPlaying(Sound sound)
        {
            var gO = GameObject.Find(objName_play);
            if (gO != null)
                PlayNow(sound);
        }

        static internal void DestroyImmediateIfPlayObjectExist()
        {
            var playObject = GameObject.Find(objName_play);
            if (playObject != null)
                DestroyImmediate(playObject);
        }
        
        private void OnEnable() => DestroyImmediateIfPlayObjectExist();
        private void OnDisable() => DestroyImmediateIfPlayObjectExist();
        private void OnValidate() => DestroyImmediateIfPlayObjectExist();
        private void OnDestroy() => DestroyImmediateIfPlayObjectExist();
    }
}

#endif
