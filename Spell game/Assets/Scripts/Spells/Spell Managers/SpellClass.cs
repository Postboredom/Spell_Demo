using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellClass : MonoBehaviour
{
    #region public Variables
    public int spellType;
    public string spellName;
    public float spellLength;
    public float modifierDelay;
    #endregion

    #region Private Variables
    SpellClass spell;
    SpellModifier type;
    ParticleSystem curParticles;
    #endregion

    #region Constructor Methods
    SpellClass(ParticleSystem particleSystem, int spelltype)
    {
        spellName = "Spell";
        spellType = spelltype;
        curParticles = particleSystem;
    }
    SpellClass(string name, ParticleSystem particleSystem, int spelltype)
    {
        spellName = name;
        spellType = spelltype;
        curParticles = particleSystem;
    }
    SpellClass(string name, ParticleSystem current,int spelltype, SpellClass nextSpell)
    {
        spellName = name;
        spell = nextSpell;
        spellType = spelltype;
        curParticles = current;
    }
    SpellClass(string name, ParticleSystem particleSystem, int spelltype, SpellModifier mod, float modDelay)
    {
        type = mod;
        spellName = name;
        spellType = spelltype;
        modifierDelay = modDelay;
        curParticles = particleSystem;
    }
    #endregion

    #region Util Methods
    void CastNextSpell()
    {
        Destroy(curParticles);
        spell.CastSpell(curParticles.transform);
    }
    #endregion

    #region Main Methods
    void CastSpell(Transform target)
    {
        ParticleSystem temp = Instantiate(curParticles, target);
        temp.transform.parent = GameObject.Find("====Spells====").transform;
    }

    void ModifySpell()
    {
        type.Modify(curParticles, modifierDelay);
    }
    #endregion
}
