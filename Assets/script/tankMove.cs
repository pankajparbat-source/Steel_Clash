using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class tankMove : MonoBehaviour
{
    public static tankMove Instance;
    [SerializeField] private Animator animator;
    float timeofSpawnBall = 0f;
    // Start is called before the first frame update
    [SerializeField] GameObject fire;
    [SerializeField] GameObject chiled;
    [SerializeField] Text livescore;
    [SerializeField] Text currentscore;
    [SerializeField] Text highrscore;
    int scor=0;
    Vector2 lowerLimit;
    Vector2 upperLimit;
    GameObject ball1;
    bool isCoroutineRunning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    void Start()
    {
      
    }

    void Update()
    {
        upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y));

        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                timeofSpawnBall += Time.deltaTime;
                Move();
            }
           
        }
    }

    void Move()
    {
        Vector3 mouseposion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposion.x, transform.position.y);

        if (transform.position.y == upperLimit.y || transform.position.y == lowerLimit.y || transform.position.x == upperLimit.x || transform.position.x == lowerLimit.x)
        {
            Destroy(ball1);
        }

        if (timeofSpawnBall > .03f && !isCoroutineRunning)
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }
    //this is pankaj
    IEnumerator SpawnBallWithDelay()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(0.3f); // Change this to your desired delay time

        ball1 = Instantiate(fire, chiled.transform.position + chiled.transform.up, Quaternion.identity);
        Rigidbody2D rb = ball1.AddComponent<Rigidbody2D>();
        rb.velocity = (chiled.transform.up) * 20f;
        rb.mass = 50f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        timeofSpawnBall = 0f;
        isCoroutineRunning = false;
    }
   public void scoreMethod(int val)
    {
        scor += val;
        livescore.text = scor.ToString();
        Debug.Log("score is " + livescore.text);
        currentscore.text = scor.ToString();

        int highScore = PlayerPrefs.GetInt("score", scor); // Get stored high score or default to 0
        if (scor > highScore)
        {
            PlayerPrefs.SetInt("score", scor); // Save new high score
            highrscore.text = scor.ToString();
        }
        else
        {
            highrscore.text = highScore.ToString(); // Display current high score
        }
    }
    public void blastTank()
    {
        audioManeger.Instance.playSound(soundName.blas);
        animator.SetTrigger("blastTank");
      
    }
    public void destroyTank()
    {

        CameraShake.instance.Shake();
        CanvasBounceAnimation.instance.StartBounceAnimation();
        Destroy(gameObject);
        
        audioManeger.Instance.playSound(soundName.gameOver);
        UiManeger.Instance.gameOver();
    }

}
