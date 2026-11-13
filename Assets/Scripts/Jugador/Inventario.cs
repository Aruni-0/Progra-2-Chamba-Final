using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private List<ArmaSO> armasEnInventario = new List<ArmaSO>();
    private ControlJugador controlJugador;

    public void AñadirArma(ArmaSO armaNueva)
    {
        armasEnInventario.Add(armaNueva);
    }

    public void CambiarArmaEquipada(int armaIndex)
    {
        if (armasEnInventario.Count == 0) { return; }
        controlJugador.primaria = armasEnInventario[armaIndex];
        controlJugador.actual = controlJugador.primaria;
    }
}
