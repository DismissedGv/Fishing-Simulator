using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int fish1;
    public int fish2;
    public int fish3;
    public int fish4;

    public void AddFish(int index)
    {
        if (index == 1)
        {
            fish1++;
        }
        else if (index == 2)
        {
            fish2++;
        }
        else if (index == 3)
        {
            fish3++;
        }
        else if (index == 4)
        {
            fish4++;
        }
        
    }
}
