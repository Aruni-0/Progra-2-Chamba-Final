using System.Collections;
using UnityEngine;

public class ControladorGeneral : MonoBehaviour
{
    public FaseDia faseActual;
    [SerializeField] private float tiempoDeCambio;
    private Coroutine corrutinita;
    public OleadasControlador spawner;

    private void Start()
    {
        faseActual = FaseDia.Noche;
        StartCoroutine(CambioCiclo());
    }

    private IEnumerator CambioCiclo()
    {
        if (faseActual == FaseDia.Dia)
        {
            faseActual = FaseDia.Noche;
            Debug.Log("Ahora es de noche");
            StartCoroutine(spawner.SpawnOleada());
        }
        else if (faseActual == FaseDia.Noche)
        {
            faseActual = FaseDia.Dia;
            Debug.Log("Ahora es de dia");
            spawner.SpawnEsporadico();
        }
        yield return new WaitForSeconds(tiempoDeCambio);

        yield return StartCoroutine(CambioCiclo());
    }
}
