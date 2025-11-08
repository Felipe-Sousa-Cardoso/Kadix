using UnityEngine;

public class JogadorPularDaParede : MonoBehaviour, Interfaces.IPulo
{
    JogadorMovimento JoggMovimento;

    float timerMenorPulo; //Tempo minimo de pulo
    float timerMaiorPulo; //Tempo máximo de pulo

    bool pulando;

    public bool PodePular()
    {
        return JoggMovimento.EncostandoNaParede;
    }
    public void ExecutarPulo()
    {
        pulando = true;
        timerMenorPulo = 0.2f;
        timerMaiorPulo = 0.2f;
        JoggMovimento.JogadorEstado = JogadorMovimento.JogadorEstados.semInputX;
        JoggMovimento.Rb.AddForce(new Vector2 (-JoggMovimento.DireçaoDoJogador*2 ,8), ForceMode2D.Impulse);
    }
    public void CancelarPulo()
    {
        pulando = false;
    }
    void PuloConcluido()
    {
        JoggMovimento.JogadorEstado = JogadorMovimento.JogadorEstados.normal;
    }

    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
    }
    void Update()
    {
        if (timerMenorPulo > 0) //se ainda resta tempo minimo decresse
        {
            timerMenorPulo-=Time.deltaTime;
        }
        else 
        {
            if (timerMaiorPulo > 0)//se ainda resta tempo máximo decresse
            {
                timerMaiorPulo -= Time.deltaTime;
            }
        
            if (!pulando|| timerMaiorPulo<0) //Se o jogador apertou qualquer input 
            {
                PuloConcluido();
            }
               
        }

    }
}
