using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied EnteredDeathState;

    public delegate void ShowSpellCooldown(float spellCooldown);
}
