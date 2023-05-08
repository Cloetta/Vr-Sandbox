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




    
    void Awake()
    {
        state = GameObject.FindWithTag("Player").GetComponent<State>();
        expManager = GameObject.FindWithTag("Player").GetComponent<ExperienceManager>();
        stats = GameObject.FindWithTag("Player").GetComponent<StartingStats>();

    }
    // Update is called once per frame
    void Update()
    {
        //Update text and slidebars values
        healthText.text = state.currentHealth.ToString() + "/" + stats.GetStat(Stat.HealthPoints);
        ExpText.text = expManager.expThisLevel.ToString() + "/" + stats.GetStat(Stat.ExpToLevelUp);
        LevelText.text = "Lv. " + stats.CalculateLevel();
        sliderHP.value = state.currentHealth / stats.GetStat(Stat.HealthPoints) * 100;
        sliderExp.value = expManager.expThisLevel / stats.GetStat(Stat.ExpToLevelUp) * 100;
        SliderMP.value = state.currentMana / stats.GetStat(Stat.MagicPoints) * 100;
        manaText.text = (float)Mathf.Round(state.currentMana) + "/" + stats.GetStat(Stat.MagicPoints);

    }

}
