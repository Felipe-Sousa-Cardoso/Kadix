using UnityEngine;

public class JogadorPulaDaBeirada : MonoBehaviour, Interfaces.IPulo
{
    JogadorMovimento JoggMovimento;
    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float timerPulo; //Altura atual do pulo em tempo
    public void CancelarPulo()
    {
        PuloConcluido();
    }

    public void ExecutarPulo()
    {
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocityX, 0); //Zera a movimentação do jogador para evitar conflito
        JoggMovimento.JogadorEstado = JogadorMovimento.JogadorEstados.puloBeirada; //Muda o estado do jogador para não conflitar com o pulo na beirada
        JoggMovimento.Rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);//Pulo propriamente dito
        isJump = true;
        print("beirada");
    }

    public bool PodePular()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,0.2f), Vector2.right * JoggMovimento.DireçaoDoJogador, 0.25f, JoggMovimento.layerChao);
        //verifica se o jogador está proximo da parede e se movimentando em direção a ela

        return !hit && JoggMovimento.EncostandoNaParede;
    }
    void PuloConcluido()
    {
        isJump = false; //para de pular
        timerPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.1f); //freia bruscamente o jogador 
        JoggMovimento.JogadorEstado = JogadorMovimento.JogadorEstados.normal;
    }

    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.2f,0), Vector2.right * JoggMovimento.DireçaoDoJogador, 0.25f, JoggMovimento.layerChao); 
        //verifica se o jogador está proximo da parede e se movimentando em direção a ela
        Color cor = hit ? Color.green : Color.red;
        Debug.DrawRay(transform.position + new Vector3(0, 0.2f, 0), Vector2.right * JoggMovimento.MoveInput.x * 0.25f, cor);
    }
}
