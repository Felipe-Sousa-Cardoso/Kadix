using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorAnimações : MonoBehaviour
{
    JogadorMovimento Joggmovimento;
    void Start()
    {
        Joggmovimento = GetComponent<JogadorMovimento>();
        InputManager.Instancia.Input_jogadorMovimentoBasico.performed += AlterarDireçao;
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
            InputManager.Instancia.Input_jogadorMovimentoBasico.performed -= AlterarDireçao;
    }
}
