using UnityEngine;

public class TestInput: MonoBehaviour
{
    public BaseMaterial materialPrefab;
    //при щелчке мыши кидаю рейкаст
    //проверяю на попадание
    //если нужный то вызываю метод в материале - SetInput

    private void Update()
    {
        //switch pause|game - space
        if (Input.GetKeyDown(KeyCode.P))
        {
            materialPrefab.Pause();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            materialPrefab.Resume();
        }

        //build mode
        if (Input.GetKeyDown(KeyCode.B))
        {
            materialPrefab.EnterBuildMode();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            materialPrefab.ExitBuildMode();
        }
    }

    

}