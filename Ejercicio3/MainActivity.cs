using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;


namespace Ejercicio3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string Usuario, Password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btnIngresa = FindViewById<Button>(Resource.Id.btnIngresar);
            var txtUser = FindViewById<EditText>(Resource.Id.txtusuario);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtpassword);
            var Imagen = FindViewById<ImageView>(Resource.Id.imagen);
            Imagen.SetImageResource(Resource.Drawable.logo1);
            
            btnIngresa.Click += delegate
            {
                try
                {
                    Usuario = txtUser.Text;
                    Password = txtPassword.Text;
                    if (Usuario == "Oscar")
                    {
                        if (Password == "123")
                        {
                            Cargar();

                        }
                        else
                            Toast.MakeText(this, "Error de Password", ToastLength.Long).Show();
                    }
                        
                    else
                    {
                        Toast.MakeText(this, "Error de Usuario", ToastLength.Long).Show();
                    }
                        


                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
                
            };
        }
        public void Cargar()
        {
            var VistaPrincipal = new Intent(this, typeof(Principal));
            VistaPrincipal.PutExtra("Usuario", Usuario);
            StartActivity(VistaPrincipal);

        }
        
    }
}