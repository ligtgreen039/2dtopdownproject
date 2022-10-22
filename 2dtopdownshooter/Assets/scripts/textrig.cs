using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textrig : MonoBehaviour
{
   public wavespawnerupgraded wavespawnerupgraded;
    void textrigger()
    {
        wavespawnerupgraded.texttrigger = false;
        wavespawnerupgraded.canspawnnormalize = true;
        wavespawnerupgraded.canspawndragon = true;
        wavespawnerupgraded.dragonspawntime = wavespawnerupgraded.dragondelay;
    }
}
