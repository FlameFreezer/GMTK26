using System;

public abstract class Plant {
	public PlantTypes.Type type;

	protected int _ticksUntilHarvest = 0;
	protected UInt32 _id = UInt32.MaxValue;

    public event Action<UInt32> OnHarvestRequested;

	public void AssignId(UInt32 id) {
		_id = id;
	}

	public abstract void Tick();

	protected void InvokeOnHarvestRequested() {
		OnHarvestRequested?.Invoke(_id);
	}
}

public class EyeWeed : Plant {
	public override void Tick() {
		if(_ticksUntilHarvest < 1) {
			InvokeOnHarvestRequested();
		}
	}
}
