using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mutunmute()
    {
        audioManeger.Instance.playSound(soundName.click);
        audioSource.mute = !audioSource.mute;
    }
}
