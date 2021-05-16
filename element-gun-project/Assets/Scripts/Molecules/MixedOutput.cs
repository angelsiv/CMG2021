using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "ScriptableObjects/Material", order = 1)]
public class MixedOutput : ScriptableObject
{
    public MixedOutputType type = MixedOutputType.None;

    public List<Molecule> chemicalFormula;
}
