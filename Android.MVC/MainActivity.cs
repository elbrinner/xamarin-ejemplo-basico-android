using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Android.MVC
{
    [Activity(Label = "Android.MVC", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText username, password;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set our view from the "main" layout resource
             SetContentView (Resource.Layout.homeView);

             this.username = FindViewById<EditText>(Resource.Id.user);
             this.password = FindViewById<EditText>(Resource.Id.password);

            Button button = FindViewById<Button>(Resource.Id.acceder);

            button.Click += delegate {
                new Handler(Looper.MainLooper).Post(
              () =>
              {
                  if(!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text))
                  {
                      //Navegamos
                       StartActivity(new Intent(this, typeof(LogadoActivity)));
                  }
                  else
                  {
                      //Si es un error, mostramos un dialogo
                         AlertDialog.Builder builder = new AlertDialog.Builder(this);
                         AlertDialog alertdialog = builder.Create();

                          alertdialog.SetMessage("Relllene los datos");
                          alertdialog.Show();
                  }
                 

                 
              });

            };
        }

    }
}

