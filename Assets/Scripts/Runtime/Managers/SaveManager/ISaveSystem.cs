namespace Assets.Scripts.Runtime.Managers.SaveManager
{
	public interface ISaveSystem
	{
		void Save();
		void Load();
		SaveState SaveState { get; set; }
	}
}