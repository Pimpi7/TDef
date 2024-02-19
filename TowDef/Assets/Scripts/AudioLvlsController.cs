using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLlvsUI : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource buttonPress;

    public void playSound() 
    {
        buttonPress.Play();
    }

}
