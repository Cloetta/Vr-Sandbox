using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;

    [SerializeField] Button skill1Button;
    [SerializeField] SkillUnlockPath [] skillUnlockPathArray;


    private Text skillPointsText;

  


    private void Awake()
    {
        //transform.Find("SkillBn").GetComponent<Button>();
    }

    //https://www.youtube.com/watch?v=_OQTTKkwZQY&ab_channel=CodeMonkey 14.35 tooltip
    public void ClickSkill1()
    {
        Debug.Log("Skill 1 Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Skill1);
    }
    public void ClickSkill2()
    {
        Debug.Log("Skill 2 Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Skill2);
    }
    public void ClickSkill3()
    {
        Debug.Log("Skill 3 Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Skill3);
    }
    public void ClickSkill4()
    {
        Debug.Log("Skill 4 Clicked!");
        playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Skill4);
    }


    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
        playerSkills.OnSkillPointsChanged += PlayerSkills_OnSkillPointsChanged;
        UpdateVisuals();
        UpdateSkillPointsUI();
    }

    private void PlayerSkills_OnSkillPointsChanged(object sender, System.EventArgs e)
    {
        UpdateSkillPointsUI();

    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        UpdateVisuals();
        
    }

    private void UpdateSkillPointsUI()
    {
        skillPointsText.text = playerSkills.GetSkillPoints().ToString();
    }

    private void UpdateVisuals()
    {
        if (playerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Skill1))
        {
            //refer to sprite and change color? skill is unlocked
        }
        else
        {
            if (playerSkills.CanUnlock(PlayerSkills.SkillType.Skill1))
            {
                //skill can be unlocked and interacted
            }
            else
            {
                //skill cannot be unlocked and cannot be interacted with
            }
        }

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
            if(playerSkills.IsSkillUnlocked(skillUnlockPath.skillType) || playerSkills.CanUnlock(skillUnlockPath.skillType))
            {
                //Skill unlocked or can be unlocked

                foreach (Image linkImage in skillUnlockPath.linkImageArray)
                {
                    linkImage.color = Color.white;
                }

                
            }




            foreach (Image linkImage in skillUnlockPath.linkImageArray)
            {
                linkImage.color = new Color(.5f, .5f, .5f);
            }
        }

    }

    //https://www.youtube.com/watch?v=_OQTTKkwZQY&ab_channel=CodeMonkey 20.26
    [System.Serializable]
    public class SkillUnlockPath
    {
        public PlayerSkills.SkillType skillType;
        public Image[] linkImageArray;
    }


}

