using UnityEngine;

public class TestInput: MonoBehaviour
{
    public BaseMaterial materialPrefab;
    //при щелчке мыши кидаю рейкаст
    //проверяю на попадание
    //если нужный то вызываю метод в материале - SetInput

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputData inputData = new InputData(true);
            var material = HitMaterial();
            if (material != null)
            {
                material.SetInputData(inputData);
            }
        }
        //drag
        if (Input.GetMouseButton(0))
        {
            InputData inputData = new InputData(new MoveData(MoveType.Drag, Input.mousePosition));
            var material = HitMaterial();
            if (material != null)
            {
                material.SetInputData(inputData);
            }
        }
        
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

    private BaseMaterial HitMaterial()
    {
        // Получаем позицию мыши в мировых координатах
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        // Выполняем Raycast в 2D
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    
        if (hit.collider != null) // Проверяем, был ли найден объект
        {
            if (hit.transform.TryGetComponent<BaseMaterial>(out var material))
            {
                return material;
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object.");
        }
        return null;
    }

}