using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	
	public int channelCount;
	public  IList<AudioSource> _channels;
	public AudioClip[] clips;

    void Awake()
    {
        channelCount = 10;
        _channels = new List<AudioSource>();
        for (int i = 0; i < channelCount; i++)
        {
            _channels.Add(this.gameObject.AddComponent<AudioSource>());
        }
    }

	public void PlaySound (int id,bool loop, float vol)
	{
		int c = FindChannel();
		if (c == -1)
		{
			return;
		}
		_channels[c].clip= clips [id];
        _channels[c].loop = loop;
        _channels[c].volume = vol;
		_channels[c].Play();
	}
    //We search an empty channel to set our sound
	public int FindChannel ()
	{
	    for (int i =0; i<channelCount;i++)
		{
            if (_channels[i] != null)
            {
                if (!_channels[i].isPlaying) return i;
            }
		}
		return -1;
	}
    //For pause
    public void StopSound()
    {
        foreach (AudioSource source in _channels)
        {
            source.mute = true;
        }

    }
    //For pause off
    public void ResumeSound()
    {
        foreach (AudioSource source in _channels)
        {
            if (source.isPlaying)
            {
                source.mute = false;
            }
        }
    }
    //For bulletTime
    public void ChangePitch()
    {
        foreach (AudioSource source in _channels)
        {
            if (source.isPlaying)
            {
                source.pitch = 0.70f;
            }
        }
    }
    //For BulletTime off
    public void ResumePitch()
    {
        foreach (AudioSource source in _channels)
        {
                source.pitch = 1f;
        }
    }
	
}
