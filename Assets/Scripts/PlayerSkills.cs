using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Skill1,
        Skill2,
        Skill3,
        Skill4,
    }

    private List<SkillType> unlockedSkillList;
    private int skillPoints;

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
            case SkillType.Skill2: return SkillType.Skill1;
            case SkillType.Skill3: return SkillType.Skill2;
            case SkillType.Skill4: return SkillType.Skill3;
        }

        return SkillType.None;
        
    }
    
    public bool TryUnlockSkill(SkillType skillType)
    {
        if (CanUnlock(skillType))
        {
            if (skillPoints > 0)
            {
                skillPoints--;
                OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
                UnlockSkill(skillType);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        else
        {
            return false;
        }

        
    }

    
}
