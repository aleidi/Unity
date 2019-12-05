public class ButtonBase
{
    public enum ButtonState{
        ButtonDown,
        ButtonUp
    };

    public delegate void Button();
    public event Button EventButtonDown;
    public event Button EventButtonUp;

    protected string m_sName;
    protected bool m_bIsPressed;
    protected bool m_bIsReleased;
    protected float m_fPressDuration;

    public ButtonBase()
    {
        m_sName = "";
    }

    public ButtonBase(string name)
    {
        m_sName = name;
    }

    public void OnButtonUp()
    {
        if(null == EventButtonUp)
        {
            return;
        }
        EventButtonUp.Invoke();
    }

    public void OnButtonDown()
    {
        if(null == EventButtonDown)
        {
            return;
        }
        EventButtonDown.Invoke();
    }

    public void SetName(string name) { m_sName = name; }
    public string GetName() { return m_sName; }
    public bool IsPressed() { return m_bIsPressed; }
    public void OnPress(bool isPressed) { m_bIsPressed = isPressed; }
    public bool IsReleased() { return m_bIsReleased; }
    public void OnReleased(bool isReleased) { m_bIsReleased = isReleased; }
    public float GetPressDuration() { return m_fPressDuration; }
    public void UpdatePressDuration(float var) { m_fPressDuration += var; }
    public void ResetPressDuration() { m_fPressDuration = 0; }
}
