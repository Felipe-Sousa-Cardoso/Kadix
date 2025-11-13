using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorAnimações : MonoBehaviour
{
    JogadorControladorMovimento Joggmovimento;
    void Start()
    {
        Joggmovimento = GetComponent<JogadorControladorMovimento>();
        InputManager.Instancia.Input_JogadorMovimentoBasico.performed += AlterarDireçao;
    }

    void AlterarDireçao(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input.x != Joggmovimento.DireçaoDoJogador)
        {
            if (input.x > 0)
            {
                Joggmovimento.DireçaoDoJogador = 1;
            }
            else if (input.x < 0)
            {
                Joggmovimento.DireçaoDoJogador = -1;
            }
        }                
    }
    void OnDestroy()
    {
        if (InputManager.Instancia != null)
            InputManager.Instancia.Input_JogadorMovimentoBasico.performed -= AlterarDireçao;
    }
}
