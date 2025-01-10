using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManeger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public sound[] clip;
    public static audioManeger Instance;
   

    private void Awake()
    {
        if (Instance == null)
        {
           
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // slider.value = audioSource.volume;
       
    }
    public void playSound(soundName name)
    {
        foreach (var item in clip)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.num);
                break;
            }

        }
    }
    public void soundMute(bool val)
    {
        audioSource.mute = val;
    }
    public void muteUnmute()
    {
        audioManeger.Instance.playSound(soundName.click);
        audioSource.mute = !audioSource.mute;
    }
    public void volumeInceDec()
    {
      
      
    }
}
[System.Serializable]
public class sound
{
    public soundName name;
    public AudioClip num;
}
public enum soundName
{
    click,
   gameOver,
    move,
    blas
   
}
