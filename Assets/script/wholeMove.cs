using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wholeMove : MonoBehaviour
{
    public static wholeMove Instance;
    [SerializeField] private GameObject hole;
    [SerializeField] private List<GameObject> Spawnball;
    public List<GameObject> spawnedBall= new List<GameObject>(); 
    int value = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    private void Start()
    {
      //  Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        isEmpty();
    }


    void isEmpty()
    {
       
        if (spawnedBall.Count==0) {
            move();
        }
    }
    public void EmptyList()
    {
        spawnedBall.Clear();
    }

    void move()
    {
        float x = Random.Range(-1.81f, 1.6f);
        float y = Random.Range(2.12f, 3.96f);
       // Whole.transform.position = new Vector2(x, y);
        GameObject Whole = Instantiate(hole, new Vector3(x, y,0.1f), Quaternion.identity);


        if (value==1)
        {
            float offsetx = Random.Range(2f, 4f);
            float offsety = Random.Range(2f, 5f);
            GameObject ball = Instantiate(Spawnball[0],Whole.transform.position,Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(offsetx, offsety));

            spawnedBall.Add(ball);
            value++;
          //  Destroy(Whole);
          
            StartCoroutine(waitFor(.5f));
        }
       else if (value == 2)
        {
            for(int index=0;index<3;index++)
            {
                int offsetx = Random.Range(-3,3);
                int offsety = Random.Range(-3, 5);
              
                GameObject ball = Instantiate(Spawnball[index], Whole.transform.position, Quaternion.identity);

                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(offsetx,offsety)*50);

                spawnedBall.Add(ball);
                value++;
                StartCoroutine(waitFor(.5f));
            }
           // Destroy(Whole);
        }
        else
        {
            int indexofBall=Random.Range(1,Spawnball.Count);
            for(int index=indexofBall;index>indexofBall-3;index--)
            {
                if(index>=0)
                {
                    int offsetx = Random.Range(-3, 3);
                    int offsety = Random.Range(-3, 5);
                
                    GameObject ball = Instantiate(Spawnball[index], Whole.transform.position , Quaternion.identity);
                    ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(offsetx, offsety)*50);

                    spawnedBall.Add(ball);
                    StartCoroutine(waitFor(.5f));
                }
               
            }
           // Destroy(Whole);
        }
        StartCoroutine(DestroyHoleAfterDelay(Whole, 1.0f)); // De

    }
    IEnumerator DestroyHoleAfterDelay(GameObject holeToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(holeToDestroy);
    }
    IEnumerator waitFor( float delay)
    {
        yield return new WaitForSeconds(delay);
        
    }
}
