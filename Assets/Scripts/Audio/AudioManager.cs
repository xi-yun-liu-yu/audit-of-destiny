using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class AudioManager : PersistentSingleten<AudioManager>
    {
        [Header("音效")] [Tooltip("设置音源")] [SerializeField]
        AudioSource sFXPlayer;

        [Tooltip("设置SFX音量")] [SerializeField] float sFXVolume = 0.1f;

        [Tooltip("不能为空")] [SerializeField] List<AudioClip> audioSFXClips;


        [Header("音乐")] [Tooltip("设置音源")] [SerializeField]
        AudioSource musicPlayer;

        [Tooltip("设置SFX音量")] [SerializeField] float musicVolume = 0.1f;

        [Tooltip("不能为空")] [SerializeField] List<AudioClip> audioMusicClips;

        // slider 配置来源滑条
        // 设置音量
        public void SetSFXVolume(Slider slider)
        {
            sFXVolume = slider.value;
            sFXPlayer.volume = sFXVolume;
        }

        // slider 配置来源滑条
        // 设置音量
        public void SetMusicVolume(Slider slider)
        {
            musicVolume = slider.value;
            musicPlayer.volume = musicVolume;
        }


        // audioClip 音频源
        // volume 音量
        // 播放UI音效
        public void PlaySFX(AudioClip audioClip, float volume)
        {
            sFXPlayer.PlayOneShot(audioClip, volume);
        }

        // volume 音量
        // 默认播放第一条UI音效
        public void PlaySFX()
        {
            sFXPlayer.PlayOneShot(audioMusicClips[0], sFXVolume);
        }

        // index 索引
        // volume 音量
        // 播放第index条UI音效
        public void PlaySFX(int index)
        {
            sFXPlayer.PlayOneShot(audioMusicClips[index - 1], sFXVolume);
        }

        // volume 音量
        // 随机播放UI音效
        public void PlayRandomSFX()
        {
            int index = Random.Range(0, audioMusicClips.Count);
            sFXPlayer.PlayOneShot(audioMusicClips[index], sFXVolume);
        }


        // audioClip 音频源
        // volume 音量
        // 播放背景音乐
        public void PlayMusic(AudioClip audioClip, float volume)
        {
            musicPlayer.clip = audioClip;
            musicPlayer.volume = volume;
            musicPlayer.Play();
        }

        // volume 音量
        // 默认播放第一条背景音乐
        public void PlayMusic()
        {
            musicPlayer.clip = audioMusicClips[0];
            musicPlayer.volume = musicVolume;
            musicPlayer.Play();
        }

        // index 索引
        // volume 音量
        // 播放第index条背景音乐
        public void PlayMusic(int index)
        {
            musicPlayer.clip = audioMusicClips[index - 1];
            musicPlayer.volume = musicVolume;
            musicPlayer.Play();
        }

        // volume 音量
        // 随机播放背景音乐
        public void PlayRandomMusic()
        {
            int index = Random.Range(0, audioMusicClips.Count);
            musicPlayer.clip = audioMusicClips[index];
            musicPlayer.volume = musicVolume;
            musicPlayer.Play();
        }
    }
}