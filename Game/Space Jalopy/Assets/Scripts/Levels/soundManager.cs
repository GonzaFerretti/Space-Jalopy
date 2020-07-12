using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum SFX
{
    damage_taken = 0,
    damage_taken_2 = 1,
    enemy_dead = 2,
    hover_optionmenu = 3,
    laser = 4,
    laser_2 = 5,
    part_broken = 6,
    repair_fail = 7,
    repair_ok = 8,
    select_option_menu = 9,
}

public enum BGM
{
    Menu = 0,
    Stage = 1,
}
public class soundManager : MonoBehaviour
{
    private float bgmMasterVolume = 1, sfxMasterVolume = 1;
    private AudioSource[] sources;
    public AudioMixerGroup amg;
    [Header("BGM")]
    public AudioClip[] bgms;
    [Range(0, 1)]
    public float[] bgmVolumes;
    [Header("SFX")]
    public AudioClip[] sfxs;
    [Range(0, 1)]
    public float[] sfxVolumes;

    public void StopBGM()
    {
        sources[0].Stop();
    }

    public void stopAllSfx()
    {
        for (int i = 1; i < sources.Length; i++)
        {
                sources[i].Stop();
        }
    }

    public float getVolumeLevels(bool isBGM)
    {
        float volume;
        return volume = (isBGM) ? bgmMasterVolume : sfxMasterVolume;
    }

    public void updateVolumeLevels(bool isBGM, float finalVolume)
    {
        if (isBGM)
        {
            bgmMasterVolume = finalVolume;
            sources[0].volume = bgmVolumes[getSoundId(0,bgms)] * bgmMasterVolume;
        }
        else
        {
            sfxMasterVolume = finalVolume;
            adjustCurrentSfxVolume();
        }
    }

    private void adjustCurrentSfxVolume()
    {
        for (int i = 1; i < sources.Length; i++)
        {
            sources[i].volume = sfxVolumes[getSoundId(i, sfxs)] * sfxMasterVolume;
        }
    }

    public void PauseAll()
    {
        for (int i = 0; i < sources.Length; i++)
        {
                if (sources[i].isPlaying)
                { 
                sources[i].Pause();
                }
        }
    }

    public int getSoundId(int sourceId, AudioClip[] clips)
    {
        int id = 1;
        for (int i = 0; i < clips.Length; i++)
        {
            if (sources[sourceId].clip == clips[i])
            {
                id = i;
            }
        }
        return id;
    }
    public void ResumeAll()
    {
        for (int i = 0; i < sources.Length; i++)
        {
                sources[i].UnPause();
        }
    }

    public void stopSFX(SFX sfx)
    {
        foreach (AudioSource As in sources)
        {
            if (As.isPlaying && As.clip == sfxs[(int)sfx])
            {
                As.Stop();
            }
        }
    }
    public bool isPlayingSFX(SFX sfx)
    {
        bool isPlaying = false;
        foreach (AudioSource As in sources)
        {
            isPlaying = As.isPlaying && As.clip == sfxs[(int)sfx];
            if (isPlaying) break;
        }
        return isPlaying;
    }

    public AudioClip GetCurrentSFX()
    {
        return sources[1].clip;
    }

    public void Play(SFX sfx)
    {
        int availableAsIndex = getAvailableAudioSourceIndex(sfx);
        if (availableAsIndex != -1)
        {
            sources[availableAsIndex].volume = sfxVolumes[(int)sfx] * sfxMasterVolume;
        sources[availableAsIndex].clip = sfxs[(int)sfx];
        sources[availableAsIndex].Play();
        }
        else
        {
            createNewSource();
            int newIndex = getAvailableAudioSourceIndex(sfx);
            sources[newIndex].volume = sfxVolumes[(int)sfx] * sfxMasterVolume;
            sources[newIndex].clip = sfxs[(int)sfx];
            sources[newIndex].Play();
        }
    }
    public void Play(BGM bgm)
    {
        if (bgms[(int)bgm] != sources[0].clip)
        {
        sources[0].volume = bgmVolumes[(int)bgm] * bgmMasterVolume;
        sources[0].clip = bgms[(int)bgm];
        sources[0].Play();
        }
    }



    void Awake()
    {
        sources = GetComponents<AudioSource>();  
    }
    

    int getAvailableAudioSourceIndex(SFX sfx)
    {
        int availableSourceIndex = -1;
        for (int i = 1; i <sources.Length; i++)
        {
            if(!sources[i].isPlaying || sources[i].clip == sfxs[(int)sfx])
            {
                availableSourceIndex = i;
                break;
            }
        }
        return availableSourceIndex;
    }

    void createNewSource()
    {
        AudioSource newAs = gameObject.AddComponent<AudioSource>();
        newAs.outputAudioMixerGroup = amg;
        sources = GetComponents<AudioSource>();
    }
}
