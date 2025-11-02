using UnityEngine;

public class JogadorPulo : MonoBehaviour
{
    JogadorMovimento JogMovimento;

    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float tempoPulo;
    void Start()
    {
        JogMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
    }

    private void Update()
    {
        if (JogMovimento.PuloInput&& tempoPulo < JogMovimento.AlturaDoPulo)
        {
            isJump = true;
            tempoPulo += Time.deltaTime;
        }
        else
        {
            isJump = false;
        }
    }
    void FixedUpdate()
    {
       if (isJump)
        {
            JogMovimento.Rb.AddForce(Vector2.up);
        }
    }
}
