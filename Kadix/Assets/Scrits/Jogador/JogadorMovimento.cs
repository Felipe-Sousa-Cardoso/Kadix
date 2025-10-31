using UnityEngine;

public class JogadorMovimento : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(InputManager.GetInput_jogadorMovimento().x,InputManager.GetInput_jogadorMovimento().y)*0.2f;
    }
}
