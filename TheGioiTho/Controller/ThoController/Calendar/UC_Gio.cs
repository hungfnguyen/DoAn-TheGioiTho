using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.All_Calendar_Control
{
    public partial class UC_Gio : UserControl
    {
        private bool _isBusy;
        private FlowLayoutPanel _flowLayoutPanel;
        private bool _isSelected;
        private string _selectedGio;

        public event EventHandler<string> GioSelected;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    this.BackColor = Color.Orange;
                    this.Enabled = false;
                }
                else
                {
                    this.BackColor = Color.White;
                    this.Enabled = true;
                }
            }
        }

        public string GioText
        {
            get { return lblGio.Text; }
            set { lblGio.Text = value; }
        }

        public UC_Gio(FlowLayoutPanel flowLayoutPanel, string gio)
        {
            InitializeComponent();
            IsBusy = false;
            _flowLayoutPanel = flowLayoutPanel;
            _isSelected = false;
            _selectedGio = gio;
        }

        private void UC_Gio_Click(object sender, EventArgs e)
        {
            if (!_isBusy && !_isSelected)
            {
                foreach (Control control in _flowLayoutPanel.Controls)
                {
                    if (control is UC_Gio uC_Gio)
                    {
                        if (uC_Gio != sender && uC_Gio._isBusy == false)
                        {
                            uC_Gio._isSelected = false;
                            uC_Gio.BackColor = Color.White;
                        }
                    }
                }

                this.BackColor = Color.Green;
                _isSelected = true;
                _selectedGio = lblGio.Text;

                GioSelected?.Invoke(this, _selectedGio);
            }
            else if (_isSelected)
            {
                this.BackColor = Color.White;
                _isSelected = false;
                _selectedGio = null;

                GioSelected?.Invoke(this, _selectedGio);
            }
        }

        private void lblGio_Click(object sender, EventArgs e)
        {
            if (!_isBusy && !_isSelected)
            {
                foreach (Control control in _flowLayoutPanel.Controls)
                {
                    if (control is UC_Gio uC_Gio)
                    {
                        if (uC_Gio != sender && uC_Gio._isBusy == false)
                        {
                            uC_Gio._isSelected = false;
                            uC_Gio.BackColor = Color.White;
                        }
                    }
                }

                this.BackColor = Color.Green;
                _isSelected = true;
                _selectedGio = lblGio.Text;

                GioSelected?.Invoke(this, _selectedGio);
            }
            else if (_isSelected)
            {
                this.BackColor = Color.White;
                _isSelected = false;
                _selectedGio = null;

                GioSelected?.Invoke(this, _selectedGio);
            }
        }
    }
}
