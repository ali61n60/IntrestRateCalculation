using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IntrestRateCalculation.Models;

namespace IntrestRateCalculation
{
    [Activity(Label = "IntrestRateCalculation", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private Button _buttonCalculate;
        private EditText _editTextTotalLoan;
        private EditText _editTextPayPerMonth;
        private EditText _editTextTotalMonths;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            initComponents();
        }

        private void initComponents()
        {
            _buttonCalculate = FindViewById<Button>(Resource.Id.buttonCalculate);
            _buttonCalculate.Click += ButtonCalculateClick;
            _editTextTotalLoan = FindViewById<EditText>(Resource.Id.editTextTotalLoan);
            _editTextPayPerMonth = FindViewById<EditText>(Resource.Id.editTextPayPerMonth);
            _editTextTotalMonths = FindViewById<EditText>(Resource.Id.editTextTotalMonths);

        }

        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();
            double totalLoan = 0;
            bool resultTotalLoan = double.TryParse(_editTextTotalLoan.Text, out totalLoan);
            int totalMonths = 0;
            bool resultTotalMonth = int.TryParse(_editTextTotalMonths.Text, out totalMonths);
            double payPerMonth = 0;
            bool resultPayPerMonth = double.TryParse(_editTextPayPerMonth.Text, out payPerMonth);
            if (!resultTotalLoan || !resultTotalMonth || !resultPayPerMonth)
            {
                //Error in conversion
                //return
            }
            try
            {
                double intrestRate = calculator.CalculateIntrestRatePercent(totalLoan, payPerMonth, totalMonths);
                string message = $"Intrest Rate is: {intrestRate}%";
                showMessage(message);
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void showMessage(string message)
        {
            var callDialog = new AlertDialog.Builder(this);
            callDialog.SetMessage(message);
            callDialog.SetNegativeButton("OK", delegate { });
            callDialog.Show();
        }
    }
}

