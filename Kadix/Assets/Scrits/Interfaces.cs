using UnityEngine;

public class Interfaces : MonoBehaviour
{
    public interface IPulo
    {
        bool PodePular();
        void ExecutarPulo();
        void CancelarPulo();
    }
}
