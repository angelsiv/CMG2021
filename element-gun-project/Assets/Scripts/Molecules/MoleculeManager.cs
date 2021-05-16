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
	[SerializeField] private MixedOutputType currentlyEquipped = MixedOutputType.None;
	[SerializeField] private int currentIndex = 0;

	public event Action<List<Molecule>,MixedOutputType> OnUIUpdated;
	
	private void Awake()
	{
		currentlyEquipped = materialsDatabase[0].type;
	}


	private void Start()
	{
		OnUIUpdated?.Invoke(ammo,currentlyEquipped);
	}

	private void DumpFuel()
	{
		ammo.Clear();
		OnUIUpdated?.Invoke(ammo,currentlyEquipped);
	}

	private void Update()
	{
		//Temporary, to be replaced with collect event
		if(Input.GetKeyDown(KeyCode.U)) AddAmmo(MoleculeType.Hydrogen);
		if(Input.GetKeyDown(KeyCode.I)) AddAmmo(MoleculeType.Oxygen);
		if(Input.GetKeyDown(KeyCode.O)) AddAmmo(MoleculeType.Potassium);
		if(Input.GetKeyDown(KeyCode.P)) AddAmmo(MoleculeType.Electron);
		/////////////////////////////////////////////////////////////////

		if (Input.GetKeyDown(KeyCode.V)) DumpFuel();
		if (Input.GetKeyDown(KeyCode.E)) IncreaseIndex();
		if (Input.GetKeyDown(KeyCode.Q)) DecreaseIndex();
		if (Input.GetMouseButtonDown(0)) OutputMaterial(currentlyEquipped);

		possibleOutput = CheckPossibleMaterials();
	}

	private void IncreaseIndex()
	{
		if (currentIndex < (materialsDatabase.Count-1))
		{
			currentIndex++;
		}
		else if(currentIndex == (materialsDatabase.Count-1))
		{
			currentIndex = 0;
		}

		currentlyEquipped = materialsDatabase[currentIndex].type;
		OnUIUpdated?.Invoke(ammo,currentlyEquipped);
	}
	private void DecreaseIndex()
	{
		if (currentIndex == 0)
		{
			currentIndex = materialsDatabase.Count - 1;
		}
		else if(currentIndex > 0)
		{
			currentIndex--;
		}
		
		
		currentlyEquipped = materialsDatabase[currentIndex].type;
		OnUIUpdated?.Invoke(ammo,currentlyEquipped);
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
			OnUIUpdated?.Invoke(ammo,currentlyEquipped);
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
		OnUIUpdated?.Invoke(ammo, currentlyEquipped );
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