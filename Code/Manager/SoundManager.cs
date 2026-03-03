using System;
using System.Collections.Generic;
using GondrLib.Dependencies;
using GondrLib.ObjectPool.Runtime;
using Member.Core.EventBus;
using Member.kJH.Code.Event;
using Member.kJH.Code.Sounds;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Member.kJH.Code.Manager
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private Slider sfxVolumeSlider;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private AudioMixer audioMixer;
        
        [SerializeField] private PoolingItemSO soundPlayer;
        
        [Inject] private PoolManagerMono _poolManager;
        private SoundPlayer _bgmPlayer;

        private Dictionary<int, SoundPlayer> _longSoundDict;

        private readonly string _sfx = "SFX";
        private readonly string _bgm = "BGM";
        private readonly string _master = "MASTER";
        
        private float _sfxValue;
        private float _bgmValue;
        private float _masterValue;
        
        private void Awake()
        {
            _longSoundDict = new Dictionary<int, SoundPlayer>();

            _sfxValue = PlayerPrefs.GetFloat(_sfx, 1);
            _bgmValue = PlayerPrefs.GetFloat(_bgm, 1);
            _masterValue = PlayerPrefs.GetFloat(_master, 1);

            sfxVolumeSlider.value = _sfxValue;
            bgmVolumeSlider.value = _bgmValue;
            masterVolumeSlider.value = _masterValue;

            SetSFXVolume(_sfxValue);
            SetBGMVolume(_bgmValue);
            SetMasterVolume(_masterValue);

            Bus<PlaySFXEvent>.OnEvent[Owner.AI1] += HandlePlaySFX;
            Bus<PlayBGMEvent>.OnEvent[Owner.AI1] += HandlePlayBGM;
            Bus<StopBGMEvent>.OnEvent[Owner.AI1] += HandleStopBGM;
            Bus<PlayLongSFXEvent>.OnEvent[Owner.AI1] += HandlePlayLongSFX;
            Bus<StopLongSFXEvent>.OnEvent[Owner.AI1] += HandleStopLongSFX;

            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
            bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
            masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        }

        
        private void OnDestroy()
        {
            Bus<PlaySFXEvent>.OnEvent[Owner.AI1] -= HandlePlaySFX;
            Bus<PlayBGMEvent>.OnEvent[Owner.AI1] -= HandlePlayBGM;
            Bus<StopBGMEvent>.OnEvent[Owner.AI1] -= HandleStopBGM;
            Bus<PlayLongSFXEvent>.OnEvent[Owner.AI1] -= HandlePlayLongSFX;
            Bus<StopLongSFXEvent>.OnEvent[Owner.AI1] -= HandleStopLongSFX;
            
            sfxVolumeSlider.onValueChanged.RemoveListener(SetSFXVolume);
            bgmVolumeSlider.onValueChanged.RemoveListener(SetBGMVolume);
            masterVolumeSlider.onValueChanged.RemoveListener(SetMasterVolume);
        }
        
        private void SetSFXVolume(float value)
        {
            audioMixer.SetFloat("SFXVolume", SliderToDecibel(value));
            PlayerPrefs.SetFloat(_sfx, value);
            PlayerPrefs.Save();
        }

        private void SetBGMVolume(float value)
        {
            audioMixer.SetFloat("BGMVolume", SliderToDecibel(value));
            PlayerPrefs.SetFloat(_bgm, value);
            PlayerPrefs.Save();
        }

        private void SetMasterVolume(float value)
        {
            audioMixer.SetFloat("MasterVolume", SliderToDecibel(value));
            PlayerPrefs.SetFloat(_master, value);
            PlayerPrefs.Save();
        }


        private float SliderToDecibel(float value)
        {
            if (value <= 0.0001f) return -80f;
            return Mathf.Log10(value) * 20f;
        }
        
        private void HandleStopLongSFX(StopLongSFXEvent evt)
        {
            if(_longSoundDict.TryGetValue(evt.IdxNumber, out SoundPlayer player))
            {
                player.StopAndReturnToPool();
                _longSoundDict.Remove(evt.IdxNumber);
            }
        }
        
        private void HandlePlayLongSFX(PlayLongSFXEvent evt)
        {
            if (_longSoundDict.TryGetValue(evt.IdxNumber, out SoundPlayer player))
            {
                player.StopAndReturnToPool();
                _longSoundDict.Remove(evt.IdxNumber);
            }

            SoundPlayer sfxPlayer = _poolManager.Pop<SoundPlayer>(soundPlayer);
            sfxPlayer.transform.position = evt.Position;
            sfxPlayer.PlaySound(evt.SoundClip);
            
            _longSoundDict.Add(evt.IdxNumber, sfxPlayer );
        }

        private void HandlePlaySFX(PlaySFXEvent evt)
        {
            SoundPlayer sfxPlayer = _poolManager.Pop<SoundPlayer>(soundPlayer);
            sfxPlayer.transform.position = evt.Position;
            sfxPlayer.PlaySound(evt.SoundClip);
        }

        private void HandlePlayBGM(PlayBGMEvent evt)
        {
            //_bgmPlayer?.StopAndReturnToPool();
            _bgmPlayer = _poolManager.Pop<SoundPlayer>(soundPlayer);
            _bgmPlayer.PlaySound(evt.BGMClip);
        }


        private void HandleStopBGM(StopBGMEvent evt)
        {
            _bgmPlayer?.StopAndReturnToPool();
        }
    }
}