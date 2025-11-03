using UnityEngine;

public class JogadorPulo : MonoBehaviour
{
    JogadorMovimento JogMovimento;

    public bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    public float tempoPulo;
    void Start()
    {
        JogMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
    }

    private void Update()
    {
        if (JogMovimento.MoveInput.y==1 && tempoPulo < JogMovimento.AlturaDoPulo)
        {
            isJump = true;
            tempoPulo += Time.deltaTime;
        }
        else
        {
            isJump = false;
            tempoPulo = 0;
            
        }
    }
    void FixedUpdate()
    {
        if (isJump)
        {
            JogMovimento.Rb.linearVelocity= new Vector2 (JogMovimento.Rb.linearVelocity.x,5);
        }
        
    }
}
