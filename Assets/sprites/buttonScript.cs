using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Sprite activeSprite;
    [SerializeField] private Sprite unactiveSprite;
    private Image image;
    private bool isoff = true;
 
    void Start()
    {
        image = GetComponent<Image>();
        activeSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeSprite()
    {
        if (isoff)
        {
            image.sprite = unactiveSprite;
            isoff = false;

        }
        else
        {
            image.sprite = activeSprite;
            isoff = true;

        }
    }
   
}
