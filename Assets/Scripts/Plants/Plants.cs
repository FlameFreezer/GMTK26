using System;

public abstract class Plant {
	protected int _ticksUntilHarvest = 0;

	public PlantTypes.Type type;

    public event Action OnHarvestRequested;

	public abstract void Tick();
}
