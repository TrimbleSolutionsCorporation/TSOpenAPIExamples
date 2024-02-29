using System;
using System.Windows.Forms;
using Tekla.Structures.Dialog;

public partial class SpliceConnection : PluginFormBase
{
    public SpliceConnection()
    {
        InitializeComponent();
    }

    private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e)
    {
        this.Apply();
    }

    private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e)
    {
        this.Close();
    }

    private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e)
    {
        this.Get();
    }

    private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e)
    {
        this.Modify();
    }

    private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
    {
        this.Apply();
        this.Close();
    }

    private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
    {
        this.ToggleSelection();
    }

    private Control GetEnableCheckBox(string attributeName, Control parent)
    {
        Control foundCheckBox = null;

        for (int i = 0; i < parent.Controls.Count && foundCheckBox == null; i++)
        {
            Control control = parent.Controls[i];

            if (control.GetType() == typeof(CheckBox))
            {
                CheckBox checkBox = control as CheckBox;

                if (attributeName == structuresExtender.GetAttributeName(checkBox))
                {
                    foundCheckBox = checkBox;
                }
            }
            else
            {
                foundCheckBox = GetEnableCheckBox(attributeName, control);
            }
        }

        return foundCheckBox;
    }

    private void SetThisControlEnableCheckBoxChecked(object sender)
    {
        Control thisControl = sender as Control;

        if (thisControl != null)
        {
            Control control = GetEnableCheckBox(structuresExtender.GetAttributeName(thisControl), this);
            CheckBox enableCheckBox = control as CheckBox;

            if (enableCheckBox != null)
            {
                enableCheckBox.Checked = true;
            }
        }
    }

    private void anyTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        SetThisControlEnableCheckBoxChecked(sender);
    }

    private void anyComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetThisControlEnableCheckBoxChecked(sender);
    }

    // Use the following method if UI contains ImageListComboBox controls

    //private void ImageListComboBoxSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ComboBox comboBox = sender as ComboBox;

    //    if (comboBox != null)
    //    {
    //        ImageListComboBox imageListComboBox = comboBox.Parent as ImageListComboBox;

    //        if (imageListComboBox != null)
    //        {
    //            SetThisControlEnableCheckBoxChecked(imageListComboBox);
    //        }
    //    }
    //}
}
