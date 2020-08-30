using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellModifier : MonoBehaviour
{
    #region Variables
    SpellTransform spellTransform;
    #endregion

    #region Constructor
    SpellModifier(int modifier)
    {

    }
    #endregion

    public void Modify(ParticleSystem spell, float delayTime)
    {
        switch (spellTransform)
        {
            case SpellTransform.tripleShot:
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
}

enum SpellTransform
{
    tripleShot, sineWaveX, sineWaveY,sineWaveZ,splitShot
}