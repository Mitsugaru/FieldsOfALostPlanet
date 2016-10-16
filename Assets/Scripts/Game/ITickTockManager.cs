

public interface ITickTockManager {
	
	bool Paused { get; }

	void SetPaused(bool state);

}
