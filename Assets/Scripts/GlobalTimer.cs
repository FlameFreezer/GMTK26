using System;
using TMPro;
using UnityEngine;

public class GlobalTimer : MonoBehaviour {
	[SerializeField]
	private int _ticksRemaining = 500;

	[SerializeField]
	private int _ticksPerClick = 50;

	[SerializeField]
	private double _costMutliplierPerClick = 1.25;

	[SerializeField]
	private double _addTimeCost = 200;

	[SerializeField]
	private TextMeshProUGUI _display;

	void Start() {
		Game.Instance().EventBus().onTick += DecrementTimer;

		UpdateDisplay();
	}

	public void AddTime() {
		Player player = Game.Instance()._player.GetComponent<Player>();
		if(player.money < _addTimeCost)
		{
			Debug.Log($"{player.money} is not enough to afford cost of {_addTimeCost} to add time");
			return;
		}
		//Make sure some casting shenanigans can't cause money to overflow
		if ((uint)_addTimeCost > player.money) player.money = 0;
		else player.money -= (uint)_addTimeCost;

		_ticksRemaining += _ticksPerClick;
		_addTimeCost *= _costMutliplierPerClick;

		UpdateDisplay();
	}

	private void DecrementTimer() {
		_ticksRemaining--;

		UpdateDisplay();

		if(_ticksRemaining < 1) {
			Game.Instance().EventBus().OnGlobalTimerExhausted();
		}
	}

	private void UpdateDisplay() {
		_display.text = $"{_ticksRemaining}";
	}
}
