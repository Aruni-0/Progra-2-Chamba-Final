using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [SerializeField] CharacterController controlador;
    [SerializeField] private float velocidad;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float distanciaInteracccion;
    [SerializeField] private LayerMask layerMask;

    [Header("Armas Info")]
    [SerializeField] private ArmaSO actual;
    [SerializeField] private ArmaSO primaria;
    [SerializeField] private ArmaSO secundaria;

    public bool puedePegar = true;
    [SerializeField] private int daño;

    private void Start()
    {
        daño = actual.daño;
    }

    void Update()
    {
        DibujarLinea();
        Movimiento();
        MovimientoRaton();
        Golpear();
        Interaccion();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (actual == primaria)
            {
                actual = secundaria;
            }
            else if (actual == secundaria)
            {
                actual = primaria;
            }
            daño = actual.daño;
            distanciaAtaque = actual.alcance;
        }
    }

    private void Movimiento()
    {
        //Movimiento
        Vector3 movimiento = Vector3.zero;

        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.y = 0;
        movimiento.z = Input.GetAxis("Vertical");

        controlador.Move(movimiento * Time.deltaTime * velocidad);
    }

    private void MovimientoRaton()
    {
        //Movimiento del Ratón
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit infoHit;
        if (Physics.Raycast(rayo, out infoHit, 100f))
        {
            Vector3 posicion = infoHit.point;
            posicion.y = transform.position.y;

            transform.LookAt(posicion);
        }
    }

    private void Golpear()
    {
        //Golpe
        if (Input.GetMouseButtonDown(0) && puedePegar)
        {
            Ray golpe = new Ray(transform.position, transform.forward);
            RaycastHit enemyInfo;

            //Debug.DrawRay(golpe.origin, golpe.direction * 10, Color.green, distancia);

            if (Physics.Raycast(golpe.origin, golpe.direction, out enemyInfo, distanciaAtaque, layerMask))
            {
                Debug.Log(enemyInfo.transform.gameObject.name);
            }
            else
            {
                Debug.Log("No le pegaste");
            }
            puedePegar = false;
            StartCoroutine(CadenciaGolpe());
        }
    }

    private void Interaccion()
    {
        IInteractuable interactuableMasCercano = null;

        List<Collider> objetosInteractuables = Physics.OverlapSphere(transform.position + transform.forward, distanciaInteracccion).ToList();

        float distanciaCercana = 1000f;
        if (objetosInteractuables.Count > 0)
        {

            foreach (Collider collider in objetosInteractuables)
            {
                if (collider.transform.TryGetComponent<IInteractuable>(out IInteractuable interactuable))
                {
                    //Si nuestro collider con el componente interactuable está más cerca que la distancia más cercana
                    if (Vector3.Distance(collider.transform.position, transform.position) < distanciaCercana)
                    {
                        interactuableMasCercano = interactuable;
                        distanciaCercana = Vector3.Distance(collider.transform.position, transform.position);
                    }
                }
            }
        }
        else
        {
            interactuableMasCercano = null;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //El "?" está checando si es null
            interactuableMasCercano?.Interactuar();
        }

    }

    private IEnumerator CadenciaGolpe()
    {
        yield return new WaitForSeconds(actual.cadencia);
        puedePegar = true;
    }

    private void DibujarLinea()
    {
        Vector3 origen = transform.position;
        Vector3 direccion = transform.forward;

        // Crear el Raycast
        RaycastHit hit;

        if (Physics.Raycast(origen, direccion, out hit, distanciaAtaque, layerMask))
        {
            // Si impacta algo, dibuja la línea hasta el punto de impacto en ROJO
            Debug.DrawLine(origen, hit.point, Color.red);
        }
        else
        {
            // Si no impacta nada, dibuja la línea hasta la distancia máxima en VERDE
            Debug.DrawRay(origen, direccion * distanciaAtaque, Color.green);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.forward, distanciaInteracccion);
    }

}
