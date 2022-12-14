using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSIS484
{
    // Login Form
    public partial class LoginForm : Form
    {
        // For debugging
        //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
        //private static extern bool AllocConsole();

        public LoginForm()
        {
            InitializeComponent();

            // For debugging
            //AllocConsole();
        }

        // On Login Button clicked
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the text field values
            string storeId = txtStoreId.Text;
            string password = txtPassword.Text;
            // Encrypt the password using SHA-512
            string encryptedPassword = SHA512(password);

            // Verify credentials
            bool result = login(storeId, encryptedPassword);
            if (!result)
            {
                // If incorrect login, show that is is and return
                txtIncorrectLogin.Visible = true;
                return;
            }
            else
            {
                // Hide the login form
                this.Hide();
                // Create the main form
                MainForm main = new MainForm(storeId, encryptedPassword);
                // When the new form opens, close the login form
                main.Closed += (s, args) => this.Close();
                // Show the main form
                main.Show();
            }
        }

        // Encrypts a string using SHA-512
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

        // Verifies login credentials
        public bool login(string storeId, string encryptedPassword)
        {
            // Create the URL to verify credentials
            string url = $"http://localhost:3030/v1/login?storeId={storeId}&key={encryptedPassword}";

            try
            {
                // Make the HTTP request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Return whether the status is 200
                    return (int) JObject.Parse(reader.ReadToEnd())["status"] == 200;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}