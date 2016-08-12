using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppMaps.Model;
using Newtonsoft.Json;
using Windows.UI.Popups;
using System;



// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppMaps
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Serializable ser = new Serializable();
        public MainPage()
        {
            this.InitializeComponent();
        }

        /*
         * Méthode qui actionne le bouton de sauvegarde
         * Création d'un fichier de sauvegarde 
         */
        private void clickSaveUser(object sender, RoutedEventArgs e)
        {
            User user = new User(textboxNameRegister.Text, textboxFirstnameRegister.Text, textboxMailRegister.Text, passwordboxRegister.Password);
            ser.createFile("connect.txt");
            ser.writeFile("connect.txt",user);
            result.Text = "Check";
        }

        /*
         * Méthode qui actionne le bouton de connexion
         * Il y a une deserialisation du fichier de sauvegarde
         * on vérifie si les données correspondent pour permettre 
         * la connexion
         */ 
        private async void clickConnectUser(object sender, RoutedEventArgs e)
        {
            string json = await ser.readFile("connect.txt");
            User userDeserializable = JsonConvert.DeserializeObject<User>(json);
            if (textboxMailSignin.Text == userDeserializable.Mail && passwordboxSignin.Password == userDeserializable.Password)
            {
                MessageDialog msgbox = new MessageDialog("Bonjour " + userDeserializable.Name, "Alert !");
                await msgbox.ShowAsync();
                this.Frame.Navigate(typeof(HomePage));
            }
            else
            {
                MessageDialog msgbox = new MessageDialog(userDeserializable.Mail, "Alert !");
                await msgbox.ShowAsync();
            }
            
        }
    }
}
