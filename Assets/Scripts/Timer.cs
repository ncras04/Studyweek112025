using System;
using UnityEngine;
public class Timer
{
    protected float m_time = 0;
    protected float m_setTime;

    protected event Action<Timer> timerEnd;

    private Action m_resetTime;

    public Timer(float _setTime, Action<Timer> _onTimerEnd)
    {
        m_setTime = _setTime;
        timerEnd = _onTimerEnd;
    }

    public void SetTimer()
    {
        m_time = m_setTime;
    }

    public virtual void Update(float _deltaTime)
    {
        if (m_time > 0)
        {
            m_time -= _deltaTime;

            if (m_time <= 0)
                InvokeEndTimer();
        }
    }
    protected void InvokeEndTimer()
    {
        timerEnd?.Invoke(this);
    }
}

public class EventTimer : Timer
{
    public event Action<float> IntervalReached
    {
        add
        {
            m_intervalReached -= value;
            m_intervalReached += value;
        }
        remove
        {
            m_intervalReached -= value;
        }
    }
    public float Interval { get => m_interval; private set => m_interval = value; }

    private event Action<float> m_intervalReached;
    private float m_interval;
    private float m_timeSinceInterval = 0;

    public EventTimer(float _interval, float _setTime, Action<Timer> _onTimerEnd, Action<float> _onCountdownInterval) : base(_setTime, _onTimerEnd)
    {
        m_interval = _interval;
        m_intervalReached = _onCountdownInterval;
    }

    public override void Update(float _deltaTime)
    {
        if (m_time > 0)
        {
            m_time -= _deltaTime;
            m_timeSinceInterval += _deltaTime;

            if (m_timeSinceInterval >= m_interval)
            {
                m_timeSinceInterval = m_timeSinceInterval - m_interval;
                m_intervalReached?.Invoke(m_time);
            }

            if (m_time <= 0)
                InvokeEndTimer();
        }
    }
}
