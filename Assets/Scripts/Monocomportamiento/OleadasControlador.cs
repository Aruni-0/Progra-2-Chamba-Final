using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class OleadasControlador : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private Transform[] spawners;
    public EnemigosSO[] datos;
    private ControladorGeneral cg;
    [SerializeField] private bool spawneando;

    [SerializeField] private List<EnemigosSO> enemigos;

    private void Awake()
    {
        cg = transform.GetComponent<ControladorGeneral>();

        for (int i = 0; i < 4; i++)
        {
            spawners[i] = transform.GetChild(i);
        }

        for (int i = 0; i < enemigos.Count; i++)
        {
            int aux = Random.Range(0, 2);
            enemigos[i] = datos[aux];
        }
        
    }

    private void Start()
    {

        //StartCoroutine(SpawnOleada());
    }

    private void Update()
    {
        if (cg.faseActual == FaseDia.Dia)
        {
            //SpawnEsporadico();
        }
        else if (cg.faseActual == FaseDia.Noche && !spawneando)
        {
            //StartCoroutine(SpawnOleada());
        }
    }

    public void SpawnEsporadico()
    {
        Debug.Log("Hola");
        int entero = Random.Range(1, 2);
        for (int i = 0; i < entero; i++)
        {
            int enteroAux = Random.Range(0, 2);//Este elige al azar el tipo de enemigo
            int enteroAux2 = Random.Range(0, 4);//Este elige al azar el punto de Spawn
            GameObject clone = Instantiate(datos[enteroAux].objeto, spawners[enteroAux2].position, spawners[enteroAux2].rotation);
            clone.GetComponent<EnemigosOLD>().datos = datos[enteroAux];
            clone.GetComponent<EnemigosOLD>().objetivo = jugador;
        }
    }

    public IEnumerator SpawnOleada()
    {
        if (cg.faseActual == FaseDia.Noche)
        {
            spawneando = true;
            foreach (EnemigosSO enem in enemigos)
            {
                int auxilia = Random.Range(0, 4);
                GameObject clone = Instantiate(enem.objeto, spawners[auxilia].position, spawners[auxilia].rotation);
                clone.GetComponent<EnemigosOLD>().datos = enem;
                clone.GetComponent<EnemigosOLD>().objetivo = jugador;
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(30);
            spawneando = false;
        }
    }
}
