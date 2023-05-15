using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerSkills
{
    public event EventHandler OnSkillPointsChanged;
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;

   
    public class OnSkillUnlockedEventArgs: EventArgs
    {
        public SkillType skillType;
    }

    public enum SkillType
    {
        None,
        Heal,
        Passive_Summon1,
        Passive_Mana1,
        Barrier_Summon,
        Empower_Summon,
        Passive_HP1,
        Passive_HP2,
        Passive_Damage1,
        Barrier_Self,
        Empower_Self,
        Fireball,
        Passive_Mana2,
        Passive_Damage2,
        Passive_Mana3,
        Break_Barriers, 
        Blood_Stain
    }

    private List<SkillType> unlockedSkillList;
    public int skillPoints = 10;



    //Constructor for the list of skills acquired
    public PlayerSkills()
    {
        unlockedSkillList = new List<SkillType>();
    }
    public void AddSkillPoint()
    {
        skillPoints++;
        OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    //Add unlocked skill to the list
    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillList.Add(skillType);
            OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        }
    }
        
    
    public bool IsSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillList.Contains(skillType);
    }

    public bool CanUnlock(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequirement(skillType);

        if (skillRequirement != SkillType.None)
        {
            if (IsSkillUnlocked(skillRequirement))
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            
            return true;
        }
    }


    public SkillType GetSkillRequirement(SkillType skillType)
    {
        switch (skillType)
        {
            //Support Branch
            case SkillType.Passive_Summon1: return SkillType.Heal;
            case SkillType.Passive_Mana1: return SkillType.Passive_Summon1;
            case SkillType.Barrier_Summon: return SkillType.Passive_Mana1;
            case SkillType.Empower_Summon: return SkillType.Passive_Mana1;
            //Offense Branch
            case SkillType.Passive_HP1: return SkillType.Blood_Stain;
            case SkillType.Passive_Damage1: return SkillType.Passive_HP1;
            case SkillType.Passive_HP2: return SkillType.Passive_HP1;
            case SkillType.Barrier_Self: return SkillType.Passive_HP2;
            case SkillType.Empower_Self: return SkillType.Passive_Damage1;
            //Magic/Debuff Branch
            case SkillType.Passive_Mana2: return SkillType.Fireball;
            case SkillType.Passive_Damage2: return SkillType.Passive_Mana2;
            case SkillType.Passive_Mana3: return SkillType.Passive_Mana2;
            case SkillType.Break_Barriers: return SkillType.Passive_Damage1 | SkillType.Passive_Mana3;

        }

        return SkillType.None;
        
    }
    
    public bool TryUnlockSkill(SkillType skillType)
    {
        if (CanUnlock(skillType))
        {
            if (skillPoints > 0)
            {
                Debug.Log(skillPoints);
                skillPoints--;
                OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
                UnlockSkill(skillType);
                Debug.Log("unlock ok");
                return true;
            }
            else
            {
                return false;
            }
           
        }
        else
        {
            Debug.Log("Unlock Failed");
            return false;
        }

        
    }

   
}
