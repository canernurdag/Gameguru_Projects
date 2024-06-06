namespace Assets.Scripts.Runtime.Managers._SaveManager
{
	public interface ISaveSystem
	{
		void Save();
		void Load();
		SaveState SaveState { get; set; }
	}
}