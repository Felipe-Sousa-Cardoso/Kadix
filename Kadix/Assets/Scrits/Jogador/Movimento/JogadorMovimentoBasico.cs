using UnityEngine;

public class JogadorMovimentoBasico : MonoBehaviour
{
    JogadorControladorMovimento JoggMovimento;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorControladorMovimento>(); //recebe o componente que contem as variáveis 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (JoggMovimento.JogadorEstado)
        {
            case JogadorControladorMovimento.JogadorEstados.normal:
                if (JoggMovimento.Rb.gravityScale != 2)
                {
                    JoggMovimento.Rb.gravityScale = 2;
                }
                JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.MoveInput.x * JoggMovimento.Velocidade, JoggMovimento.Rb.linearVelocityY);  //Movimento basico, sem aceleração                print("saiu");
                break;

            case JogadorControladorMovimento.JogadorEstados.semInputX:
                if(JoggMovimento.Rb.gravityScale != 2)
                {
                    JoggMovimento.Rb.gravityScale =2;
                }
                break;

            case JogadorControladorMovimento.JogadorEstados.paradoNoAr:
                if (JoggMovimento.Rb.gravityScale !=0)
                {
                    JoggMovimento.Rb.gravityScale = 0;
                }
                JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, 0);  //mantém apenas o deslocamento horizontal, sem o input no x
                break;
        }
       
    }
}
