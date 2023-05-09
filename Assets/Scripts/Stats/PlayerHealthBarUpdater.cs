using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUpdater: MonoBehaviour
{

    State state;
    ExperienceManager expManager;
    StartingStats stats;
    public Text healthText;
    public Text manaText;
    public Text ExpText;
    public Text LevelText;

    public Material indicatorHP;
    public Slider sliderExp;
    public Material indicatorMP;

    //public Slider sliderHp;
    //public Slider sliderMp;

    public float sliderMP;
    public float sliderHP;




    
    void Awake()
    {
        state = GameObject.FindWithTag("Player").GetComponent<State>();
        expManager = GameObject.FindWithTag("Player").GetComponent<ExperienceManager>();
        stats = GameObject.FindWithTag("Player").GetComponent<StartingStats>();

        sliderMP = 0;
        sliderHP = 0;

    }
    // Update is called once per frame
    void Update()
    {
        sliderMP = (0.5f - (state.currentMana / stats.GetStat(Stat.MagicPoints) / 2));
        sliderHP = (0.5f - (state.currentHealth / stats.GetStat(Stat.HealthPoints) / 2));

        //Update text and slidebars values
        //healthText.text = state.currentHealth.ToString() + "/" + stats.GetStat(Stat.HealthPoints);
        ExpText.text = expManager.expThisLevel.ToString() + "/" + stats.GetStat(Stat.ExpToLevelUp);
        LevelText.text = "Lv. " + stats.CalculateLevel();
        //sliderHp.value = state.currentHealth / stats.GetStat(Stat.HealthPoints) * 100;
        sliderExp.value = expManager.expThisLevel / stats.GetStat(Stat.ExpToLevelUp) * 100;
        //sliderMp.value = state.currentMana / stats.GetStat(Stat.MagicPoints) * 100;
        indicatorMP.SetFloat("_Cutoff", sliderMP);
        indicatorHP.SetFloat("_Cutoff", sliderHP);

        //manaText.text = (float)Mathf.Round(state.currentMana) + "/" + stats.GetStat(Stat.MagicPoints);

    }

    

}
