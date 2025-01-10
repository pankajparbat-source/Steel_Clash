using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject blast;
    Vector2 lowerLimit;
    Vector2 upperLimit;
    [SerializeField] private BlastScript blastScript;
  //  [SerializeField] private GameObject blast;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
          if (collision.gameObject.CompareTag("tank"))
        {
          
          //  Destroy(collision.gameObject);
            tankMove.Instance.blastTank();
           
          
           
        }
    }
    IEnumerator DestroyHoleAfterDelay( float delay)
    {
        yield return new WaitForSeconds(delay);
       
    }
}
