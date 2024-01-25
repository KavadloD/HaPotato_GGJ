using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetecton : MonoBehaviour
{

    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    public float AudioThresh;
    public bool CakeTriggerer;
    public float volume;

    private void Start()
    {
        MicrophoneToAudio();
    }

    public void MicrophoneToAudio()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
      
        int startPos = clipPosition - sampleWindow;
        
        if (startPos < 0)
            return 0;
        
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPos);
        
        //compute loudness 
         

        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        //current way finds the mean of the audio  it compares the total loudness with the length of the sample
        Debug.Log("Total Loudness Detected "+ totalLoudness/sampleWindow);
        volume=  totalLoudness / sampleWindow;
        return volume; 

    }
    
}
