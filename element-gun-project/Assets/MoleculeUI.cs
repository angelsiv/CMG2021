using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeUI : MonoBehaviour
{
    [SerializeField] GameObject icon_template = null;
    [SerializeField] private Transform group_Layout = null;
    [SerializeField] private MoleculeManager moleculeManager = null;
    [SerializeField] private Sprite[] equippedIcon = null;
    [SerializeField] private Image currentEquippedIcon = null;

    private void Awake()
    {
        moleculeManager.OnUIUpdated += UpdateUI;
    }

    private void OnDestroy()
    {
        moleculeManager.OnUIUpdated -= UpdateUI;
    }

    private void UpdateUI(List<Molecule> molecules, MixedOutputType type)
    {
        for (int i = 0; i < group_Layout.childCount; i++)
        {
            Destroy(group_Layout.GetChild(i).gameObject);
        }

        foreach (Molecule molecule in molecules)
        {
            AddIcon(molecule.uiElement);
        }
        
        UpdateEquippedIcon(type);
    }

    

    private void AddIcon(Sprite sprite)
    {
        GameObject iconToAdd = Instantiate(icon_template,group_Layout);
        iconToAdd.GetComponent<Image>().sprite = sprite;
    }

    private void UpdateEquippedIcon(MixedOutputType type)
    {
        switch (type)
        {
            case MixedOutputType.Acid:
                currentEquippedIcon.sprite = equippedIcon[0];
                break;
            case MixedOutputType.Lightning:
                currentEquippedIcon.sprite = equippedIcon[1];
                break;
            case MixedOutputType.Water:
                currentEquippedIcon.sprite = equippedIcon[2];
                break;
        }
    }
    

    
}
