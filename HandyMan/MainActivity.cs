using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace HandyMan
{
	[Activity(Label = "HandyMan", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private Button mButtonSignUp;
		private Button mButtonSignIn;
		private ProgressBar mProgressBar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			mButtonSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
			mButtonSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
			mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

			mButtonSignUp.Click += (object sender, EventArgs args) =>
			{
				//Pull up dialog
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_SuignUp signUpDialog = new dialog_SuignUp();
				signUpDialog.Show(transaction, "dialog frangment");

				signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
			};

			mButtonSignIn.Click += (object sender, EventArgs args) =>
			{
				//Pull up dialog
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_SuignIn signInDialog = new dialog_SuignIn();
				signInDialog.Show(transaction, "dialog frangment");

				signInDialog.mOnSignInComplete += signInDialog_mOnSignInComplete;
			};
		}
		void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
		{
			mProgressBar.Visibility = ViewStates.Visible;
			Thread thread = new Thread(ActLikeARequest);
			thread.Start();
		}

		void signInDialog_mOnSignInComplete(object sender, OnSignInEventArgs e)
		{
			mProgressBar.Visibility = ViewStates.Visible;
			Thread thread = new Thread(ActLikeARequest);
			thread.Start();
		}

		private void ActLikeARequest()
		{
			Thread.Sleep(3000);

			RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
		}
	}
}


