using System;

public class Timer
{
    private float _duration;
    private float _currentTime;
    private Action _onComplete;
    private bool _isRunning;

    public Timer(float duration)
    {
        _duration = duration;
        _currentTime = 0f;
        _isRunning = false;
    }

    public void Start(Action onComplete)
    {
        if (_isRunning) return; // Если таймер уже запущен, ничего не делаем

        _currentTime = 0f;
        _isRunning = true;
        _onComplete = onComplete; // Устанавливаем коллбек
    }

    public void Update(float deltaTime)
    {
        if (!_isRunning) return; // Если таймер не запущен, ничего не делаем

        _currentTime += deltaTime;

        if (_currentTime >= _duration)
        {
            _currentTime = _duration; // Ограничиваем текущее время до длительности
            _isRunning = false; // Останавливаем таймер
            _onComplete?.Invoke(); // Вызываем коллбек по завершении
        }
    }

    public void Reset()
    {
        _currentTime = 0f;
        _isRunning = false; // Останавливаем таймер
    }

    public bool IsRunning => _isRunning; // Свойство для проверки, запущен ли таймер
    public float CurrentTime => _currentTime; // Свойство для получения текущего времени
    public float Duration => _duration; // Свойство для получения длительности таймера
}