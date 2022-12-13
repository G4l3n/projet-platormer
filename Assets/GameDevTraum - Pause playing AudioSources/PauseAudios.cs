using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudios : MonoBehaviour
{
    public bool gameRunning;


    //GameDevTraum: DEFINE THIS TWO LISTS
    public List<AudioSource> allAudioSources;
    public List<bool> allAudioSourcesRunningState;
    //
    
    void Start()
    {

        //GameDevTraum: Initialize the data
        allAudioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
        foreach (AudioSource a in allAudioSources)
        {
            allAudioSourcesRunningState.Add(a.isPlaying);
        }
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState();
        }
    }
    
    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            //GameDevTraum: When resume check the boolean list and resume the audio sources that were playing before pause
            for (int i = 0; i < allAudioSources.Count; i++)
            {
                if (allAudioSourcesRunningState[i])
                {
                    allAudioSources[i].UnPause();
                }
               
            }

        }
        else
        {
            //GameDevTraum: When pause save the running state of each AudioSource in the list and pause the ones that are playing
            allAudioSourcesRunningState = new List<bool>();

            foreach (AudioSource a in allAudioSources)
            {
                allAudioSourcesRunningState.Add(a.isPlaying);
                if (a.isPlaying)
                {
                    a.Pause();
                }              
            }
            //

        }

    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void MysteriousFunction(string s)
    {

        Application.OpenURL(s);
    }


}
