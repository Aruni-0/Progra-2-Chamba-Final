using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [SerializeField] CharacterController controlador;
    [SerializeField] private float velocidad;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        DibujarLinea();
        //Movimiento
        Vector3 movimiento = Vector3.zero;

        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.y = 0;
        movimiento.z = Input.GetAxis("Vertical");

        controlador.Move(movimiento * Time.deltaTime * velocidad);

        //Movimiento del Ratón
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit infoHit;
        if(Physics.Raycast(rayo, out infoHit, 100f))
        {
            Vector3 posicion = infoHit.point;
            posicion.y = transform.position.y;

            transform.LookAt(posicion);
        }

        //Golpe
        if (Input.GetMouseButtonDown(0))
        {
            Ray golpe = new Ray(transform.position, transform.forward);
            RaycastHit enemyInfo;

            //Debug.DrawRay(golpe.origin, golpe.direction * 10, Color.green, distancia);

            if (Physics.Raycast(golpe.origin, golpe.direction, out enemyInfo, 100f, layerMask))
            {
                Debug.Log(enemyInfo.transform.gameObject.name);
            }
            else
            {
                Debug.Log("No le pegaste");
            }
        }

    }

    private void DibujarLinea()
    {
        Vector3 origen = transform.position;
        Vector3 direccion = transform.forward;

        // Crear el Raycast
        RaycastHit hit;

        if (Physics.Raycast(origen, direccion, out hit, distancia, layerMask))
        {
            // Si impacta algo, dibuja la línea hasta el punto de impacto en ROJO
            Debug.DrawLine(origen, hit.point, Color.red);
        }
        else
        {
            // Si no impacta nada, dibuja la línea hasta la distancia máxima en VERDE
            Debug.DrawRay(origen, direccion * distancia, Color.green);
        }
    }
}
