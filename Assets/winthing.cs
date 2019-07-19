using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class winthing : MonoBehaviour
{
    public AudioClip winclip;

    public AudioSource winsong;

    public Text winText;

    void Start()
    {
        GetComponent<PlayerController>().winEvent.AddListener(PlayWhenWin);
        winText.text = ""; 
    }

    private void PlayWhenWin()
    {   
        winText.text = "You Win!";
        winsong.Stop();
        winsong.clip = winclip; 
        winsong.Play(); 
        Time.timeScale = 0f; 
    }
}
