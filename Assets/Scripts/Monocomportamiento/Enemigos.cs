using UnityEngine;

public class Enemigos : MonoBehaviour, IDañables
{
    public int vida;

    private void Update()
    {

    }

    public void RecibirDaño(int dañitos)
    {
        vida = vida - dañitos;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
