using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Molecule", menuName = "ScriptableObjects/Molecule", order = 1)]
public class Molecule : ScriptableObject
{
   public MoleculeType type = MoleculeType.None;
   public Sprite uiElement;
   public GameObject prefab;
}
