using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data;
using Telerik.Windows.Controls.Data.DataForm;


namespace SunSeven.Models
{
    public class CustomKeyboardCommandProvider : DataFormCommandProvider
    {
        public CustomKeyboardCommandProvider()
            : base(null)
        {

        }

        public CustomKeyboardCommandProvider(RadDataForm dataForm)
            : base(dataForm)
        {
            this.DataForm = dataForm;
        }

        //public override List<DelegateCommandWrapper> ProvideCommandsForKey(KeyEventArgs args)
        //{
        //    List<DelegateCommandWrapper> actionsToExecute = base.ProvideCommandsForKey(args);

        //    if (args.Key == Key.Enter)
        //    {
        //        if (args.OriginalSource is TextBox && (args.OriginalSource as TextBox).AcceptsReturn)
        //        {
        //            TextBox textBox = args.OriginalSource as TextBox;

        //            actionsToExecute.Clear();

        //            StringBuilder stringBuilder = new StringBuilder(textBox.Text);
        //            stringBuilder.Insert(textBox.SelectionStart, Environment.NewLine); // add new line
        //            textBox.Text = stringBuilder.ToString();

        //            textBox.SelectionStart += 3; // move cursor to new line
        //            textBox.Focus();
        //        }
        //        else
        //        {
        //            actionsToExecute.Clear();
        //            actionsToExecute.Add(new DataFormDelegateCommandWrapper(RadDataFormCommands.CommitEdit, this.DataForm));
        //        }
        //    }

        //    return actionsToExecute;
        //}
        public override List<DelegateCommandWrapper> ProvideCommandsForKey(KeyEventArgs args)
        {
            List<DelegateCommandWrapper> actionsToExecute = base.ProvideCommandsForKey(args);

            if (args.Key == Key.Enter)
            {
                if (args.OriginalSource is TextBox && (args.OriginalSource as TextBox).AcceptsReturn)
                {
                    TextBox TB = args.OriginalSource as TextBox;

                    actionsToExecute.Clear();
                    TB.SelectionStart = TB.Text.Length;
                    TB.Focus();
                }
                else
                {
                    actionsToExecute.Clear();
                    actionsToExecute.Add(new DataFormDelegateCommandWrapper(RadDataFormCommands.CommitEdit, this.DataForm));
                }
            }

            if (actionsToExecute.Count > 0)
            {
                actionsToExecute.Add(new DataFormDelegateCommandWrapper(new Action(() => { this.DataForm.AcquireFocus(); }), 100, this.DataForm));
                args.Handled = true;
            }
            return actionsToExecute;
        }
    }
}
