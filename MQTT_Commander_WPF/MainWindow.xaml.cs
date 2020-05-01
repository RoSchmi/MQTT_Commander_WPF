// https://github.com/eclipse/paho.mqtt.m2mqtt

//https://gist.github.com/cwschroeder/7b5117dca561c01def041e7d4c6d2771

// https://m2mqtt.wordpress.com/m2mqtt-and-amazon-aws-iot/


// https://www.elektormagazine.de/news/mein-weg-ins-iot-4-mqtt

// Tutorials for MVVM:
// https://www.codeproject.com/Articles/165368/WPF-MVVM-Quick-Start-Tutorial
// https://www.codeproject.com/Tips/813345/Basic-MVVM-and-ICommand-Usage-Example

//How to create PFX file
// https://gist.github.com/adrenalinehit/b33994a4d430b26747ac#file-converting-to-pfx-using-openssl
// openssl pkcs12 -export -out YOURPFXFILE.pfx -inkey*****-private.pem.key -in *****-certificate.pem.crt


using System;

using System.Windows;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using FileStore;
using MQTT_Client.ViewModels;
using System.Windows.Controls;
using System.Security;



// including the M2Mqtt Library

//using uPLibrary.Networking.M2Mqtt;
//using uPLibrary.Networking.M2Mqtt.Messages;


namespace MQTT_Commander_WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        UI_ViewModel ViewModel = new UI_ViewModel();
        
        #region Region MainWindow
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = ViewModel;

            Closing += ViewModel.OnWindowClosing;
        }
        #endregion

        #region Region ValidateServerCertificate   (not used, only here to rememer how it works)
        public static bool ValidateServerCertificate(
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        #endregion


        #region Region SelectLocalCertificate   (not used, only here to rememer how it works)
        public static X509Certificate SelectLocalCertificate(
        object sender,
        string targetHost,
        X509CertificateCollection localCertificates,
        X509Certificate remoteCertificate,
        string[] acceptableIssuers)
        {
            Console.WriteLine("Client is selecting a local certificate.");
            if (acceptableIssuers != null &&
                acceptableIssuers.Length > 0 &&
                localCertificates != null &&
                localCertificates.Count > 0)
            {
                // Use the first certificate that is from an acceptable issuer.
                foreach (X509Certificate certificate in localCertificates)
                {
                    string issuer = certificate.Issuer;
                    if (Array.IndexOf(acceptableIssuers, issuer) != -1)
                        return certificate;
                }
            }
            if (localCertificates != null &&
                localCertificates.Count > 0)
                return localCertificates[0];

            return null;
        }
        #endregion


        private void userCertificateValidationCallback(object sender)
        {
            Console.WriteLine("Certificate validated");
        }
 
        void setcolor()
        {
            btnPublish.Background = System.Windows.Media.Brushes.Green; 
        }
        // this code runs when the main window closes (end of the app)
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
      
        private void P_w_d_Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = sender as PasswordBox;

            UI_ViewModel.the_p_w_d = box.SecurePassword;
            
        }    
    }
}






