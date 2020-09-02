using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class SpellModifier : MonoBehaviour
{
    #region Variables
    GameObject spellObject;
    public SpellTransform spellTransform;
    private Thread _t1;
    #endregion


    #region Util Methods/Structs
    public enum SpellTransform
    {
        none, tripleShot, sineWaveX, sineWaveY, sineWaveZ, splitShot
    }

    private void Tripleshot()
    {
        spellObject.GetComponent<SpellClass>().type = 0;
        GameObject temp = Instantiate(spellObject, spellObject.transform);
        temp.transform.Rotate(new Vector3(0, 0, 45));
        temp = Instantiate(spellObject, spellObject.transform);
        temp.transform.Rotate(new Vector3(0, 0, -45));
    }
    #endregion


    #region Main Methods
    public void Modify(GameObject spell,SpellTransform type, float delayTime)
    {
        spellObject = spell;
        switch (type)
        {
            case SpellTransform.tripleShot:
                _t1 = new Thread(Tripleshot);
                _t1.Start();
                break;
            case SpellTransform.sineWaveX:
                break;
            case SpellTransform.sineWaveY:
                break;
            case SpellTransform.sineWaveZ:
                break;
            case SpellTransform.splitShot:
                break;
            default:
                break;
        }
    }
    #endregion
}
