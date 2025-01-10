using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDEtection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject blast; 
  //  [SerializeField] private List<Sprite> newSprites;
    [SerializeField] private List<GameObject> newGameObject;
    Vector2 upperLimit;
    Vector2 lowerLimit;
    [SerializeField] private BlastScript blastScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y));
        if (transform.position.y == upperLimit.y || transform.position.y == lowerLimit.y || transform.position.x == upperLimit.x || transform.position.x == lowerLimit.x)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb-1"))
        {
            // 

            //wholeMove.Instance.EmptyList();
           // animator.SetTrigger("blast");
            wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            tankMove.Instance.scoreMethod(1);
            Vector2 vector2 = (collision.gameObject.transform.position + transform.position) / 2;
            Debug.Log("this method call");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            audioManeger.Instance.playSound(soundName.blas);
            blastScript.Blastbomb(vector2);
            CameraShake.instance.Shake();


        }
        else if (collision.gameObject.CompareTag("bomb-2"))
        {
            // collision.gameObject.GetComponent<SpriteRenderer>().sprite = newSprites[0];
            // collision.gameObject.tag = newSprites[0].name;
            //      Destroy(gameObject);


            Vector2 vector2 = (collision.gameObject.transform.position+transform.position) / 2;           
            Destroy(gameObject);
            Destroy(collision.gameObject);
            wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            GameObject newObject1 = Instantiate(newGameObject[0], vector2, Quaternion.identity);
            wholeMove.Instance.spawnedBall.Add(newObject1);
            // wholeMove.Instance.spawnedBall.Remove(collision.gameObject);

            tankMove.Instance.scoreMethod(1);
          
            
        }
        else if (collision.gameObject.CompareTag("bomb-3"))
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sprite = newSprites[1];
            //collision.gameObject.tag = newSprites[1].name;
            //Destroy(gameObject);

            Vector2 vector2 = (collision.gameObject.transform.position + transform.position) / 2;          
            Destroy(gameObject);  
            Destroy(collision.gameObject);
            wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            GameObject newObject1 = Instantiate(newGameObject[1], vector2, Quaternion.identity);
            wholeMove.Instance.spawnedBall.Add(newObject1);
            //  wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            tankMove.Instance.scoreMethod(3);
        
        }
        else if (collision.gameObject.CompareTag("bomb-4"))
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sprite = newSprites[2];
            //collision.gameObject.tag = newSprites[2].name;
            //Destroy(gameObject);


            Vector2 vector2 = (collision.gameObject.transform.position + transform.position) / 2;           
            Destroy(gameObject);      
            Destroy(collision.gameObject);
            wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            GameObject newObject1 = Instantiate(newGameObject[2], vector2, Quaternion.identity);
            wholeMove.Instance.spawnedBall.Add(newObject1);
            //  wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
            tankMove.Instance.scoreMethod(5);
          
        }
        else if (collision.gameObject.CompareTag("bomb-5"))
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sprite = newSprites[3];
            //collision.gameObject.tag = newSprites[3].name;
            //Destroy(gameObject);

            Vector2 vector2 = (collision.gameObject.transform.position + transform.position) / 2;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            wholeMove.Instance.spawnedBall.Remove(collision.gameObject);
           GameObject newObject1= Instantiate(newGameObject[3], vector2, Quaternion.identity);
            wholeMove.Instance.spawnedBall.Add(newObject1);
            tankMove.Instance.scoreMethod(5);
         
        }
        else if (collision.gameObject.CompareTag("collider"))
        {
           
            Destroy(gameObject);
           
        }
       
    }
}
