using System;

public static class GameManager{
	public static event Action<GameState> OnGameStateChange;
	public static event EventHandler OnUpdateCurrentLevel;

	public static LevelSpawnPoints CurrentLevel {get; private set;}

	public static GameState CurrentState {get; private set;}

	public static void UpdateGameState(GameState state){
		CurrentState = state;

        switch (CurrentState){
            case GameState.MainMenu:
                break;
            case GameState.Game: 
                break;
            case GameState.WinScreen:
                break;
        }

        OnGameStateChange?.Invoke(state);
    }
	
	public static void UpdateCurrentLevel(LevelSpawnPoints incomingLevel){
		CurrentLevel = incomingLevel;
		OnUpdateCurrentLevel?.Invoke(null, EventArgs.Empty);
	}
}

public enum GameState{
	MainMenu,
	Game,
	WinScreen
}
