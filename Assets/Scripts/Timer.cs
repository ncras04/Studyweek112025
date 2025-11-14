using System;
public class Timer
{
    private float m_time = 0;
    private float m_setTime;

    public event Action<Timer> timerEnd;

    private Action m_resetTime;

    public Timer(float _setTime, Action<Timer> _onTimerEnd)
    {
        m_setTime = _setTime;
        timerEnd = _onTimerEnd;

        SetTimer();
    }

    public void SetTimer()
    {
        m_time = m_setTime;
    }

    public void Update(float _deltaTime)
    {
        if (m_time > 0)
        {
            m_time -= _deltaTime;

            if (m_time <= 0)
                timerEnd?.Invoke(this);
        }
    }
}
