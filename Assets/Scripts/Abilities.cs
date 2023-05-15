using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class Abilities : ScriptableObject
{
    new public string name = "New Ability";

    public Texture icon = null;

   
    public enum Type
    {
        Passive,
        Active
    }

    public float modifier;
    public Stat stat;
    public Type type;
    [SerializeField]
    public PlayerSkills.SkillType ability;

    public string description; 
    public GameObject effectPrefab;

    public float cost;
    public float cooldown;
}
