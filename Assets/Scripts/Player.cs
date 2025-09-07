using UnityEngine;
using FlappyBird;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    public Sprite[] spritesArray;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.81f;
    public float jumpStrenght = 5f;

    //This method is called when the script instance is being loaded
    // we will use it to get the sprite renderer component
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    //This method will detect player input and apply gravity to the player
    //we will also move the player based on the direction vector
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * jumpStrenght;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //This method will animate the player sprite by changing the sprite every 0.15 seconds
    //we will use the InvokeRepeating method to call this method every 0.15 seconds
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= spritesArray.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = spritesArray[spriteIndex];
    }

    //This method will detect collisions with obstacles and scoring objects
    //it will give us the indication of what we hit by checking the tag of the other object
    //if we hit an obstacle we will call the game manager to end the game
    //if we hit a scoring object we will call the game manager to increase the score
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            //we detected a collision with an obstacle so we call the game manager to end the game
            Vector3 postion = transform.position;
            postion.y = -3.2f;
            transform.position = postion;
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
        else if (other.gameObject.tag == "Scoring")
        {
            //we detected a collision with a scoring object so we call the game manager to increase the score
            gameManager.IncreaseScore();
            Debug.Log("Score");
        }
    }

    //This method is called when the object becomes enabled and active
    //we will use it to reset the player's position and direction
    //so the player starts from the same position every time we start the game
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
