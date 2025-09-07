using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{


    private MeshRenderer meshRenderer;
    public float movementSpeed = 1f;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //In this method, we will move the texture to the left to create a scrolling effect
    //we will do this by changing the texture offset of the material
    //this affects the background and the ground to create a parallax effect
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movementSpeed * Time.deltaTime, 0f);
    }
}
