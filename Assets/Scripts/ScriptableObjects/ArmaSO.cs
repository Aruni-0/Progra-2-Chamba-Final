using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ArmaSO", menuName = "Scriptable Objects/ArmaSO")]
public class ArmaSO : ScriptableObject
{
    public int alcance;
    public int daño;
    public float cadencia;
    public GameObject prefab;
    public Image icono;
}
