using UnityEngine;

public class UIScreenSwitcher: MonoBehaviour
{
    public GameObject buildScreen;
    public GameObject menuScreen;
    public GameObject gameScreen;
    
    public GameObject pauseScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    
    private void SetActiveBuildScreen(bool active) => buildScreen.SetActive(active);
    private void SetActiveMenuScreen(bool active) => menuScreen.SetActive(active);
    private void SetActiveGameScreen(bool active) => gameScreen.SetActive(active);
    
    public void SetActivePauseScreen(bool active) => pauseScreen.SetActive(active);
    private void SetActiveWinScreen(bool active) => winScreen.SetActive(active);
    private void SetActiveLoseScreen(bool active) => loseScreen.SetActive(active);
    
    
    public void SwitchToBuildScreen()
    {
        SetActiveGameScreen(false);
        SetActiveMenuScreen(false); 
        SetActivePauseScreen(false);
        
        SetActiveBuildScreen(true);
    }
    public void SwitchToMenuScreen()
    {
        SetActiveGameScreen(false);
        SetActivePauseScreen(false);
        SetActiveBuildScreen(false);
        
        SetActiveMenuScreen(true); 
    }
    public void SwitchToGameScreen()
    {
        SetActivePauseScreen(false);
        SetActiveBuildScreen(false);
        SetActiveMenuScreen(false); 
        
        SetActiveGameScreen(true);
    }
}