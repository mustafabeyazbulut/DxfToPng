using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class DraggableForm : Form
{
    private bool isDragging = false;
    private Point lastCursorPos;
    private Color borderColor = Color.Black;
    private int borderThickness = 3;
    private int radius = 30;
    private int margin = 2;

    public DraggableForm()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.DoubleBuffered = true;
        this.BackColor = Color.FromArgb(24, 40, 56);
        this.FormBorderColor = Color.FromArgb(24, 40, 56);
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.Padding = new Padding(margin); // Set the padding for the form
    }

    public Color FormBorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    public int FormBorderThickness
    {
        get { return borderThickness; }
        set { borderThickness = value; this.Invalidate(); }
    }

    public int FormRadius
    {
        get { return radius; }
        set { radius = value; this.Invalidate(); }
    }

    public int FormMargin
    {
        get { return margin; }
        set { margin = value; this.Padding = new Padding(margin); this.Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // Create a rounded rectangle path
        GraphicsPath oPath = new GraphicsPath();
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        oPath.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
        oPath.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
        oPath.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
        oPath.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
        oPath.CloseAllFigures();

        this.Region = new Region(oPath);
        // Draw the border
        using (Pen pen = new Pen(borderColor, borderThickness))
        {
            pen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawPath(pen, oPath);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            lastCursorPos = Control.MousePosition;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (isDragging)
        {
            Point currentCursorPos = Control.MousePosition;
            int deltaX = currentCursorPos.X - lastCursorPos.X;
            int deltaY = currentCursorPos.Y - lastCursorPos.Y;
            Point newLocation = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            this.Location = newLocation;
            lastCursorPos = currentCursorPos;
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        isDragging = false;
    }

    //protected override void OnLayout(LayoutEventArgs levent)
    //{
    //    base.OnLayout(levent);

    //    // Döngü içindeki her kontrolün sınırlarını ayarlayın
    //    foreach (Control control in this.Controls)
    //    {
    //        // Margin içinde sınırları ayarlayın
    //        control.Left = Math.Max(margin, control.Left);
    //        control.Top = Math.Max(margin, control.Top);

    //        // Form boyutuna göre kontrol genişliğini ve yüksekliğini ayarlayın
    //        control.Width = Math.Min(this.ClientSize.Width - 2 * margin, control.Width);
    //        control.Height = Math.Min(this.ClientSize.Height - 2 * margin, control.Height);
    //    }
    //}

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // DraggableForm
        // 
        this.ClientSize = new System.Drawing.Size(300, 200);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "DraggableForm";
        this.ResumeLayout(false);
    }
}