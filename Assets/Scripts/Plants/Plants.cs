using System;

public abstract class Plant {
	public PlantTypes.Type type;

	public int ticksUntilHarvest = 0;
	protected UInt32 _id = UInt32.MaxValue;

    public event Action<UInt32> OnHarvestRequested;

	public void AssignId(UInt32 id) {
		_id = id;
	}

	public abstract void Tick();

	public abstract void Harvest(Func<UInt32, GridQueryConfig, Func<Plant, bool>, UInt32> adjacentQueryCallback);

	protected void InvokeOnHarvestRequested() {
		OnHarvestRequested?.Invoke(_id);
	}
}

public class EyeWeed : Plant {
	private UInt32 _payout = 3;

	public override void Tick() {
		if(ticksUntilHarvest < 1) {
			InvokeOnHarvestRequested();
		}
	}

	public override void Harvest(Func<UInt32, GridQueryConfig, Func<Plant, bool>, UInt32> adjacentQueryCallback) {
		if(adjacentQueryCallback.Invoke(_id, new() { matchesRequired = 1 }, _Criteria) > 0) {
			_payout = 9;
		}

		return;

		bool _Criteria(Plant subject) {
			return subject.type == PlantTypes.Type.EYE_WEED && subject.ticksUntilHarvest < 1;
		}
	}
}
