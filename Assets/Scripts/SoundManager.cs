using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// サウンド関連を容易な管理を提供します
// 関数を呼び出すだけで効果音やBGSの再生・停止などを行うことができます
// サウンドは複数同時に再生できます
public class SoundManager : MonoBehaviour
{
    // サウンドエフェクトの最大数
    const int MAX_SOUND_EFFECT_NUM = 20;
    // 複数個のオーディオソースを管理する
    AudioSource[] soundEffectSourcesList = new AudioSource[MAX_SOUND_EFFECT_NUM];
    // BGS用のAudioSourceを管理
    [SerializeField] AudioSource backGroundSource;
    // 使用するサウンドエフェクトのリスト
    [SerializeField] List<AudioClip> soundEffectList;
    // 使用するBGSのリスト
    [SerializeField] List<AudioClip> backGroundSoundList;
    // Startより先に実行される
    // 初期化処理を記述
    void Awake()
    {
        // リストの数だけAudioSourceを作成し、格納する
        for (var i = 0; i < soundEffectSourcesList.Length; i++)
        {
            soundEffectSourcesList[i] = gameObject.AddComponent<AudioSource>();
        }

        // BGS用AudioSourceを作成
        backGroundSource = gameObject.AddComponent<AudioSource>();
        // BGSのループ再生を有効化
        backGroundSource.loop = true;
    }

    // 未使用のAudioSourceを探して返す関数
    AudioSource GetUnusedAudioSource()
    {
        // リストの中から未使用（音を鳴らしてない）AudioSourceを探して返す
        for (var i = 0; i < soundEffectSourcesList.Length; i++)
        {
            if (soundEffectSourcesList[i].isPlaying == false)
            {
                return soundEffectSourcesList[i];
            }
        }

        return null;    // 未使用のAudioSourceがないとき、nullを返す
    }

    /// <summary>
    /// 定義済みリストから効果音を鳴らす関数
    /// </summary>
    /// <param name="soundNumber">効果音のリストのインデックス</param>
    public void PlaySoundEffect(int soundNumber)
    {
        AudioSource source = GetUnusedAudioSource();
        // 未使用のAudioSourceがないとき、処理を終了する
        if (source == null)
        {
            Debug.Log("音が鳴らせなかった");
            return;
        }
    
        // 未使用のAudioSourceがあれば、音を鳴らす
        source.clip = soundEffectList[soundNumber];
        source.Play();
        Debug.Log($"効果音を鳴らします ({source.clip.name})");
    }

    /// <summary>
    /// AudioClipから効果音を鳴らす関数
    /// </summary>
    /// <param name="clip">効果音のAudioClip</param>
    public void PlaySoundEffect(AudioClip clip)
    {
        AudioSource source = GetUnusedAudioSource();
        // 未使用のAudioSourceがないとき、処理を終了する
        if (source == null)
        {
            Debug.Log("音が鳴らせなかった");
            return;
        }

        // 未使用のAudioSourceがあれば、音を鳴らす
        source.clip = clip;
        source.Play();
        Debug.Log($"効果音を鳴らします ({source.clip.name})");
    }

    /// <summary>
    /// 定義済みリストからBGSを鳴らす関数
    /// </summary>
    /// <param name="bgsNumber">BGSのリストのインデックス</param>
    public void PlayBuckGorundSound(int bgsNumber)
    {
        backGroundSource.clip = backGroundSoundList[bgsNumber];
        backGroundSource.Play();
        Debug.Log($"BGMを鳴らします ({backGroundSource.clip.name})");
    }

    /// <summary>
    /// AudioClipからBGSを鳴らす関数
    /// </summary>
    /// <param name="clip">BGSのAudioClip</param>
    public void PlayBuckGorundSound(AudioClip clip)
    {
        backGroundSource.clip = clip;
        backGroundSource.Play();
        Debug.Log($"BGMを鳴らします ({backGroundSource.clip.name})");
    }

    // 流れているBGSを止める
    public void StopBackGroundSound()
    {
        backGroundSource.Stop();
        Debug.Log("BGSを停止しました");
    }

    // 流れている全ての音を止める
    public void StopAllSound()
    {
        for (var i = 0; i < soundEffectSourcesList.Length; i++)
        {
            soundEffectSourcesList[i].Stop();
        }
        backGroundSource.Stop();
        Debug.Log("全ての音を停止しました");
    }

}
