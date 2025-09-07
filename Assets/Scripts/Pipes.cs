using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Speed at which the pipes move to the left
    public float movementSpeed = 5f;

    private float leftBound;


    //In the start method, we will calculate the left bound of the screen
    //we will use this to destroy the pipes when they go off screen
    void Start()
    {
        leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    //In the update method, we will move the pipes to the left
    //and check if they have gone off screen, if they have we will destroy them
    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
