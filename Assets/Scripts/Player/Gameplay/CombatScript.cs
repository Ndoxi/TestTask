using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatScript : MonoBehaviour
{
    [Header("Player script manager")]
    [SerializeField] private PlayerScriptManager _scriptManager;

    [Header("Spell")]
    [SerializeField] private GameObject _spellPrafab;

    public static event PlayerEventManager.ShowSpellCooldown ShowSpellCooldownUI;

    private bool _inCooldown = false;

    public bool InCooldown { get { return _inCooldown; } }


    public void PrepareSpell()
    {
        Vector2 shootPosition = _scriptManager.InputHandler.MousePosition;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 firePosition = (shootPosition - currentPos).normalized;

        if (firePosition.x > 0)
        {
            _scriptManager.Visuals.FaceRight();
        }
        else if (firePosition.x < 0)
        {
            _scriptManager.Visuals.FaceLeft();
        }
    }


    public void FireSpell()
    {
        Vector2 shootPosition = _scriptManager.InputHandler.MousePosition;
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 firePosition = (shootPosition - currentPos).normalized;

        Quaternion spellRotation = Quaternion.FromToRotation(transform.right, firePosition);

        GameObject spellGameObject = Instantiate(_spellPrafab, transform.position, spellRotation);

        spellGameObject.GetComponent<FireSpellScriptManager>().Projectile.Setup(firePosition);
        float spellCouldown = spellGameObject.GetComponent<FireSpellScriptManager>().Projectile.SpellStats.cooldown;

        StartCoroutine(WaitForCooldownEnd(spellCouldown));
    }


    IEnumerator WaitForCooldownEnd(float spellCouldown)
    {
        _inCooldown = true;
        ShowSpellCooldownUI?.Invoke(spellCouldown);

        yield return new WaitForSeconds(spellCouldown);

        _inCooldown = false;
        _scriptManager.InputHandler.IsAttacking = false;
    }
}