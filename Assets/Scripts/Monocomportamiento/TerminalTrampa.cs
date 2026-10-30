using System.Collections;
using UnityEngine;

public class TerminalTrampa : MonoBehaviour, IInteractuable
{
    [SerializeField] private GameObject trampa;
    [SerializeField] private int daño;
    [SerializeField] private float tiempoActivo;
    [SerializeField] private bool trampaActiva;

    public void Interactuar()
    {
        if (!trampaActiva)
        {
            Debug.Log("Terminal Tocada");
            ActivarTrampa();
        }
    }

    private void ActivarTrampa()
    {
        StartCoroutine(Temporizador());
    }

    private IEnumerator Temporizador()
    {
        trampa.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(tiempoActivo);
        trampa.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Trampa Apagada " + tiempoActivo + " segundos");
    }
}
