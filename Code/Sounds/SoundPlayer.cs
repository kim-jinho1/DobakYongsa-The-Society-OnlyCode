using GondrLib.ObjectPool.Runtime;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

namespace Member.kJH.Code.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour, IPoolable
    {
        [SerializeField] private AudioMixerGroup sfxGroup;
        [SerializeField] private AudioMixerGroup musicGroup;
        [SerializeField] private AudioSource audioSource;
        
        [field: SerializeField] public PoolingItemSO PoolingType { get; private set; }
        public GameObject GameObject => gameObject;
        private Pool _myPool;

        public void SetUpPool(Pool pool)
        {
            _myPool = pool;
        }

        public void ResetItem()
        {
            // do nothing
        }

        public void PlaySound(SoundSO clipData)
        {
            if (clipData.audioType == SoundSO.AudioTypes.SFX)
            {
                audioSource.outputAudioMixerGroup = sfxGroup;
            }
            else if (clipData.audioType == SoundSO.AudioTypes.Music)
            {
                audioSource.outputAudioMixerGroup = musicGroup;
            }

            audioSource.volume = clipData.volume;
            audioSource.pitch = clipData.pitch;

            if (clipData.randomizePitch)
            {
                audioSource.pitch += Random.Range(-clipData.randomPitchModifier, clipData.randomPitchModifier);
            }

            audioSource.clip = clipData.clip;
            audioSource.loop = clipData.loop;

            audioSource.Play();

            if (!clipData.loop)
            {
                StartCoroutine(ReturnToPoolAfterDelay(clipData.clip.length + 0.2f));
            }
        }

        private IEnumerator ReturnToPoolAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _myPool.Push(this);
        }

        public void StopAndReturnToPool()
        {
            audioSource.Stop();
            _myPool.Push(this);
        }
    }
}
