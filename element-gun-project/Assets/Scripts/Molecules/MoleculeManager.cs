using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeManager : MonoBehaviour
{
	[SerializeField] private List<Molecule> moleculesDatabase = null;
	[SerializeField] private List<MixedOutput> materialsDatabase = null;
	[SerializeField] private List<Molecule> ammo = null;
	[SerializeField] private List<MixedOutputType> possibleOutput = null;
	[SerializeField] private int MaxAmmo = 4;

	[SerializeField] private int HCount = 0;
	[SerializeField] private int OCount = 0;
	[SerializeField] private int KCount = 0;
	[SerializeField] private int woodCount = 0;
	
	private void Awake()
	{
		materialsDatabase = CreateMaterialDatabase();
		moleculesDatabase = CreateMoleculeDataBase();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.U)) AddAmmo(MoleculeType.Hydrogen);
		if(Input.GetKeyDown(KeyCode.I)) AddAmmo(MoleculeType.Oxygen);
		if(Input.GetKeyDown(KeyCode.O)) AddAmmo(MoleculeType.Potassium);
		if(Input.GetKeyDown(KeyCode.P)) AddAmmo(MoleculeType.Wood);
		
		if(Input.GetKeyDown(KeyCode.Space)) OutputMaterial(MixedOutputType.Water);

		HCount = AmountOfMolecule(MoleculeType.Hydrogen, ammo);
		OCount = AmountOfMolecule(MoleculeType.Oxygen, ammo);
		KCount = AmountOfMolecule(MoleculeType.Potassium, ammo);
		woodCount = AmountOfMolecule(MoleculeType.Wood, ammo);

		possibleOutput = CheckPossibleMaterials();
	}

	List<Molecule> CreateMoleculeDataBase()
	{
		List<Molecule> database = new List<Molecule>();

		foreach (Molecule rawMat in Resources.FindObjectsOfTypeAll(typeof(Molecule)) as Molecule[])
		{
			database.Add(rawMat);
		}

		return database;
	}
	
	List<MixedOutput> CreateMaterialDatabase()
	{
		List<MixedOutput> database = new List<MixedOutput>();

		foreach (MixedOutput mat in Resources.FindObjectsOfTypeAll(typeof(MixedOutput)) as MixedOutput[])
		{
			database.Add(mat);
		}

		return database;
	}
	
	public void AddAmmo(MoleculeType moleculeType)
	{
		if (ammo.Count == MaxAmmo)
		{
			Debug.LogWarning("No more space for ammo - Code is working as expected");
			return;
		}
		
		if (SearchForMolecule(moleculeType) is Molecule moleculeToAdd)
		{
			ammo.Add(moleculeToAdd);
		}
	}

	private Molecule SearchForMolecule(MoleculeType moleculeType)
	{
		foreach (Molecule molecule in moleculesDatabase)
		{
			if (molecule.type == moleculeType) return molecule;
		}

		return null;
	}

	private void OutputMaterial(MixedOutputType type)
	{
		if (!possibleOutput.Contains(type))
		{
			Debug.LogWarning("Do not have enough molecules to shoot this material - Code works as expected");
			return;
		}
		
		
		foreach (Molecule molecule in ReturnMaterialOfSpecificType(type).chemicalFormula)
		{
			ammo.Remove(molecule);
		}
		
	}
	
	private List<MixedOutputType> CheckPossibleMaterials()
	{
		List<MixedOutputType> possibleMaterials = new List<MixedOutputType>();
		foreach (MixedOutput material in materialsDatabase)
		{
			bool canCreateMaterial = true;
			List<Molecule> possibleMolecules = PossibleMolecules(material);
			
			foreach (Molecule molecule in possibleMolecules)
			{
				int amountInFormula = AmountOfMolecule(molecule.type, material.chemicalFormula);
				int amountInAmmo = AmountOfMolecule(molecule.type, ammo);

				if (amountInAmmo < amountInFormula) canCreateMaterial = false;
			}
			
			if(canCreateMaterial) possibleMaterials.Add(material.type);
		}

		return possibleMaterials;
	}

	private List<Molecule> PossibleMolecules(MixedOutput material)
	{
		List<Molecule> possibleMolecules = new List<Molecule>();

		foreach (Molecule molecule in material.chemicalFormula)
		{
			if(!possibleMolecules.Contains(molecule)) possibleMolecules.Add(molecule);
		}

		return possibleMolecules;
	}

	private MixedOutput ReturnMaterialOfSpecificType(MixedOutputType type)
	{
		foreach (MixedOutput material in materialsDatabase)
		{
			if (type == material.type) return material;
		}

		return null;
	}
	
	private int AmountOfMolecule(MoleculeType type, List<Molecule> list)
	{
		int count = 0;

		foreach (Molecule molecule in list)
		{
			if (molecule.type == type) count++;
		}
		
		return count;
	}
}