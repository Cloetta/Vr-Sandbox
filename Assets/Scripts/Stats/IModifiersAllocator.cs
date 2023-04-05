using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Allocate all modifiers to the stats
public interface IModifiersAllocator
{
    //Compared to enumerator, enumerable allows to loop over it
    IEnumerable<float> GetModifier(Stat stat);
}
