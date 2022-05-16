using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellCD : MonoBehaviour
{
    [Header("Spell cooldown image")]
    [SerializeField] private Image _image;

    private void Start()
    {
        _image.fillAmount = 0;
    }


    private void OnEnable()
    {
        CombatScript.ShowSpellCooldownUI += ShowSpellCooldown;
    }


    private void OnDisable()
    {
        CombatScript.ShowSpellCooldownUI -= ShowSpellCooldown;
    }


    public void ShowSpellCooldown(float spellCooldown)
    {
        StartCoroutine(ShowSpellCooldownCoroutine(spellCooldown));
    }


    IEnumerator ShowSpellCooldownCoroutine(float spellCooldown)
    {
        float fillAmount = 1f / spellCooldown;
        _image.fillAmount = 1;

        while (true)
        {
            _image.fillAmount -= fillAmount * Time.deltaTime;

            if (_image.fillAmount <= 0) { break; }

            yield return new WaitForEndOfFrame();
        }
    }
}