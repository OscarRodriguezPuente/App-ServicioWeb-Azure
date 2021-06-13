using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace Ejercicio3
{
    [Activity(Label = "Principal")]
    public class Principal : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaprincipal);
            var lblDestino = FindViewById<TextView>(Resource.Id.lblUsuario);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnguardar);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            var txtNombre = FindViewById<EditText>(Resource.Id.txtnombre);
            var txtDomicilio = FindViewById<EditText>(Resource.Id.txtdomicilio);
            var txtFolio = FindViewById<EditText>(Resource.Id.txtfolio);
            var txtEdad = FindViewById<EditText>(Resource.Id.txtedad);

            String Usuario;
            Usuario = Intent.GetStringExtra("Usuario");
            lblDestino.Text = Usuario;

            btnGuardar.Click += delegate
            {
                try
                {
                    var WS = new ServicioAzure.ServicioWeb();
                    if

                    (WS.Guardar(txtNombre.Text, txtDomicilio.Text, int.Parse(txtEdad.Text))) Toast.MakeText(this, "Archivo Guardado Correctamente", ToastLength.Long).Show();

                    else
                        Toast.MakeText(this, "No guardado", ToastLength.Long).Show();





                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
                /*
                btnGuardar.Click += delegate
                {
                    var DC = new Datos();
                    try
                    {
                        DC.Nombre = txtNombre.Text;
                        DC.Domicilio = txtDomicilio.Text;
                        DC.Folio = txtFolio.Text;
                        DC.Edad = int.Parse(txtEdad.Text);
                        var serializador = new XmlSerializer(typeof(Datos));
                        var Escritura = new StreamWriter(Path.Combine(System.Environment.GetFolderPath
                            (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                        serializador.Serialize(Escritura, DC);
                        Escritura.Close();

                        txtNombre.Text = "";
                        txtDomicilio.Text = "";
                        txtEdad.Text = "";
                        Toast.MakeText(this, "Archivo Guardado Correctamente", ToastLength.Long).Show();

                    }
                    catch(System.Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                };

                btnBuscar.Click += delegate
                {
                    var DC = new Datos();
                    try
                    {

                        var serializador = new XmlSerializer(typeof(Datos));
                        var Lectura = new StreamReader(Path.Combine(System.Environment.GetFolderPath
                            (System.Environment.SpecialFolder.Personal), txtFolio.Text + ".xml"));
                        var datos=(Datos)serializador.Deserialize(Lectura);
                        Lectura.Close();

                        txtNombre.Text = datos.Nombre;
                        txtDomicilio.Text = datos.Domicilio;
                        txtEdad.Text = datos.Edad.ToString();
                        Toast.MakeText(this, "Archivo Guardado Correctamente", ToastLength.Long).Show();

                    }
                    catch (System.Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                };
                */

            };

            btnBuscar.Click += delegate
            {
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new ServicioAzure.ServicioWeb();
                    Conjunto = WS.Busqueda(int.Parse(txtFolio.Text));
                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    txtNombre.Text = Renglon["Nombre"].ToString();
                    txtDomicilio.Text = Renglon["Domicilio"].ToString();
                    txtEdad.Text = Renglon["Edad"].ToString();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
        }

        public class Datos
        {
            public string Nombre;
            public string Domicilio;
            public string Folio;
            public int Edad;
        }
    }
}