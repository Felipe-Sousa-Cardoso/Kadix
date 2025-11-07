using UnityEngine;

public class JogadorMovimentoBasico : MonoBehaviour
{
    JogadorMovimento JoggMovimento;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (JoggMovimento.JogadorEstado)
        {
            case JogadorMovimento.JogadorEstados.normal:
                JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.MoveInput.x * JoggMovimento.Velocidade, JoggMovimento.Rb.linearVelocityY);  //Movimento basico, sem aceleração
                break;

            case JogadorMovimento.JogadorEstados.semInputX:
                break;

            case JogadorMovimento.JogadorEstados.paradoNoAr:
                JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, 0);  //mantém apenas o deslocamento horizontal, sem o input no x
                break;
        }
       
    }
}
