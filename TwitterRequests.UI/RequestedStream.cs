using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitterRequests.Domain;
using Newtonsoft.Json;
using RestSharp;

namespace TwitterRequests.UI
{
    public partial class RequestedStream : Form
    {

        private readonly string _token;

        public RequestedStream(string token)
        {
            _token = token;
            InitializeComponent();
        }

        private async void btn_Request_Click(object sender, EventArgs e)
        {
            var streamRequests = new StreamRequests(_token);

            try
            {
                var task = Task.Run(async() =>
                {
                    var request = await streamRequests.Get();
                    return request;
                });

                var result = await task;


                if (result.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<Tweets>(result.Content);

                    if (content.Data != null)
                    {
                        foreach(var item in content.Data)
                        {
                            cbb_Repository.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("DEU RUIM == null");
                    }

                }
                else
                {
                    MessageBox.Show($"DEU RUIM NOT COMPLETED {task.Status}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"DEU RUIM NO TRY {ex}");
            }

        }

        private void cbb_Repository_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbb_Repository.SelectedItem as Datum;

            lbl_ID.Text = selectedItem.Id;
            lbl_Text.Text = selectedItem.Text;
             
        }
    }
}
