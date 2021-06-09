using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamBMI
{
    [Activity(Label = "BMI")]
    public class BMI : Activity
    {
        // Create your application here
        EditText txtHeight;
        EditText editWeight;
        EditText txtResult;
        TextView txtMessage;
        Button btnCalculate;
        ImageView img;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BMI);
            InitializeControls();
        }
        public void InitializeControls()
        {
            //Connect the fake controls to the real controls
            txtHeight = FindViewById<EditText>(Resource.Id.Height);
            editWeight = FindViewById<EditText>(Resource.Id.editWeight);
            txtResult = FindViewById<EditText>(Resource.Id.txtResult);
            txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            //Create a Button Click Method
            btnCalculate.Click += onBtnCalculateClick;
            img = FindViewById<ImageView>(Resource.Id.imgView1);

        }
        public void onBtnCalculateClick(object sender, EventArgs e)
        {
            if (editWeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the weight", ToastLength.Long).Show();
                return;
            }
            if (txtHeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the height", ToastLength.Long).Show();
                return;
            }
            CalcBMI();
        }
        private void CalcBMI()
        {
            //Stuff happens here
            double Height = Convert.ToDouble(txtHeight.Text);
            double Weight = Convert.ToDouble(editWeight.Text);
 double BMIAnswer = Weight / (Height * Height);
            txtResult.Text = Convert.ToString(Math.Round(BMIAnswer, 2));
            if (BMIAnswer <= 18.5)
            {
                txtMessage.Text = "Underweight";
            }
            else if (BMIAnswer >= 18.60 && BMIAnswer <= 24.99)
            {
                txtMessage.Text = "Normal";
                img.SetImageResource(Resource.Drawable.healthy);
            }
            else if (BMIAnswer > 25 && BMIAnswer <= 29.99)
            {
                txtMessage.Text = "Overweight";
            }
            else if (BMIAnswer > 30)
            {
                txtMessage.Text = "Obese ";
            }
            //Create a log system, use other tags if you want so you can filter them
            string tag = "BMI";
            Log.Info(tag, "Height = " + Height.ToString());
            Log.Info(tag, "Weight = " + Weight.ToString());
            Log.Info(tag, "Answer = " + BMIAnswer.ToString());
            Log.Info(tag, "Message = " + txtMessage.Text);
        }
    }
}
        

