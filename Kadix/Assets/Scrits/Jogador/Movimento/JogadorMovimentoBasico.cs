using UnityEngine;

public class JogadorMovimentoBasico : MonoBehaviour
{
    JogadorMovimento JogMovimento;
    void Start()
    {
        JogMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
        JogMovimento.Rb.linearVelocity = new Vector2 (JogMovimento.MoveInput.x * JogMovimento.Velocidade, JogMovimento.Rb.linearVelocityY);  //Movimento basico, sem aceleração
    }
}
