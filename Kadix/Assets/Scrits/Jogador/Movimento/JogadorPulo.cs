using UnityEngine;
using UnityEngine.InputSystem;
using static Interfaces;

public class JogadorPulo : MonoBehaviour, Interfaces.IPulo
{
    JogadorMovimento JoggMovimento;

    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float timerPulo; //Altura atual do pulo em tempo

    float coyotetime = 0.05f;
    float coyotetimer;
    float bufftime = 0.2f;
    float bufftimer; 
    public bool PodePular()
    {
        return true;
    }
    public void ExecutarPulo()
    {
        bufftimer = bufftime;
    }
    public void CancelarPulo()
    {
        PuloConcluido();
    }
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
    }

    private void Update()
    {
        if (bufftimer > 0)
        {            
            bufftimer-=Time.deltaTime;
            if (coyotetimer > 0 & !isJump)
            {
                isJump = true;
                JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocityX, 0);
                JoggMovimento.Rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
                bufftimer = 0;
            }
        }
        if (isJump) //Se o jogador ainda está pulando e ainda não atingiu a altura máxima calcula o tempo
        {          
            if (timerPulo < JoggMovimento.AlturaDoPulo)
            {
                timerPulo += Time.deltaTime;
            }
            else
            {
                PuloConcluido();
            }
        }

        if (JoggMovimento.NoChao) //Verificação do coyote time
        {
            coyotetimer = coyotetime;
        }
        else if(coyotetimer>0)
        {
            coyotetimer -= Time.deltaTime;
        }

    }
    void PuloConcluido()
    {
        isJump = false; //para de pular
        timerPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.1f); //freia bruscamente o jogador 
    }

 
}
