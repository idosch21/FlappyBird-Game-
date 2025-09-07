using UnityEngine;

public class Spawner : MonoBehaviour
{


    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    //This method is called when the object becomes enabled and active
    //we will start invoking the SpawnObject method repeatedly at the specified spawn rate
    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnObject), spawnRate, spawnRate);
    }

    //This method will instantiate a new prefab at the spawner's position
    //and we will add a random height offset to the y position of the prefab
    //to create variation in the spawning of the objects
    private void SpawnObject()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

    //This method is called when the behaviour becomes disabled or inactive
    //we will stop invoking the SpawnObject method
    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObject));
    }


}
