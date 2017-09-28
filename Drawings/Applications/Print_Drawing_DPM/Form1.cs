using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Print_Drawing_DPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ExecutePart1()) return;
            if (!ExecutePart2()) return;

            if (!ExecutePart3())
                return;
            else
                label4.Visible = true;


        }

        private bool ExecutePart1()
        {
            label1.Enabled = true;
            bool result = Logic.CreateAndSelectNewPart();

            if (result)
            {
                label1.Text = label1.Text + "  DONE!";
                label1.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                label1.Text = label1.Text + "  WRONG!";
                label1.ForeColor = System.Drawing.Color.Red;
            }

            return result;
        }

        private bool ExecutePart2()
        {
            label2.Enabled = true;
            bool result = Logic.CreateAndOpenNewDrawing();

            if (result)
            {
                label2.Text = label2.Text + "  DONE!";
                label2.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                label2.Text = label2.Text + "  WRONG!";
                label2.ForeColor = System.Drawing.Color.Red;
            }

            return result;
        }

        private bool ExecutePart3()
        {
            label3.Enabled = true;
            bool result = Logic.PrintActiveDrawing();

            if (result)
            {
                label3.Text = label3.Text + "  DONE!";
                label3.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                label3.Text = label3.Text + "  WRONG!";
                label3.ForeColor = System.Drawing.Color.Red;
            }

            return result;
        }
    }
}
