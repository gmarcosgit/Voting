using System;
using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text.Format;
using Android.Views;
using Android.Widget;

namespace Voting
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity //, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        
        Button nextLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            nextLogin = FindViewById<Button>(Resource.Id.btnWelcome);
            nextLogin.Click += NextLogin_Click;

            //textMessage = FindViewById<TextView>(Resource.Id.message);
            //BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            //navigation.SetOnNavigationItemSelectedListener(this);

        }

        private void NextLogin_Click(object sender, EventArgs e)
        {
            //WifiManager manager = (WifiManager)GetSystemService(WifiService);
            //int ip = manager.ConnectionInfo.IpAddress;

            StartActivity(typeof(LogInActivity));
            OverridePendingTransition(Resource.Animation.slideright, Resource.Animation.slideleft);
        }

        //public bool OnNavigationItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.navigation_home:
        //            textMessage.SetText(Resource.String.title_home);
        //            return true;
        //        case Resource.Id.navigation_dashboard:
        //            textMessage.SetText(Resource.String.title_dashboard);
        //            return true;
        //        case Resource.Id.navigation_notifications:
        //            textMessage.SetText(Resource.String.title_notifications);
        //            return true;
        //    }
        //    return false;
        //}
    }
}

 //<TextView
 //       android:id="@+id/message"
 //       android:layout_width="wrap_content"
 //       android:layout_height="wrap_content"
 //       android:layout_centerInParent="true"
 //       android:layout_marginLeft="@dimen/activity_horizontal_margin"
 //       android:layout_marginStart="@dimen/activity_horizontal_margin"
 //       android:layout_marginTop="@dimen/activity_vertical_margin"
 //       android:text="@string/title_home" />


    //<android.support.design.widget.BottomNavigationView
    //    android:id="@+id/navigation"
    //    android:layout_width="wrap_content"
    //    android:layout_height="wrap_content"
    //    android:layout_marginEnd="0dp"
    //    android:layout_marginStart="0dp"
    //    android:background="?android:attr/windowBackground"
    //    android:layout_alignParentBottom="true"
    //    app:menu="@menu/navigation" />