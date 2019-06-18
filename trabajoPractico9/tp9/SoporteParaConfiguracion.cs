using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helpers
{
    class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion()
        {
            string archivo = "directorio.dat";
            string rutaDest = @"C:\tp9_prueba";

            ////FileStream archivoDat = new FileStream(rutaDest + archivo, FileMode.Create);
            ////archivoDat.Close();

            ////using (BinaryWriter file = new BinaryWriter(File.Open(rutaDest+archivo, FileMode.Open)))
            ////{
            ////    file.Write(archivo);
                
            ////    file.Close(); // es importante?
            ////}
            using(BinaryWriter fila = new BinaryWriter(File.Open(Path.Combine(rutaDest, archivo), FileMode.Create)))
            {
                fila.Write(rutaDest);
                fila.Close();
            }
            //try
            //{
            //    // direccion no encontrada
            //}
            //catch (Exception ex)
            //{

            //    // string error = ex.ToString();
            //}

        }
        public static string LeerConfiguracion(string rutaDest)
        {
            string archivo = "directorio.dat";
            //string rutaDest = @"C:\tp9_prueba";
            string contenido;
            using (BinaryReader file = new BinaryReader(File.Open(Path.Combine(rutaDest, archivo), FileMode.Open)))
            {
                contenido = file.ReadString();
            }

            return(contenido);

        }
    }
    class ConversorDeMorse
    {
        public static string MorseATexto(string ruta)
        {
            string textoEnMorse;
            string nombreArch = "morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt";
            string rutaCompleta = Path.Combine(ruta, nombreArch); 
            FileStream archivo = new FileStream(rutaCompleta,FileMode.Open);
            archivo.Close();
            
            using(StreamReader lector =new StreamReader(rutaCompleta))
            {                
                textoEnMorse=lector.ReadToEnd();
                lector.Close();
            }
            string[] textoEnMorseSeparado = textoEnMorse.Split('/');
            string textoEnCastellano = "";
            char letra = ' '; // aqui guardare mi letra y luego ire agregandola 

            // crear un archivo txt
            //FileStream archivoTxt = new FileStream("queso.txt",FileMode.Create);

            //



            for (int i = 0; i < textoEnMorseSeparado.Count(); i++)
            {
                switch (textoEnMorseSeparado[i])
                {
                    case ".-":
                        letra = 'a';
                        break;
                    case "-...":
                        letra = 'b';
                        break;

                    case "-.-.":
                        letra = 'c';
                        break;

                    case "-..":
                        letra = 'd';
                        break;

                    case ".":
                        letra = 'e';
                        break;

                    case "..-.":
                        letra = 'f';
                        break;

                    case "--.":
                        letra = 'g';
                        break;

                    case "....":
                        letra = 'h';
                        break;

                    case "..":
                        letra = 'i';
                        break;

                    case ".---":
                        letra = 'j';
                        break;

                    case "-.-":
                        letra = 'k';
                        break;

                    case ".-..":
                        letra = 'l';
                        break;

                    case "--":
                        letra = 'm';
                        break;

                    case "-.":
                        letra = 'n';
                        break;

                    case "---":
                        letra = 'o';
                        break;

                    case ".--.":
                        letra = 'p';
                        break;

                    case "--.-":
                        letra = 'q';
                        break;

                    case ".-.":
                        letra = 'r';
                        break;

                    case "...":
                        letra = 's';
                        break;

                    case "-":
                        letra = 't';
                        break;

                    case "..-":
                        letra = 'u';
                        break;

                    case "...-":
                        letra = 'v';
                        break;

                    case ".--":
                        letra = 'w';
                        break;

                    case "-..-":
                        letra = 'x';
                        break;

                    case "-.--":
                        letra = 'y';
                        break;

                    case "--..":
                        letra = 'z';
                        break;
                }
                if (textoEnMorseSeparado[i] == "e")
                {
                    letra = ' ';
                }

                textoEnCastellano = textoEnCastellano + letra;
                letra = ' ';
            }

            FileStream nuevoArchivo = new FileStream(Path.Combine(ruta,"enCastellano.txt"),FileMode.Create);
            nuevoArchivo.Close();
            using(StreamWriter escritor = new StreamWriter(Path.Combine(ruta, "enCastellano.txt")))
            {
                escritor.Write(textoEnCastellano);
                escritor.Close();
            }
            Console.WriteLine("Archivo: enCastellano.txt creada en :"+ Path.Combine(ruta, "enCastellano.txt"));
            return (textoEnCastellano);
        }
        public static string TextoAMorse(string textoEnCastellano)
        {
            //creo el directorio morse dentro de la carpeta creada anteriormente
            string directorios = @"C:\tp9_prueba\morse";
            Directory.CreateDirectory(directorios);


            string textoEnMorse = "";
            string letraEnMorce;
            for (int i = 0; i < textoEnCastellano.Count(); i++)
            {
                switch (textoEnCastellano[i])  // la barra / es el separador
                {
                    case 'a':
                        letraEnMorce = ".-/";
                        break;
                    case 'b':
                        letraEnMorce = "-.../";
                        break;
                    case 'c':
                        letraEnMorce = "-.-./";
                        break;
                    case 'd':
                        letraEnMorce = "-../";
                        break;
                    case 'e':
                        letraEnMorce = "./";
                        break;
                    case 'f':
                        letraEnMorce = "..-./";
                        break;
                    case 'g':
                        letraEnMorce = "--./";
                        break;
                    case 'h':
                        letraEnMorce = "..../";
                        break;
                    case 'i':
                        letraEnMorce = "../";
                        break;
                    case 'j':
                        letraEnMorce = ".---/";
                        break;
                    case 'k':
                        letraEnMorce = "-.-/";
                        break;
                    case 'l':
                        letraEnMorce = ".-../";
                        break;
                    case 'm':
                        letraEnMorce = "--/";
                        break;
                    case 'n':
                        letraEnMorce = "-./";
                        break;
                    case 'o':
                        letraEnMorce = "---/";
                        break;
                    case 'p':
                        letraEnMorce = ".--./";
                        break;
                    case 'q':
                        letraEnMorce = "--.-/";
                        break;
                    case 'r':
                        letraEnMorce = ".-./";
                        break;
                    case 's':
                        letraEnMorce = ".../";
                        break;
                    case 't':
                        letraEnMorce = "-/";
                        break;
                    case 'u':
                        letraEnMorce = "..-/";
                        break;
                    case 'v':
                        letraEnMorce = "...-/";
                        break;
                    case 'w':
                        letraEnMorce = ".--/";
                        break;
                    case 'x':
                        letraEnMorce = "-..-/";
                        break;
                    case 'y':
                        letraEnMorce = "-.--/";
                        break;
                    case 'z':
                        letraEnMorce = "--../";
                        break;
                    case ' ':
                        letraEnMorce = "e/"; // e de espacio 
                        break;
                    default: // preguntar si es correcto
                        letraEnMorce = "";
                        break;
                }
                textoEnMorse = textoEnMorse + letraEnMorce;
            }


            //creo el archivo para guardar mi clave
            //nombre de mi archivo

            string nombreArch = "morse_" + DateTime.Today.ToString("dddd, dd MMMM yyyy") + ".txt";
            string rutaCompleta = Path.Combine(directorios, nombreArch);
            FileStream clave = new FileStream(rutaCompleta, FileMode.Create);
            clave.Close();
            using (StreamWriter escritor = new StreamWriter(rutaCompleta))
            {
                escritor.Write(textoEnMorse);
                escritor.Close();
            }
            Console.WriteLine("archivo con la clave creado en: "+rutaCompleta);
            return (textoEnMorse);
        }
    }
}
