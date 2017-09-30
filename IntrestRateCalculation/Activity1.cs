using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace IntrestRateCalculation
{
    [Activity(Label = "IntrestRateCalculation", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button buttontranslate = FindViewById<Button>(Resource.Id.buttonCalculate);
            EditText textTotalLoan = FindViewById<EditText>(Resource.Id.editTextTotalLoan);
            EditText textPayPerMonth = FindViewById<EditText>(Resource.Id.editTextPayPerMonth);
            EditText textTotalMonths = FindViewById<EditText>(Resource.Id.editTextTotalMonths);
            

            //EditText textTotalLoan = FindViewById<EditText>(Resource.Id.editTextTotalLoan);
            buttontranslate.Click += (object sender, EventArgs e) =>
                {
                    int totalIterations=400;
                    int totalMonths=0;
                    double totalLoan = 0;
                    double tempTotalLoan = 0;
                    double payPerMonth = 0;
                    double intrestRate = 15;
                    string messageToUser = "";
                    try
                    {
                         totalLoan = double.Parse(textTotalLoan.Text);
                         tempTotalLoan = totalLoan;
                         payPerMonth = double.Parse(textPayPerMonth.Text);
                         totalMonths = int.Parse(textTotalMonths.Text);
                         for (int i = 1; i < totalIterations; i++)
                         {
                             tempTotalLoan = totalLoan;
                             for (int j = 0; j < totalMonths; j++)
                             {
                                 tempTotalLoan = tempTotalLoan + tempTotalLoan * intrestRate / 1200 - payPerMonth;
                             }
                             if (tempTotalLoan > payPerMonth)
                             {
                                 intrestRate-=0.25;
                             }
                             else if (tempTotalLoan < 0)
                             {
                                 intrestRate+=0.25;
                             }
                             else
                             {
                                 break;
                             }
                         }
                         
                        
                             messageToUser = "Intrest Rate is: " + intrestRate.ToString()+" %\n plus "+((int)tempTotalLoan).ToString()+" Toman";

                         

                        var callDialog = new AlertDialog.Builder(this);
                        callDialog.SetMessage(messageToUser);
                        // callDialog.SetNeutralButton(
                        //callDialog.SetNeutralButton("Ok", delegate
                        // {
                        // Create intent to dial phone
                        // var callIntent = new Intent(Intent.ActionCall);
                        //  callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                        // StartActivity(callIntent);
                        //  });
                        callDialog.SetNegativeButton("OK", delegate { });

                        // Show the alert dialog to the user and wait for response.
                        callDialog.Show();
                    }
                    catch (Exception ex)
                    {

                    }
                };


            

           
        }
    }
}

