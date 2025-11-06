using UnityEngine;

public class JogadorPularDaParede : MonoBehaviour, Interfaces.IPulo
{
    JogadorMovimento JoggMovimento;

    float timerPulo; //Usado para voltar o estado normal do jogador
    public bool PodePular()
    {
        return JoggMovimento.EncostandoNaParede;
    }
    public void ExecutarPulo()
    {
        print("pulo da parede");
        timerPulo = 0.2f;
        JoggMovimento.JogadorEstado = JogadorMovimento.jogadorEstados.dash;
        JoggMovimento.Rb.AddForce(new Vector2 (-JoggMovimento.MoveInput.x*2 ,8), ForceMode2D.Impulse);
    }
    public void CancelarPulo()
    {
        //puloConcluido();
    }
    void puloConcluido()
    {
        JoggMovimento.JogadorEstado = JogadorMovimento.jogadorEstados.normal;
    }

    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
    }
    void Update()
    {
        if (timerPulo > 0)
        {
            timerPulo-=Time.deltaTime;
        }
        else 
        {
            puloConcluido();
        }

    }
}
