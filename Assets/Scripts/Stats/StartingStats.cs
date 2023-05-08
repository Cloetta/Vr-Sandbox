using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StartingStats : MonoBehaviour
{
    //Range of the available levels available
    [Range(1, 20)]
    public int startLevel = 1;
    [SerializeField]
    Class characterClass;
    
    public ElementAffinity elementAffinity;
    public ElementAffinity elementWeakness; 
    [SerializeField]
    Levelling levelling = null;
    ExperienceManager expManager;

    private PlayerSkills playerSkills;


    State state;

    public int currentLevel = 0;
    

    private void Awake()
    {       
        currentLevel = CalculateLevel();

        playerSkills = new PlayerSkills();
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {

        //is this useful for some passive maybe...? https://www.youtube.com/watch?v=_OQTTKkwZQY&ab_channel=CodeMonkey 10.34
        switch (e.skillType)
        {
            case PlayerSkills.SkillType.Skill1:
                break;
            case PlayerSkills.SkillType.Skill2:
                break;
            case PlayerSkills.SkillType.Skill3:
                break;
            case PlayerSkills.SkillType.Skill4:
                break;

        }
    }

    private void Start()
    {
        expManager = GetComponent<ExperienceManager>();

        state = GetComponent<State>();

        if (expManager != null)
        {
            //Subscribing to the updatelevel method
            expManager.onExpReceived += UpdateLevel;

        }
    }

    //Recalculating the level to update, retrieving the exp points
    private void UpdateLevel()
    {
        int newLevel = CalculateLevel();
        if(newLevel > currentLevel)
        {

            //Make sure the exp bar is considering only the current exp on the level and not being cumulative across all levels
            expManager.expThisLevel = Math.Max(expManager.expThisLevel - GetStat(Stat.ExpToLevelUp), 0);
            playerSkills.AddSkillPoint();
            currentLevel = newLevel;

        }

        float healthDiff = state.maxHealth - state.currentHealth;

        state.maxHealth = GetStat(Stat.HealthPoints);

        state.currentHealth = state.maxHealth - healthDiff;
        
    }


    //Getting the stats from the levelling pattern scriptable object and the modifiers of the equipped items
    public float GetStat(Stat stat)
    {
       
        return levelling.GetStat(stat, characterClass, GetLevel()) + GetModifier(stat);
    }

    public int CalculateLevel()
    {

        ExperienceManager exp = this.GetComponent<ExperienceManager>();

        if (exp == null)
        {
            //Returning the starting level if no componen
            //Debug.Log("ExpManager is null!");
            return startLevel;
        }
        float currentExp = exp.GetPoints();

        if (currentExp == 0)
        {
            return startLevel;
        }
  
        //float currentExp = GetComponent<ExperienceManager>().GetPoints();
        int penultimateLevel = levelling.GetLevels(Stat.CumulativeExp, characterClass);


        for (int level= 1; level <= penultimateLevel; level++)
        {
            float ExpToLevelUP = levelling.GetStat(Stat.CumulativeExp, characterClass, level);
             if (ExpToLevelUP > currentExp)
             {
                return level;
             }
        }

        Debug.Log(penultimateLevel);

        return penultimateLevel+1;
    }



    public int GetLevel()
    {
        if (currentLevel < 1)
        {
            currentLevel = CalculateLevel();
            
        }

        return currentLevel;
    }

    //Get the modifier value for the stats to increment (e.g. Additive attack value from a weapon or increased defense value from equipping an armor)
    private float GetModifier(Stat stat)
    {
        float totalDamage = 0;

        foreach(IModifiersAllocator allocator in GetComponents<IModifiersAllocator>())
        {
            foreach(float modifier in allocator.GetModifier(stat))
            {
                totalDamage += modifier;
                
            }
        }
        return totalDamage;
    }

    public void GetElementalAffinity(int index)
    {
        switch (index)
        {
            case 0:
                elementAffinity = ElementAffinity.Fire;
                elementWeakness = ElementAffinity.Water;
                break;
            case 1:
                elementAffinity = ElementAffinity.Water;
                elementWeakness = ElementAffinity.Electricity;
                break;
            case 2:
                elementAffinity = ElementAffinity.Ice;
                elementWeakness = ElementAffinity.Fire;
                break;
            case 3:
                elementAffinity = ElementAffinity.Earth;
                elementWeakness = ElementAffinity.Air;
                break;
            case 4:
                elementAffinity = ElementAffinity.Air;
                elementWeakness = ElementAffinity.Ice;
                break;
            case 5:
                elementAffinity = ElementAffinity.Electricity;
                elementWeakness = ElementAffinity.Earth;
                break;
            case 6:
                elementAffinity = ElementAffinity.Light;
                elementWeakness = ElementAffinity.Darkness;
                break;
            case 7:
                elementAffinity = ElementAffinity.Darkness;
                elementWeakness = ElementAffinity.Light;
                break;
        }
    }

    //change with skillname
    public bool CanUseSkill1()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Skill1); //change with skillname 
    }


    //change with skillname
    public bool CanUseSkill2()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Skill2); //change with skillname 
    }

    //change with skillname
    public bool CanUseSkill3()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Skill3); //change with skillname 
    }

    //change with skillname
    public bool CanUseSkill4()
    {
        return playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Skill4); //change with skillname 
    }

    public PlayerSkills GetPlayerSkills()
    {
        return playerSkills;
    }

}
