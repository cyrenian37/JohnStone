
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace UISolution.Views
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        UISolution.DataSource.HanSungLinqDataContext lContext;
        public UserControl2()
        {
            InitializeComponent();

            lContext = new DataSource.HanSungLinqDataContext();
            RadGridView1.DataContext = lContext.Securities;


        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            byte[] m_barrImg;
            System.Drawing.Image limage = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string strFn = openFileDialog.FileName;
                //imgTEST.Source = new BitmapImage(new Uri(strFn));
                limage = System.Drawing.Image.FromFile(strFn);
                //FileInfo fiImage = new FileInfo(strFn);
                //FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                //m_barrImg = new byte[Convert.ToInt32(fiImage.Length)];
                //int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(fiImage.Length));
                //fs.Close();
            }



            DataSource.Security lSecurity = lContext.Securities.SingleOrDefault(p => p.Id == 1);



            MemoryStream ms = new MemoryStream();
            limage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
            lSecurity.Image = binary;
            lSecurity.Password = Encrypt("passme");

            lContext.SubmitChanges();



            //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            UISolution.DataSource.HanSungLinqDataContext lContext = new DataSource.HanSungLinqDataContext();

            DataSource.Security lSecurity = lContext.Securities.SingleOrDefault(p => p.Id == 1);

            byte[] arrayBinary = lSecurity.Image.ToArray();
            System.Drawing.Image rImage = null;

            MemoryStream ms = new MemoryStream(arrayBinary);

            rImage = System.Drawing.Image.FromStream(ms);

            string lpassword = Decrypt(lSecurity.Password);
            // imgTEST.Source = rImage;

        }

        public string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);
            return Encoding.Unicode.GetString(decrypted);
        }
        //protected void LoadImage()
        //{

        //    try
        //    {
        //        this.openFileDialog1.ShowDialog(this);
        //        string strFn = this.openFileDialog1.FileName;
        //        this.pictureBox1.Image = Image.FromFile(strFn);
        //        FileInfo fiImage = new FileInfo(strFn);
        //        this.m_lImageFileLength = fiImage.Length;
        //        FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
        //        int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
        //        fs.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

    }
}
