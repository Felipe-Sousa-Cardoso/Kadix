using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorDash : MonoBehaviour
{
    JogadorControladorMovimento JoggMovimento;
    float duraçãoDash = 0.2f;

    [SerializeField] float timerDash;

    bool isDashig; //Usada para trocar o estado do jogador apenas 1 vez
    bool podeDash = true; //Usada para evitar vários dahss simultaneos

    void Start()
    {
        JoggMovimento = GetComponent<JogadorControladorMovimento>(); //recebe o componente que contem as variáveis 
        InputManager.Instancia.Input_JogadorMovimentoDash.performed += InputDash;
    }

    void InputDash(InputAction.CallbackContext context) //Faz com que o dash  comece
    {
        if ( podeDash)
        {
            JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.paradoNoAr; //troca o estado para desativar a gravidade

            JoggMovimento.Rb.linearVelocity = Vector2.zero; //Zera o movimento do jogador

            if (JoggMovimento.EncostandoNaParede) //Se ele está encostando na parede ele vira o jogador
            {
                JoggMovimento.DireçaoDoJogador = -JoggMovimento.DireçaoDoJogador;
            }
   
            JoggMovimento.Rb.AddForce(new Vector2(JoggMovimento.DireçaoDoJogador * 8, 0), ForceMode2D.Impulse); //Exetuta o dash propriamente dito
            timerDash = duraçãoDash;

            isDashig = true;
            podeDash = false;
        }      
    }

    private void Update()
    {
        if (JoggMovimento.EncostandoNaParede&&timerDash<0.15f) //Faz com que o dash termine caso o jogador bata na parede mas não impeçaa ele de começar
        {
            timerDash = 0;
        }

        if (timerDash > 0) //se o dash ainda não acabou decresse o timer
        {
            timerDash-=Time.deltaTime;
        }
        else if (isDashig) //Executa somente 1 vez, quando o dash acaba
        {
            isDashig=false;
            JoggMovimento.JogadorEstado = JogadorControladorMovimento.JogadorEstados.normal;
        }
     
        if ((JoggMovimento.NoChao||JoggMovimento.EncostandoNaParede )&& !podeDash) //recarrega o dash se ele encostar na parede ou no chão
            {
                podeDash=true;
            }
    }
}
