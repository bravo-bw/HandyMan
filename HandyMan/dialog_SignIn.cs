using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HandyMan
{
	public class OnSignInEventArgs : EventArgs
	{
		private string mUserName;
		private string mPassword;

		public string UserName
		{
			get { return mUserName; }
			set { mUserName = value; }
		}

		public string Password
		{
			get { return mPassword; }
			set { mPassword = value; }
		}

		public OnSignInEventArgs(string userName, string password) : base()
		{
			UserName = userName;
			Password = password;
		}
	}

	public class dialog_SuignIn : DialogFragment
	{
		private EditText mTxtUserName;
		private EditText mTxtPassword;
		private Button mBtnSignIn;

		public event EventHandler<OnSignInEventArgs> mOnSignInComplete;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.dialog_sign_in, container, false);

			mTxtUserName = view.FindViewById<EditText>(Resource.Id.txtUserName);
			mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
			mBtnSignIn = view.FindViewById<Button>(Resource.Id.btnDialogSignIn);

			mBtnSignIn.Click += mBtnSignIn_Click;

			return view;
		}

		void mBtnSignIn_Click(object sender, EventArgs e)
		{
			//User has clicked the sign up button
			mOnSignInComplete.Invoke(this, new OnSignInEventArgs(mTxtUserName.Text, mTxtPassword.Text));
			this.Dismiss();
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Set the title bar to invisible.
			base.OnActivityCreated(savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;  // Set the animation.
		}
	}
}

