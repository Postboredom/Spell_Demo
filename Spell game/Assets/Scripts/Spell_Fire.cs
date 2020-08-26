using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spell_Fire : MonoBehaviour
{
    #region Variables
    public ParticleSystem[] effects;

    public GameObject shot;
    #endregion

    #region Util Methods
    public void FireSpell()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ParticleSystem effect = Instantiate(effects[0], shot.transform);
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
