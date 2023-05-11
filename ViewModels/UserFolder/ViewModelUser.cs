using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Diagnostics;

namespace PuntoDeVenta.ViewModels.UserFolder
{
    class ViewModelUser:ViewModelBase

        
    {
        public string USERNAME { get => ViewModelBase.EmployeeActive.USUARIO; set => USERNAME = value; }
        public string NAME { get => ViewModelBase.EmployeeActive.NOMBRE; set => NAME = value; }
        public string NUM_IDENTIFICACION { get => ViewModelBase.EmployeeActive.NUM_IDENTIFICACION; set => NUM_IDENTIFICACION = value;}
        public string AUTORIDAD { get => ViewModelBase.EmployeeActive.AUTORIDAD; set => AUTORIDAD = value; }
        public string TELEFONO { get => ViewModelBase.EmployeeActive.TELEFONO; set => TELEFONO = value; }
        public string EMAIL { get => ViewModelBase.EmployeeActive.EMAIL; set => EMAIL = value; }
        public BitmapImage IMAGE { get => convertToBitMap(); set => IMAGE = value; }

        private static byte[] ByteProfilePhoto = ViewModelBase.EmployeeActive.IMAGE;
        System.IO.MemoryStream memory = new System.IO.MemoryStream(ByteProfilePhoto);



        public BitmapImage convertToBitMap()
        {
          
                var Photo = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                Photo.BeginInit();
                Photo.StreamSource=memory;
                Photo.EndInit();

                Debug.WriteLine(Photo.GetType());
                Console.WriteLine(Photo);

                return Photo;

            

            
        }

        

        
        
        

        //public byte[] PHOTO { get => ViewModelBase.EmployeeActive.IMAGE; set => PHOTO = value; }

    
    
        public ViewModelUser()
        {
            Console.ReadLine();

            convertToBitMap();

            

           

            
        }
    }


    
}
