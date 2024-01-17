using RestSharp;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://test.sdi.openapi.it/business_registry_configurations");
            var request = new RestRequest("resurce", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + textBox1.Text);
            request.AddParameter("application/json", "{\"fiscal_id\":\"" + textBox2.Text + "\",\"name\":\"" + textBox3.Text + "\",\"email\":\"" + textBox4.Text + "\",\"apply_signature\":false,\"apply_legal_storage\":false}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            MessageBox.Show(response.StatusCode.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://test.sdi.openapi.it/api_configurations");
            var request = new RestRequest("resurce", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Bearer "+textBox1.Text);
            request.AddParameter("application/json", "{\"fiscal_id\":\"16860361001\",\"callbacks\":[{\"event\":\"supplier-invoice\",\"url\":\"https://example.com/callback\",\"auth_header\":\"Bearer " + textBox1.Text + "\",\"field\":\"data\"}]}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            MessageBox.Show(response.StatusCode.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://test.sdi.openapi.it/invoices?type=1");
            var request = new RestRequest("resurce",Method.Get);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Bearer "+textBox1.Text);
            RestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);
        }
    }
}
