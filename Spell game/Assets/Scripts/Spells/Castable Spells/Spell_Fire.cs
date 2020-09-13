using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spell_Fire : MonoBehaviour
{
    #region Variables
    public GameObject[] effects;

    public GameObject shot;

    #endregion

    #region Util Methods
    public void FireSpell()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject effect = Instantiate(effects[Random.Range(0,effects.Length)], shot.transform);
            effect.GetComponent<RFX4_EffectSettings>().UseCustomColor = true;
            effect.GetComponent<RFX4_EffectSettings>().EffectColor = Color.green;
            effect.transform.parent = GameObject.Find("====Spells====").transform;
        }
    }
    #endregion

    #region Main Methods
    private void Update()
    {
        FireSpell();
    }
    #endregion
  
}
