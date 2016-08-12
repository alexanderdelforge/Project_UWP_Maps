using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AppMaps.Model
{
    class Serializable
    {
        // Méthode qui crée un fichier dans le dossier documents du téléphone
        // le nom du fichier est transmis en argument
        public async void createFile(string filename)
        {
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile file = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
        }
        
        // Méthode qui écrit dans le fichier
        // le nom du fichier est transmis en argument ainsi que les infos de l'utilisateur
        public async void writeFile(string filename, User user)
        {
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string convertData = JsonConvert.SerializeObject(user);
            await FileIO.WriteTextAsync(sampleFile, convertData);
        }

        // Méthode qui permet de lire dans un fichier
        // le nom du fichier est transmis en argument
        // la méthode retourne le contenu du fichier par une chaine de caractère 
        public async Task<string> readFile(string filename)
        {
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string jsonData = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);

            return jsonData;
        }
    }
}
