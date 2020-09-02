using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellClass : MonoBehaviour
{
    #region public Variables
    public float spellDuration;
    public float modifierDelay;

    public GameObject nextSpell;

    public SpellModifier.SpellTransform type = 0;
    #endregion

    #region Private Variables
    SpellModifier modifier;
    #endregion

    #region Constructing Methods
    public void SetSpell(SpellModifier.SpellTransform mod, float modDelay)
    {
        type = mod;
        modifierDelay = modDelay;
    }
    #endregion

    #region Util Methods
    void CastNextSpell()
    {
        Instantiate(nextSpell, transform);
        Destroy(gameObject);
    }
    #endregion

    #region Main Methods
    private void Awake()
    {
        modifier.Modify(gameObject, type, modifierDelay);        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(nextSpell)
        {
            Instantiate(nextSpell, transform);
            Destroy(gameObject);
        }
    }
    #endregion
}
