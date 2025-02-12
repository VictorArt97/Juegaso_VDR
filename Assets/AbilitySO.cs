using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability")]
public class AbilitySO : ScriptableObject
{
    public string nombreHabilidad;
    public float damage;
    public int range;
}
