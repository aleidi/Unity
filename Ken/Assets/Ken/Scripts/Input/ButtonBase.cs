public class ButtonBase
{
    public delegate void ButtonDown();
    public event ButtonDown EventButtonDown;

    public delegate void ButtonUp();
    public event ButtonUp EventButtonUp;

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
