using System;
using System.Collections.Generic;

public class Grid {
    private List<Plant> _plants;

	public UInt32 width;
	public UInt32 height;

	public void InvokeTick(PlantTypes.Type type) {
		foreach(Plant plant in _plants) {
			if(plant.type == type) {
				plant.Tick();
			}
		}
	}

	public bool GetPlantAtGridPosition(UInt32 x, UInt32 y, out Plant result) {
		result = null;

		if(_plants.Count < y * width + x) { return false; }

		result = _plants[(int)(y * width + x)];
		return true;
	}

	// assumes there's not already a plant at this position.
	// TODO -- should we handle checking validity at the
	// input level?
	public void SpawnPlantAtGridPosition(UInt32 x, UInt32 y, PlantTypes.Type type) {
		UInt32 plantId = y * width + x;

		Plant newPlant = null;

		switch(type) {
			case PlantTypes.Type.EYE_WEED:
				newPlant = new EyeWeed();
				break;
			default: return; // TODO - send an error
		}

		newPlant.AssignId(plantId);
		_plants[(int)plantId] = newPlant;
	}
}
