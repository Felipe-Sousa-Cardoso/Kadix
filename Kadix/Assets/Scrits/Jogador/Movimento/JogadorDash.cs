using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorDash : MonoBehaviour
{
    JogadorMovimento JoggMovimento;
    void Start()
    {
        JoggMovimento = GetComponent<JogadorMovimento>(); //recebe o componente que contem as variáveis 
        InputManager.Instancia.Input_JogadorMovimentoDash.performed += InputDash;
    }

    void InputDash(InputAction.CallbackContext context) //Faz com que o pulo comece
    {

    }
}
