
using Game.Core.Entities.Interfaces;
using UnityEngine;

public class TargetReachListener : MonoBehaviour
{
	private IDestroyable _destroyableComponent;

	private void Start ()
	{
		_destroyableComponent = GetComponent<IDestroyable>();
		GetComponent<IMove>().OnReachTarget += DestroyMe;
	}

	private void DestroyMe()
	{
		_destroyableComponent.Destroy();
	}
}
