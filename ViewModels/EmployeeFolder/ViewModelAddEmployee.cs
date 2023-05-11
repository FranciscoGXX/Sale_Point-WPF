using DataBase_Product.ClientDb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PuntoDeVenta.ViewModels.EmployeeFolder
{
    public class ViewModelAddEmployee:ViewModelBase
    {

        Employee EmployeeClient;

        /*--------------------------------------------------------------PROPERTIES------------------------------------------------------------*/

        /*--------------------------------------------------------------COMMNANDS------------------------------------------------------------*/

        public ViewModelComand CREATECOMMAND { get; set; }

        /*--------------------------------------------------------------METHODS--------------------------------------------------------------*/

        private void HanlderCreateCommand(object parameter)
        {
            var Values = (object[])parameter;

            string Name = Values[0].ToString();
            string User = Values[1].ToString();
            string PassWord = Values[2].ToString();
            string IdentifyNumber = Values[3].ToString();
            string Phone = Values[4].ToString();
            string Email = Values[5].ToString();
            System.Windows.Controls.ComboBoxItem Authority = (System.Windows.Controls.ComboBoxItem)Values[6];
            System.Windows.Controls.Image Photo= (System.Windows.Controls.Image)Values[7];

            string AuthorityString = Authority.Content.ToString();


            ///Convert Controls Image to Array of bytes

            if (Photo.Source == null)
            {
               MessageBox.Show("El campo de imagen es obligatorio, por favor selecionar una imagen para el nuevo usuario");
            }

           // byte[] ImageBytes =[0];

            byte[] ConvertImage(System.Windows.Controls.Image image)
            {
                
                
                byte[] ImageBytes = new byte[0];


                try
                {
                    if (image.Source == null)
                    {
                        MessageBox.Show("El campo de imagen es oblitorio para la creacion del nuevo usuario");
                        return ImageBytes;
                    }

                    var BitMapImage = image.Source as BitmapImage;

                    int height = BitMapImage.PixelHeight;
                    int width = BitMapImage.PixelWidth;
                    int stride = width * ((BitMapImage.Format.BitsPerPixel + 7) / 8);

                    ImageBytes = new byte[height * stride];
                    BitMapImage.CopyPixels(ImageBytes, stride, 0);

                    return ImageBytes;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Ha ocurrido un error mientras se convertia la imagen a Bytes, revise que el formato de la imagen que seleciono sea el correcto" +
                        "tambien recuerde que el campo de image en obligatorio");
                    return ImageBytes= new byte[0];
                }
            }


            //Sending Request
            EmployeeClient.CreateEmployee(Name,User,PassWord,IdentifyNumber, AuthorityString,Phone,Email,ConvertImage(Photo));

           

        }

        /*--------------------------------------------------------------BUILDER---------------------------------------------------------------*/

        public ViewModelAddEmployee()
        {
            EmployeeClient = new Employee();

            CREATECOMMAND = new ViewModelComand(HanlderCreateCommand);
        }


    }
}
