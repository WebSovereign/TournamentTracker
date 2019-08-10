using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }

                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information.", "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            // Check to see if the text was successfully parsed into an integer.
            if (!placeNumberValidNumber)
            {
                output = false;
                MessageBox.Show("The value you entered is not an integer", "Not an integer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check to see if the integer's value was >= 1.
            if (placeNumber < 1)
                output = false;
            // Check to see if the name value has anything in it.
            if (placeNameValue.Text.Length == 0)
                output = false;

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
                output = false;

            if (prizeAmount <= 0 && prizePercentage <= 0)
                output = false;

            if (prizePercentage < 0 || prizePercentage > 100)
                output = false;

            return output;
        }

        private void PrizePercentageValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
