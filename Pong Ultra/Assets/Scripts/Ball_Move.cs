using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class Ball_Move : MonoBehaviour
{ 
    List<Transform> balls;               //varianble for balls
    public Transform bodyPrefab;            //variable to generate balls

    //variable for speed
    public float xSpeed = 0; //variable for horizontal speed
    public float ySpeed = 0; //variable for vertical speed

    //variable for borders
    private float xBorder = 30f; //variable for horizontal border
    private float yBorder = 15f; //variable for vertical border

    //variable for move state
    public bool xMove = true;
    public bool yMove = true;

    //variables for score
    int playerOneScore;
    public Text scoreTextP1;

    int playerTwoScore;
    public Text scoreTextP2;

    public BoxCollider2D grid;     

    private void RandomPos()
    {
        Bounds bounds = grid.bounds;                                                //declare the limits of the space

        float x = Random.Range(bounds.min.x, bounds.max.x);                         //give a random value to x within the limit
        float y = Random.Range(bounds.min.y, bounds.max.y);                         //give a random value to y within the limit

        Transform balls = Instantiate(this.bodyPrefab);
        balls.position = new Vector2(Mathf.Round(x), Mathf.Round(y));           //round values, change position of the ball
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            RandomPos();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 1f;   //declare value for horizontal speed
        ySpeed = 1f;   //declare value for vertical speed
    
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        if (xMove == true)
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y); //move right
        }else
        {
            transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y); //move left
        }

        if (transform.position.x >= xBorder)
        {
            xMove = false;
            playerOneScore += 1;
            Debug.Log(playerOneScore); 
        }

        if (transform.position.x <= -xBorder)
        {
            xMove = true;
            playerTwoScore += 1;
            Debug.Log(playerTwoScore);
        }

        //vertical movement
        if (yMove == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + ySpeed); //move up
        }else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - ySpeed);   //move down
        }
       
        if (transform.position.y >= yBorder)
        {
            yMove = false;
        }

        if (transform.position.y <= -yBorder)
        {
            yMove = true;
        }

        scoreTextP1.text = playerOneScore.ToString();

        scoreTextP2.text = playerTwoScore.ToString();

        //function to randomize the position of the the food


        Debug.Log("Goal");
    }

    void OnCollisionEnter2D(Collision2D collision) //when a collision happens
    {
     
        if (collision.collider.CompareTag("Player"))
        {
            if (xMove == true)
            {
                xMove = false;
            }
            else if (xMove == false)
            {
                xMove = true;
            }
        }

        

        if (playerOneScore >= 10)
        {
            SceneManager.LoadScene("EndScene"); //chage to the end scene
            SceneManager.LoadScene("GameScene"); //restart the game
        }

        if (playerTwoScore >= 10)
        {
            SceneManager.LoadScene("EndScene"); //chage to the end scene
            SceneManager.LoadScene("GameScene"); //restart the game
        }
    }


   }







   


