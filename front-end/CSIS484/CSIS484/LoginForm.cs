using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSIS484
{
    public partial class LoginForm : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public LoginForm()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string storeId = txtStoreId.Text;
            string password = txtPassword.Text;
            string encryptedPassword = SHA512(password);

            bool result = login(storeId, encryptedPassword);
            if (!result)
            {
                txtIncorrectLogin.Visible = true;
                return;
            }

            this.Hide();
            MainForm main = new MainForm(storeId, encryptedPassword);
            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString();
            }
        }

        public bool login(string storeId, string encryptedPassword)
        {
            string url = $"http://localhost:3030/v1/login?storeId={storeId}&key={encryptedPassword}";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return (int) JObject.Parse(reader.ReadToEnd())["status"] == 200;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}