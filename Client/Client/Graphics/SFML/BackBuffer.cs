namespace Client.Graphics.SFML
{
    public class BackBuffer : System.Windows.Forms.Control
    {
        public BackBuffer(System.Windows.Forms.Form form, int width, int height, int left, int top) {
            // Create the BackBuffer.
            this.Left = left;
            this.Top = top;
            this.Height = height;
            this.Width = width;

            // Add it to the form.
            form.Controls.Add(this);
        }

        public System.IntPtr GetHandle() {
            return this.Handle;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            // base.OnPaint(e);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent) {
            // base.OnPaintBackground(pevent);
        }
    }
}
