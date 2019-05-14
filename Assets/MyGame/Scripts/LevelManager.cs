/* concrete singelton
 * this inherits from the GenericSingleton (a singleton without copying code),   
 * the GenericSingleton fixes the persistency problem and allows lazy instantiation.  
 */
using UnityEngine;

public class LevelManager : GenericSingletonClass<LevelManager>
{

    private int numberCollectibesCollected = 0;
    private bool playMode;

    public int NumberCollectiblesCollected
    {
        get
        {
            Debug.Log("get nbr collected collectibles " + numberCollectibesCollected);
            return numberCollectibesCollected;
        }

        set
        {
            Debug.Log("set nbr collected collectibles " + numberCollectibesCollected);
            numberCollectibesCollected = value;
        }
    }

    public bool PlayMode
    {
        get
        {
            return playMode;
        }

        set
        {
            playMode = value;
        }
    }
}