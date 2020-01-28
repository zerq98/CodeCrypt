using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CodeCrypt
{
    public partial class MainWindow : Window
    {
        string name = Environment.UserName;//Get name of current user

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            ExitBtn.Click += (s, e) => this.Close();
            MinimizeBtn.Click += (s, e) => this.WindowState = WindowState.Minimized;
            
        }
        #endregion

        #region Click Events

        //This click events select which one class is needed to use
        public void Encrypt_Click(object sender, EventArgs e)
        { 
            ResultTextBlock.Text = "";
            string Name = (sender as Button).Name;
            switch (Name)
            {
                case "EncryptText":
                    using (Caesar caesar = new Caesar(int.Parse(Level.Text)))
                    {
                        ResultTextBlock.Text = caesar.Encrypting(ShortText.Text);
                    }
                    break;
                case "EncryptFile":
                    FileStream file = new FileStream(FilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(file))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        file.Close();
                        FileStream filecopy = File.Create(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(FilePath.Text) + "(Crypted).txt");
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {
                            using (Caesar caesar = new Caesar(int.Parse(Level.Text)))
                            {
                                foreach (string s in filestring)
                                {
                                    ResultTextBlock.Text += caesar.Encrypting(s) + " ";
                                    writer.Write(caesar.Encrypting(s) + " ");
                                }
                            }
                        }

                    }
                    break;
                case "FenceEncryptFile":
                    FileStream fencefile = new FileStream(FenceFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(fencefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        fencefile.Close();

                        FileStream filecopy = File.Create(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(FenceFilePath.Text) + "(Crypted).txt");
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {
                            using (Fence fence = new Fence(int.Parse(Level.Text)))
                            {
                                foreach (string s in filestring)
                                {

                                    ResultTextBlock.Text += fence.Encrypting(s) + " ";
                                    writer.Write(fence.Encrypting(s) + " ");
                                }
                            }
                        }

                    }
                    break;
                case "FenceEncryptText":
                    using (Fence fence = new Fence(int.Parse(FenceLevel.Text)))
                    {
                        ResultTextBlock.Text = fence.Encrypting(FenceShortText.Text);
                    }
                    break;
                case "CircleEncryptText":
                    using (CircleCipher circle = new CircleCipher(CircleKey.Text, CircleShortText.Text))
                    {
                        ResultTextBlock.Text = circle.Encrypting();
                    }
                    break;
                case "CircleEncryptFile":
                    FileStream circlefile = new FileStream(CircleFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(circlefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        circlefile.Close();

                        FileStream filecopy = File.Create(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(CircleFilePath.Text) + "(Crypted).txt");
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {

                            foreach (string s in filestring)
                            {
                                using (CircleCipher circle = new CircleCipher(CircleKey.Text, s))
                                {
                                    ResultTextBlock.Text += circle.Encrypting() + " ";
                                    writer.Write(circle.Encrypting() + " ");
                                }
                            }
                        }
                    }
                    break;
                case "VinagreEncryptText":
                    using(Vigenere vin=new Vigenere(VinagreKey.Text,VinagreShortText.Text))
                    {
                        ResultTextBlock.Text = vin.Encrypting();
                    }
                    break;
                case "VinagreEncryptFile":
                    FileStream vinagrefile = new FileStream(VinagreFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(vinagrefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        vinagrefile.Close();

                        FileStream filecopy = File.Create(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(VinagreFilePath.Text) + "(Crypted).txt");
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {

                            foreach (string s in filestring)
                            {
                                using (Vigenere vinagre = new Vigenere(VinagreKey.Text, VinagreShortText.Text))
                                {
                                    ResultTextBlock.Text += vinagre.Encrypting() + " ";
                                    writer.Write(vinagre.Encrypting() + " ");
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Decrypt_Click(object sender, EventArgs e)
        {
            ResultTextBlock.Text = "";
            string Name = (sender as Button).Name;
            switch (Name)
            {
                case "DecryptText":
                    using(Caesar caesar = new Caesar(int.Parse(Level.Text))){
                        ResultTextBlock.Text = caesar.Decrypting(ShortText.Text);
                    }
                    break;
                case "DecryptFile":
                    FileStream file = new FileStream(FilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(file))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        file.Close();
                        FileStream filecopy = new FileStream(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(FilePath.Text) + "(Decrypted).txt"
                        , FileMode.OpenOrCreate);
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {
                            using (Caesar caesar = new Caesar(int.Parse(Level.Text)))
                            {
                                foreach (string s in filestring)
                                {

                                    ResultTextBlock.Text += caesar.Decrypting(s) + " ";
                                    writer.Write(caesar.Decrypting(s) + " ");
                                }
                            }
                        }

                    }
                    break;
                case "FenceDecryptFile":
                    FileStream fencefile = new FileStream(FenceFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(fencefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        fencefile.Close();
                        FileStream filecopy = new FileStream(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(CircleFilePath.Text) + "(Decrypted).txt"
                        , FileMode.OpenOrCreate);
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {
                            using (Fence fence = new Fence(int.Parse(Level.Text)))
                            {
                                foreach (string s in filestring)
                                {
                                    ResultTextBlock.Text += fence.Decrypting(s) + " ";
                                    writer.Write(fence.Decrypting(s) + " ");
                                }
                            }
                        }

                    }
                    break;
                case "FenceDecryptText":
                    using (Fence fence = new Fence(int.Parse(FenceLevel.Text)))
                    {
                        ResultTextBlock.Text = fence.Decrypting(FenceShortText.Text);
                    }
                    break;
                case "CircleDecryptText":
                    using (CircleCipher circle = new CircleCipher(CircleKey.Text, CircleShortText.Text))
                    {
                        ResultTextBlock.Text = circle.Decrypting();
                    }
                    break;
                case "CircleDecryptFile":
                    FileStream circlefile = new FileStream(CircleFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(circlefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        circlefile.Close();
                        FileStream filecopy = new FileStream(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(CircleFilePath.Text) + "(Decrypted).txt"
                        , FileMode.OpenOrCreate);
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {
                            foreach (string s in filestring)
                            {
                                using (CircleCipher circle = new CircleCipher(CircleKey.Text,s))
                                {
                                    ResultTextBlock.Text += circle.Decrypting() + " ";
                                    writer.Write(circle.Decrypting() + " ");
                                }
                            }
                        }

                    }
                    break;
                case "VinagreDecryptText":
                    using (Vigenere vin = new Vigenere(VinagreKey.Text, VinagreShortText.Text))
                    {
                        ResultTextBlock.Text = vin.Decrypting();
                    }
                    break;
                case "VinagreDecryptFile":
                    FileStream vinagrefile = new FileStream(VinagreFilePath.Text, FileMode.Open);

                    using (StreamReader reader = new StreamReader(vinagrefile))
                    {

                        string[] filestring = reader.ReadToEnd().Split(' ');
                        reader.Dispose();
                        vinagrefile.Close();

                        FileStream filecopy = File.Create(@"C:\Users\\" + name + "\\Desktop\\" + Path.GetFileNameWithoutExtension(VinagreFilePath.Text) + "(Crypted).txt");
                        using (StreamWriter writer = new StreamWriter(filecopy))
                        {

                            foreach (string s in filestring)
                            {
                                using (Vigenere vinagre = new Vigenere(VinagreKey.Text, VinagreShortText.Text))
                                {
                                    ResultTextBlock.Text += vinagre.Decrypting() + " ";
                                    writer.Write(vinagre.Decrypting() + " ");
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            dialog.ShowDialog();
            switch((sender as Button).Name)
            {
                case "FileButton":
                    FilePath.Text = dialog.FileName;
                    break;
                case "FenceFileButton":
                    FenceFilePath.Text = dialog.FileName;
                    break;
                case "CircleFileButton":
                    CircleFilePath.Text = dialog.FileName;
                    break;
            }
            
        }


        #endregion



    }
}
