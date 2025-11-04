using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorPulo : MonoBehaviour
{
    JogadorMovimento JoggMovimento;

    bool isJump; //Verifica se o comando de pular foi dado, usado para altura do pulo e verificações
    float tempoPulo; //Altura do pulo em tempo

    float coyotetime = 0.05f;
    public float coyotetimer;
    float bufftime = 0.1f;
    public float bufftimer;
    bool puloAtivo;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis do Jogador

        InputManager.Instancia.Input_JogadorMovimentoPulo.started += InputPuloPressionado; //Inscreve nos input a ação de começar e finalizar o pulo
        InputManager.Instancia.Input_JogadorMovimentoPulo.canceled += InputPuloConcluido;
    }
    void InputPuloPressionado(InputAction.CallbackContext context) //Faz com que o pulo comece
    {
        bufftimer = bufftime;
        puloAtivo = true;
    }
    void InputPuloConcluido(InputAction.CallbackContext context) //Se ele está pulando encerra o pulo
    {
        puloAtivo = false;
        if (isJump) 
        {
            puloConcluido();
        } 
    }
    private void Update()
    {
        if (bufftimer > 0)
        {            
            bufftimer-=Time.deltaTime;
            if (coyotetimer > 0 & !isJump &puloAtivo)
            {
                isJump = true;
                bufftimer = 0;
            }
        }
        if (isJump & tempoPulo < JoggMovimento.AlturaDoPulo) //Se o jogador ainda está pulando e ainda não atingiu a altura máxima calcula o tempo
        {
            tempoPulo += Time.deltaTime;
        }
        if (isJump & tempoPulo>= JoggMovimento.AlturaDoPulo)
        {
            puloConcluido();
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
    void FixedUpdate()
    {
        if (isJump)
        {
            JoggMovimento.Rb.linearVelocity = new Vector2 (JoggMovimento.Rb.linearVelocity.x,5); //Executa a física do pulo
        }    
    }
    void puloConcluido()
    {
        isJump = false; //para de pular
        tempoPulo = 0; //Reseta para um novo pulo
        JoggMovimento.Rb.linearVelocity = new Vector2(JoggMovimento.Rb.linearVelocity.x, JoggMovimento.Rb.linearVelocity.y * 0.1f); //freia bruscamente o jogador 
    }
}
