using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.WinUI
{
    public class Validator
    {
        public static bool ValidateControl(Control control, ErrorProvider err, string message)
        {
            bool _setError = false;
            if (control is TextBox && string.IsNullOrEmpty(control.Text))
                _setError = true;
            else if (control is ComboBox && (string.IsNullOrEmpty((control as ComboBox).Text) || (control as ComboBox).SelectedIndex < 0))
                _setError = true;
            else if (control is PictureBox && (control as PictureBox).Image == null)
                _setError = true;

            if (_setError)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
    }
}
