using System;
using System.Windows.Forms;

using Tekla.Structures.Model;

namespace TeklaEvents
{
    public partial class Form1 : Form
    {
        private Events ModelEvents { get; set; }
        private object _changedObjectHandlerLock = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ModelEvents = new Events();
                ModelEvents.SelectionChange += this.ModelEvents_SelectionChanged;
                ModelEvents.ModelObjectChanged += this.ModelEvents_ModelObjectChanged;
                ModelEvents.ModelSave += this.ModelEvents_ModelSave;
                ModelEvents.Interrupted += this.OnInterrupted;
                ModelEvents.TeklaStructuresExit += this.ModelEvents_TeklaExit;

                ModelEvents.Register();
                MessageBox.Show("Events activated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ModelEvents_ModelObjectChanged(System.Collections.Generic.List<ChangeData> changes)
        {
            lock (_changedObjectHandlerLock)
            {
                new System.Threading.Tasks.Task(delegate
                {
                    MessageBox.Show("ModelObject changed: " + changes[0].Type.ToString() + " Id: " + changes[0].Object.Identifier.ID.ToString() + " type: " + changes[0].Object.GetType().ToString());
                }).Start();
            };
        }

        private void ModelEvents_SelectionChanged()
        {
            MessageBox.Show("SelectionChanged");
        }

        private void ModelEvents_ModelSave()
        {
            MessageBox.Show("ModelSave");
        }
        
        private void OnInterrupted()
        {
            MessageBox.Show("Interrupted");
        }

        private void ModelEvents_TeklaExit()
        {
            ModelEvents.UnRegister();
            Application.Exit();
        }

        private void buttonDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                ModelEvents.UnRegister();
                MessageBox.Show("Events deactivated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ModelEvents.UnRegister();
        }   
    }
}
