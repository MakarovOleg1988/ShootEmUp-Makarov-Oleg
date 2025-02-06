public interface IGameStateListener{};

public interface IStartMainMenuListener: IGameStateListener
{
    void StartMainMenu();
}

public interface IStartGameListener: IGameStateListener
{
    void StartGame();
}

public interface IPauseGameListener: IGameStateListener
{
    void PauseGame();
}

public interface IResumeGameListener: IGameStateListener
{
    void ResumeGame();
}

public interface IFinishGameListener: IGameStateListener
{
    void FinishGame();
}
