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
    public Vector2 Input_jogadorMovimento;
    public void OnMovimento(InputValue input)
    {
        Input_jogadorMovimento = input.Get<Vector2>();
    }

    public static Vector2 GetInput_jogadorMovimento()
    {
        return Instancia.Input_jogadorMovimento;
    }
}
