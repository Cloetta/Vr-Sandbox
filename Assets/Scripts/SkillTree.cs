using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour, IModifiersAllocator
{
    private PlayerSkills playerSkills;
    private List<SkillButton> skillButtonList;


    //[SerializeField] Button [] skillbutton;
    [SerializeField] SkillUnlockPath [] skillUnlockPathArray;

    [SerializeField] PassiveBonus[] passiveNodes;
    [System.Serializable]
    class PassiveBonus
    {
        public PlayerSkills.SkillType node;
        public Stat stat;
        public float additiveBonusOnUnlock = 0;
        public float percentageBonusOnUnlock = 0;
    }


    [SerializeField] private Text skillPointsText;

    Dictionary<Stat, Dictionary<PlayerSkills.SkillType, float>> additiveBonusCache;

    Dictionary<Stat, Dictionary<PlayerSkills.SkillType, float>> percentageBonusCache;



    private void Awake()
    {

        playerSkills = new PlayerSkills();
        //transform.Find("SkillBn").GetComponent<Button>();
        additiveBonusCache = new Dictionary<Stat, Dictionary<PlayerSkills.SkillType, float>>();
        percentageBonusCache = new Dictionary<Stat, Dictionary<PlayerSkills.SkillType, float>>();

        foreach(var passiveBonus in passiveNodes)
        {
            if (!additiveBonusCache.ContainsKey(passiveBonus.stat))
            {
                additiveBonusCache[passiveBonus.stat] = new Dictionary<PlayerSkills.SkillType, float>();
            }

            if (!percentageBonusCache.ContainsKey(passiveBonus.stat))
            {
                percentageBonusCache[passiveBonus.stat] = new Dictionary<PlayerSkills.SkillType, float>();
            }
            additiveBonusCache[passiveBonus.stat][passiveBonus.node] = passiveBonus.additiveBonusOnUnlock;
            percentageBonusCache[passiveBonus.stat][passiveBonus.node] = passiveBonus.percentageBonusOnUnlock;
        }
    }


    /*
    public void ClickSkillHeal()
    {
        Debug.Log(PlayerSkills.SkillType.Heal + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Heal);
    }

    public void ClickSkillPassive_Summon1()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Summon1 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Summon1);
    }
    public void ClickSkillPassive_Mana1()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Mana1 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Mana1);
    }

    public void ClickSkillBarrier_Summon()
    {
        Debug.Log(PlayerSkills.SkillType.Barrier_Summon + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Barrier_Summon);
    }

    public void ClickSkillEmpower_Summon()
    {
        Debug.Log(PlayerSkills.SkillType.Empower_Summon + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Empower_Summon);
    }

    public void ClickSkillPassive_HP1()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_HP1 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_HP1);
    }

    public void ClickSkillPassive_HP2()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_HP2 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_HP2);
    }

    public void ClickSkillPassive_Damage1()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Damage1 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Damage1);
    }

    public void ClickSkillBarrier_Self()
    {
        Debug.Log(PlayerSkills.SkillType.Barrier_Self + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Barrier_Self);
    }

    public void ClickSkillEmpower_Self()
    {
        Debug.Log(PlayerSkills.SkillType.Empower_Self + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Empower_Self);
    }

    public void ClickSkillFireball()
    {
        Debug.Log(PlayerSkills.SkillType.Fireball + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Fireball);
    }

    public void ClickSkillPassive_Mana2()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Mana2 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Mana2);
    }

    public void ClickSkillPassive_Damage2()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Damage2 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Damage2);
    }

    public void ClickSkillPassive_Mana3()
    {
        Debug.Log(PlayerSkills.SkillType.Passive_Mana3 + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Passive_Mana3);
    }

    public void ClickSkillBreak_Barriers()
    {
        Debug.Log(PlayerSkills.SkillType.Break_Barriers + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Break_Barriers);
    }

    public void ClickSkillBlood_Stain()
    {
        Debug.Log(PlayerSkills.SkillType.Blood_Stain + " Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Blood_Stain);
    }
    */

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
        skillButtonList = new List<SkillButton>();

        


        skillButtonList.Add(new SkillButton(transform.GetChild(3).Find("ActiveSlotHeal").GetChild(0), playerSkills, PlayerSkills.SkillType.Heal));
        skillButtonList.Add(new SkillButton(transform.GetChild(3).Find("PassiveSlotSummon1").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Summon1));
        skillButtonList.Add(new SkillButton(transform.GetChild(3).Find("PassiveSlotMana1").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Mana1));
        skillButtonList.Add(new SkillButton(transform.GetChild(3).Find("ActiveSlotBarrierSummon").GetChild(0), playerSkills, PlayerSkills.SkillType.Barrier_Summon));
        skillButtonList.Add(new SkillButton(transform.GetChild(3).Find("ActiveSlotEmpowerSummon").GetChild(0), playerSkills, PlayerSkills.SkillType.Empower_Summon));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("ActiveSlotBloodStain").GetChild(0), playerSkills, PlayerSkills.SkillType.Blood_Stain));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("PassiveSlotDamage1").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Damage1));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("PassiveSlotHP1").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_HP1));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("PassiveSlotHP2").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_HP2));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("ActiveSlotBarrierSelf").GetChild(0), playerSkills, PlayerSkills.SkillType.Barrier_Self));
        skillButtonList.Add(new SkillButton(transform.GetChild(4).Find("ActiveSlotEmpowerSelf").GetChild(0), playerSkills, PlayerSkills.SkillType.Empower_Self));
        skillButtonList.Add(new SkillButton(transform.GetChild(5).Find("ActiveSlotFireball").GetChild(0), playerSkills, PlayerSkills.SkillType.Fireball));
        skillButtonList.Add(new SkillButton(transform.GetChild(5).Find("PassiveSlotMP3").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Mana3));
        skillButtonList.Add(new SkillButton(transform.GetChild(5).Find("PassiveSlotDamage2").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Damage2));
        skillButtonList.Add(new SkillButton(transform.GetChild(5).Find("PassiveSlotMP2").GetChild(0), playerSkills, PlayerSkills.SkillType.Passive_Mana2));
        skillButtonList.Add(new SkillButton(transform.GetChild(5).Find("ActiveSlotBreakBarrier").GetChild(0), playerSkills, PlayerSkills.SkillType.Break_Barriers));


        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
        playerSkills.OnSkillPointsChanged += PlayerSkills_OnSkillPointsChanged;
        UpdateVisuals();
        UpdateSkillPointsUI();
    }

    private void PlayerSkills_OnSkillPointsChanged(object sender, System.EventArgs e)
    {
        UpdateVisuals();
        UpdateSkillPointsUI();

    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        UpdateVisuals();
        UpdateSkillPointsUI();

    }

    private void UpdateSkillPointsUI()
    {
        Debug.Log(playerSkills.GetSkillPoints());
        skillPointsText.text = playerSkills.GetSkillPoints().ToString();
    }

    private void UpdateVisuals()
    {
        foreach (SkillButton skillButton in skillButtonList)
        {
            skillButton.UpdateVisual();
        }


        /*
        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Heal))
        {
            //refer to sprite and change color? skill is unlocked

            transform.Find("ActiveSlotHeal").GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Heal))
            {
                //skill can be unlocked and interacted
                transform.Find("ActiveSlotHeal").GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.19f);
            }
            else
            {
                //skill cannot be unlocked and cannot be interacted with
                transform.Find("ActiveSlotHeal").GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            }
        }*/



        //Darken all links for nodes not unlocked
        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
        {
            foreach (Image linkImage in skillUnlockPath.linkImageArray)
            {
                linkImage.color = new Color(.5f, .5f, .5f);
            }
        }

        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray)
        {
            
            if (playerSkills.IsSkillUnlocked(skillUnlockPath.skillType) )
            {

                
                //Skill unlocked or can be unlocked

                foreach (Image linkImage in skillUnlockPath.linkImageArray)
                {
                    linkImage.color = new Color(1f, .8f, .2f);
                }

                
            }

            
        }

    }

   
    [System.Serializable]
    public class SkillUnlockPath
    {
        public PlayerSkills.SkillType skillType;
        public Image[] linkImageArray;
    }

    private class SkillButton
    {
        private Transform transform;
        private Image image;
        //private Image backgroundImage;
        private PlayerSkills playerSkills;
        private PlayerSkills.SkillType skillType;

        public SkillButton(Transform transform, PlayerSkills playerSkills, PlayerSkills.SkillType skillType)
        {
            this.transform = transform;
            this.playerSkills = playerSkills;
            this.skillType = skillType;

            transform.GetComponent<Button>().onClick.AddListener(() => playerSkills.TryUnlockSkill(skillType));

        }

        public void UpdateVisual()
        {
            if (playerSkills.IsSkillUnlocked(skillType))
            {
                //refer to sprite and change color? skill is unlocked
                image = transform.GetComponent<Image>();

                image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                if (playerSkills.CanUnlock(skillType))
                {

                    image = transform.GetComponent<Image>();
                    //skill can be unlocked and interacted
                    image.color = new Color(1f, 1f, 1f, 0.19f);
                }
                else
                {

                    //skill cannot be unlocked and cannot be interacted with
                    image = transform.GetComponent<Image>();
                    image.color = new Color(1f, 1f, 1f, 0f);
                }
            }

        }
    }



    public IEnumerable<float> GetAdditiveModifier(Stat stat)
    {
        if (!additiveBonusCache.ContainsKey(stat)) yield break;

        foreach (PlayerSkills.SkillType node in additiveBonusCache[stat].Keys)
        {
            float bonus = additiveBonusCache[stat][node];
            yield return bonus;
        }
    }

    public IEnumerable<float> GetPercentageModifier(Stat stat)
    {
        if (!percentageBonusCache.ContainsKey(stat)) yield break;

        foreach (PlayerSkills.SkillType node in percentageBonusCache[stat].Keys)
        {
            float bonus = percentageBonusCache[stat][node];
            yield return bonus;
        }
    }
}

