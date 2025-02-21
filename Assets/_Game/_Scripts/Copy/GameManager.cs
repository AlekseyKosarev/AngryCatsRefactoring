using System;
// using BuildSystem;
// using MenuAndUI;

namespace _Game._Scripts.Copy
{
    public class GameManager: Singleton<GameManager>
    {

        public Action OnStartGame;//run sim
        public Action OnStopGame;//stop sim
        public Action OnEndGame;//finish sim?

        public bool startGame;
        public bool stopGame;
        public bool inGame;
        private void Update()
        {
            if (startGame)
            {
                StartGame();
                inGame = true;
                startGame = false;
            }
            if (stopGame)
            {
                StopGame();
                inGame = false;
                stopGame = false;
            }
        }

        public void StartGame(Action<bool> callback = null)
        {
            // var status = false;
            // if (CheckStartGame())
            // {
            //     OnStartGame?.Invoke();
            //     status = true;
            // }
            // else
            // {
            //     status = false;
            // }
            // callback?.Invoke(status);
            OnStartGame?.Invoke();//<-----------
        }
        public void StopGame()
        {
            OnStopGame?.Invoke();
        }
        public void EndGame()
        {
            OnEndGame?.Invoke();
        }
    

        // private bool CheckStartGame()
        // {
        //     return TilesController.Instance.CheckContactsTiles();
        // }//check contacts
    
    }
}
