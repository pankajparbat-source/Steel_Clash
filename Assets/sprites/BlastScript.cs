using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour
{
    public static BlastScript Instance; 

    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    
   public void Blastbomb(Vector2 position) 
    {
        Instantiate(gameObject,position,Quaternion.identity);
        transform.position = position;
       
        animator.SetTrigger("blast");

    }
    public void objectDisable()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);

    }
}
