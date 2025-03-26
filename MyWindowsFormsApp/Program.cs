using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyWindowsFormsApp
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyForm form = new MyForm("Clickable form");
            Application.Run(form);
        }
        public class MyForm : Form
        {
            private bool _isApplicationWorking = true;
            private bool _isMouseOnForm = false;
            public MyForm(string title)
            {
                Text = title;
                Height = 600;
                Width = 800;
                StartPosition = FormStartPosition.CenterScreen;

                Button exitButton = CreateButton(new Size(100, 20), new Point(Width - 125, +10), "CloseApp");
                exitButton.Click += (sender, e) => _isApplicationWorking = false;
                Label label = CreateLable(new Size(200, 15), new Point(300,300),"You could double click on this form!");
                DoubleClick += (sender, e) => ChangeLableColor(label);
                MouseEnter += (sender, e) => _isMouseOnForm = true;
                MouseLeave += (sender, e) => _isMouseOnForm = false;
            }

            private void ChangeLableColor(Label label)
            {
                if (_isMouseOnForm)
                {
                    if(label.ForeColor == Color.Green)
                    {
                        label.Text = "You could double click on this form!";
                        label.ForeColor = Color.Black;
                    }
                    else
                    {
                        label.Text = "You could double click again";
                        label.ForeColor = Color.Green;
                    }
                }
            }

            private void SetCommonParameters(Control element, Size size, Point position, string title)
            {
                element.Size = size;
                element.Location = (Point)position;
                element.Text = title;
                Controls.Add(element);
            }
            private Button CreateButton(Size size, Point position, string title)
            {
                Button button = new Button();
                SetCommonParameters(button, size, position, title);
                return button;
            }
            private Label CreateLable(Size size, Point position, string title)
            {
                Label label = new Label();
                SetCommonParameters(label, size, position, title);
                return label;
            }

        
        }
    }


}
