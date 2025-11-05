using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorPuloDuplo : MonoBehaviour, Interfaces.IPulo
{
    JogadorMovimento JoggMovimento;
    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float timerPulo; //Altura atual do pulo em tempo

    bool puloDuploDisponivel = true;
    
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>();
    }
    public bool PodePular()
    {
        return puloDuploDisponivel && !JoggMovimento.NoChao;
    }

    public void ExecutarPulo()
    {
        print("Pulo duplo");
    }
    /*
    void InputPuloPressionado(InputAction.CallbackContext context) //Faz com que o pulo comece
    {
        if (!JoggMovimento.NoChao&& puloDuploDisponivel)
        {
            isJump = true;
            puloDuploDisponivel=false;
        }
    }
    void InputPuloConcluido(InputAction.CallbackContext context) //Se ele está pulando encerra o pulo
    {
        if (isJump)
        {
            puloConcluido();
        }
    }
    // Update is called once per frame
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
                puloConcluido();
            }
        }
        if (JoggMovimento.NoChao && !puloDuploDisponivel)
        {
            puloDuploDisponivel = true;
        }
    }
    void FixedUpdate()
    {
        if (isJump)
        {
            JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, 5); //Executa a física do pulo
        }
    }
    void puloConcluido()
    {
        isJump = false; //para de pular
        timerPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.1f); //freia bruscamente o jogador 
    }
    */

}
