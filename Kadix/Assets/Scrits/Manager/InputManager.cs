using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instancia;

    public InputAction InputA_jogadorMovimento;
    public InputAction Input_JogadorMovimentoPulo;

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

        InputA_jogadorMovimento = InputSystem.actions.FindAction("Movimento");
        Input_JogadorMovimentoPulo = InputSystem.actions.FindAction("Pulo");
    }

   
}
