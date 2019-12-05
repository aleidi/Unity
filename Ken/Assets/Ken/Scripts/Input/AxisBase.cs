public class AxisBase
{
    public delegate void Axis(float value);
    public event Axis EventAxis;

    protected float m_fValue;
    protected string m_sName;

    public AxisBase() { }
    public AxisBase(string name)
    {
        m_sName = name;
    }

    public void OnAxisInvoke(float value)
    {
        if(null == EventAxis)
        {
            return;
        }
        EventAxis.Invoke(value);
    }

}
