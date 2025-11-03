using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instancia;
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

    }
    
    Vector2 Input_jogadorMovimento; //movimento basico para os lados
    void OnMovimento(InputValue input)
    {
        Input_jogadorMovimento = input.Get<Vector2>();
    }
    public static Vector2 GetInput_jogadorMovimento()
    {
        return Instancia.Input_jogadorMovimento;
    }

    bool Input_JogadorMovimentoPulo; //Pulo
    void OnPulo(InputValue input)
    {
        Input_JogadorMovimentoPulo = input.isPressed;
    }
    public static bool GetInput_jogadorMovimentoPulo()
    {
        return Instancia.Input_JogadorMovimentoPulo;
    }

    private void LateUpdate()
    {
        Instancia.Input_JogadorMovimentoPulo = false;
    }
}
