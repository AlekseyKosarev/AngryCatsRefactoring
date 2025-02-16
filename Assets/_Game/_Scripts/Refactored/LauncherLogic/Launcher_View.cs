using UnityEngine;

public class Launcher_View : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    // [SerializeField] private ParticleSystem _launchEffect;

    public void EnableEffects()
    {
        // _launchEffect.Play();
    }

    public void DisableEffects()
    {
        // _launchEffect.Stop();
    }

    public void DrawTrajectory(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }

    public void ClearTrajectory()
    {
        _lineRenderer.positionCount = 0;
    }
}