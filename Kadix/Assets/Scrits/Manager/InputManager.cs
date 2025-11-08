using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instancia;

    public InputAction Input_jogadorMovimentoBasico;
    public InputAction Input_JogadorMovimentoPulo;
    public InputAction Input_JogadorMovimentoDash;

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

        Input_jogadorMovimentoBasico = InputSystem.actions.FindAction("Movimento");
        Input_JogadorMovimentoPulo = InputSystem.actions.FindAction("Pulo");
        Input_JogadorMovimentoDash = InputSystem.actions.FindAction("Dash");
    }

   
}
