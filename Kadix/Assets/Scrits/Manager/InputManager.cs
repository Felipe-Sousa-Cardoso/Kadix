using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instancia;

    public InputAction Input_JogadorMovimentoBasico;
    public InputAction Input_JogadorMovimentoPulo;
    public InputAction Input_JogadorMovimentoDash;
    public InputAction Input_JogadorAtaqueBasico;

    void Awake() //Verificação de unicidade
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(this);
        }

        Input_JogadorMovimentoBasico = InputSystem.actions.FindAction("Movimento");
        Input_JogadorMovimentoPulo = InputSystem.actions.FindAction("Pulo");
        Input_JogadorMovimentoDash = InputSystem.actions.FindAction("Dash");
        Input_JogadorAtaqueBasico = InputSystem.actions.FindAction("Ataque");
    }

   
}
