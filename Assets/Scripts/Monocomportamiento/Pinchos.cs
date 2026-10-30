using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public int dañitos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            IDañables dañable = other.GetComponent<IDañables>();
            if (dañable != null)
            {
                dañable.RecibirDaño(dañitos);
            }
        }
    }
}
