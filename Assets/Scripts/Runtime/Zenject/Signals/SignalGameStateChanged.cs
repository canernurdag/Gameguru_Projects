using Assets.Scripts.Runtime.Managers._GameManager;

namespace Assets.Scripts.Runtime.Zenject.Signals
{
	public class SignalGameStateChanged
	{
		public GameStateType GameStateType;

		public SignalGameStateChanged(GameStateType gameStateType)
		{
			GameStateType = gameStateType;
		}
	}
}