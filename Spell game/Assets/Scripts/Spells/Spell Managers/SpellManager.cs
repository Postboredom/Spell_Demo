using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    #region Variables
    bool spellCreationUI;

    SpellClass newSpell;
    SpellClass OriginalSpell;
    public List<GameObject> spellList;


    GameObject selectedSpell;
    GameObject spellCreationScreen;
    public Transform playerSpellPos;
    #endregion

    #region Util Methods
    void ButtonClicks()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CreateSpell();
        }
        if(Input.GetMouseButton(0) && !spellCreationUI)
        {
            CastSpell(selectedSpell);
        }

    }
    void GetCursor()
    {
        if (spellCreationUI) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }
    void SpellCancel()
    {
        newSpell = new SpellClass();
    }
    #endregion

    #region Main Methods
    private void Awake()
    {
        spellCreationScreen = GameObject.Find("Spell Maker");
    }
    private void Update()
    {
        ButtonClicks();
        GetCursor();
    }
    void SelectSpell()
    {

    }

    void CastSpell(GameObject spell)
    {
        Instantiate(spell);
    }

    void CreateSpell()
    {
        spellCreationUI = !spellCreationUI;
        GetCursor();
        spellCreationScreen.SetActive(spellCreationUI);
    }

    void DeleteSpell(GameObject spell)
    {
        SpellClass spellcheck = spell.GetComponent<SpellClass>();
        if (spellcheck.nextSpell)
        {
            DeleteSpell(spellcheck.nextSpell);
        }
            Destroy(spell);
    }

    void ModifySpell(SpellModifier spell)
    {

    }
    #endregion
}
