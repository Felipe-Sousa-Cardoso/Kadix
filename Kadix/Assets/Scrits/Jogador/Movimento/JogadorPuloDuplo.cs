using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorPuloDuplo : MonoBehaviour, Interfaces.IPulo
{
    JogadorControladorMovimento JoggMovimento;
    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float timerPulo; //Altura atual do pulo em tempo

    bool puloDuploDisponivel = true;
    
    void Start()
    {
        JoggMovimento = GetComponent<JogadorControladorMovimento>();
    }
    public bool PodePular()
    {
        return puloDuploDisponivel && !JoggMovimento.NoChao;
    }
    public void ExecutarPulo()
    {
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocityX, 0);
        JoggMovimento.Rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        isJump = true;
        puloDuploDisponivel = false;
    }
    public void CancelarPulo()
    {
        PuloConcluido();
    }
    void PuloConcluido()
    {
        isJump = false; //para de pular
        timerPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.1f); //freia bruscamente o jogador 
    }
    void Update()
    {
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
        if ((JoggMovimento.NoChao || JoggMovimento.EncostandoNaParede )&& !puloDuploDisponivel) //recarrega o pulo duplo se está encostando no chão ou na parede
        {
            puloDuploDisponivel = true;
        }
    }    
}
