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

    public Slider sliderHP;
    public Slider sliderExp;
    public Slider SliderMP;

    public Text cumulativeExp;


    
    void Awake()
    {
        state = GameObject.FindWithTag("Player").GetComponent<State>();
        expManager = GameObject.FindWithTag("Player").GetComponent<ExperienceManager>();
        stats = GameObject.FindWithTag("Player").GetComponent<StartingStats>();

    }
    // Update is called once per frame
    void Update()
    {
        //update text and slidebar value
        healthText.text = state.currentHealth.ToString() + "/" + stats.GetStat(Stat.HealthPoints);//state.maxHealth.ToString();
        ExpText.text = expManager.expThisLevel.ToString() + "/" + stats.GetStat(Stat.ExpToLevelUp);
        LevelText.text = "Lv. " + stats.CalculateLevel();
        sliderHP.value = state.currentHealth / state.maxHealth * 100;
        //sliderHP.maxValue = stats.GetStat(Stat.HealthPoints);
        //sliderExp.maxValue = stats.GetStat(Stat.ExpToLevelUp);
        sliderExp.value = expManager.expThisLevel / stats.GetStat(Stat.ExpToLevelUp) * 100;

        SliderMP.value = state.currentMana / state.maxMana * 100;
        manaText.text = (float)Mathf.Round(state.currentMana) + "/" + stats.GetStat(Stat.MagicPoints);

        cumulativeExp.text = expManager.totalExpPoints + " / " + stats.GetStat(Stat.CumulativeExp);

    }

}
