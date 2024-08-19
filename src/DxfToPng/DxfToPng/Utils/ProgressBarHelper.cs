using System;
using System.Windows.Forms;

public class ProgressBarHelper
{
    private ProgressBar progres;
    private Control control;
    private int count = 0;

    public ProgressBarHelper(ProgressBar _progres, Control _control)
    {
        progres = _progres;
        control = _control;
    }

    public void SetupProgress(int max)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new Action<int>(SetupProgress), max);
        }
        else
        {
            progres.Value = 0;
            count = 0;
            progres.Maximum = max;
            progres.Refresh();
        }
    }
    private void IncreaseCount()
    {
        count++;
    }
    public void UpdateProgress()
    {
        IncreaseCount();
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(UpdateProgress), count);
        }
        else
        {
            progres.Value = count;
            progres.Refresh();
        }
    }

    public void ClearProgress()
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(ClearProgress));
        }
        else
        {
            progres.Value = 0;
            count = 0;
            progres.Refresh();
        }
    }
}
