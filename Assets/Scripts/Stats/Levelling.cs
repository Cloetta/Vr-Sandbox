using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levelling", menuName = "RPGMechanics/New LevellingSystem", order = 0)]
public class Levelling : ScriptableObject
{
    [SerializeField]
    CharacterProgress[] progressClass = null;
    Dictionary<Class, Dictionary<Stat, float[]>> lookupTable = null;

    public float GetStat(Stat stat, Class charClasses, int level)
    {
        //this operation can be very expensive performancewise (nested foreach), so it is replaced with dictionaries that can be occasionally looked at
        #region
        /*
        foreach (CharacterProgress classPattern in progressClass)
        {
            //if(classPattern.characterClass == charClass)
            //{
            //return classPattern.health[level - 1];
            //}

            if (classPattern.characterClass != charClasses)
            {
                continue;
            }

            foreach (LevellingStat levStat in classPattern.stats)
            {
                if(levStat.stat != stat)
                {
                    continue;
                }

                //Check if the length of the array is less than the level, in that case it continues the search through the loop
                if (levStat.levels.Length < level)
                {
                    continue;
                }

                return levStat.levels[level - 1];
            }
        }
        //return 0;
         
         */

        #endregion


        BuildDictionaryLookUp();

        float[] levels = lookupTable[charClasses][stat];

        if (levels.Length < level)
        {
            return 0;
        }



        return levels[level-1];

    }

    //Populating the dictionary of Levels, Classes and Stats
    private void BuildDictionaryLookUp()
    {
        if (lookupTable != null)
        {
            return;
        }

        lookupTable = new Dictionary<Class, Dictionary<Stat, float[]>>();

        foreach (CharacterProgress classPattern in progressClass)
        {

            var statLookupTable = new Dictionary<Stat, float[]>();

            foreach (LevellingStat levStat in classPattern.stats)
            {
                statLookupTable[levStat.stat] = levStat.levels;
            }        

            lookupTable[classPattern.characterClass] = statLookupTable;

        }
    }

    public int GetLevels (Stat stat, Class charClass)
    {
        //Ensuring the dictionary has been populated before using it to get the levels
        BuildDictionaryLookUp();



        float[] levels = lookupTable[charClass][stat];

        

        return levels.Length;
    }





    //Makes the class variables serializable within scriptable object
    [System.Serializable]
   class CharacterProgress
   {
        
        public Class characterClass;
        //public ElementAffinity elementAffinity;
        
        public LevellingStat[] stats;
        
   }


    [System.Serializable]
    class LevellingStat
    {

        public Stat stat;
        public float[] levels;
    }


}
