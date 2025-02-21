using UnityEngine;

public class Launcher_View : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRope;
    [SerializeField] private LineRenderer lineTrajectory;
    
    [SerializeField] private int verts = 10;
    [SerializeField] private float simulationTimeStep = 0.1f;
    [SerializeField] private LayerMask collisionMask;
    // [SerializeField] private ParticleSystem _launchEffect;

    public void EnableEffects()
    {
        // _launchEffect.Play();
    }

    public void DisableEffects()
    {
        // _launchEffect.Stop();
    }
    public void DrawTrajectory(Vector2 startPos, Vector2 direction, float velocity, float mass)
    {
        direction = -direction; // Инвертируем направление

        Vector2 initialVelocity = direction * velocity; // Начальная скорость
        lineTrajectory.positionCount = verts; // Устанавливаем количество точек

        Vector2 pos = startPos;
        Vector2 vel = initialVelocity / mass; // Начальная скорость (учитываем массу)
        Vector2 grav = Physics.gravity; // Гравитация

        for (int i = 0; i < verts; i++)
        {
            lineTrajectory.SetPosition(i, new Vector3(pos.x, pos.y, 0));

            Vector2 nextPos = pos + vel * simulationTimeStep;

            if (CheckTrajectoryCollision(pos, nextPos, out Vector2 hitPoint))
            {
                lineTrajectory.SetPosition(i, new Vector3(hitPoint.x, hitPoint.y, 0));

                lineTrajectory.positionCount = i + 1;
                break; // Завершаем расчет
            }

            vel += grav * simulationTimeStep;
            pos = nextPos;
        }
    }

    private bool CheckTrajectoryCollision(Vector2 startPos, Vector2 endPos, out Vector2 hitPoint)
    {
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, collisionMask);

        if (hit.collider != null) // Если есть коллизия
        {
            hitPoint = hit.point; // Возвращаем точку пересечения
            return true;
        }

        hitPoint = Vector2.zero; // Если коллизии нет, возвращаем нулевую точку
        return false;
    }
    public void ClearTrajectory()
    {
        lineTrajectory.positionCount = 0;
    }
    public void DrawRope(Vector2 startPos, Vector2 endPos)
    {
        lineRope.positionCount = 2;
        lineRope.SetPosition(0, startPos);
        lineRope.SetPosition(1, endPos);
    }

    public void ClearRope()
    {
        lineRope.positionCount = 0;
    }
}