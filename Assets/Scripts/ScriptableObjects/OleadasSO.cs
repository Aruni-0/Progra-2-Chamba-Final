using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OleadasSO", menuName = "Scriptable Objects/OleadasSO")]
public class OleadasSO : ScriptableObject
{
    public string nombreOleada;
    public List<EnemigosSO> listaEnemigos = new List<EnemigosSO>(3);
    public float esperaEntreEnemigos;
    public int cantidadEnemigos;
}
