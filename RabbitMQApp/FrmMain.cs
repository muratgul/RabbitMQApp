using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQApp.Models;
using System;
using System.Text;
using System.Windows.Forms;

namespace RabbitMQApp
{
    public partial class FrmMain : Form
    {
        IConnection connection;
        private readonly string createDocument = "create_document_queue";
        private readonly string documentCreated = "document_created_queue";
        private readonly string documentCreateExchange = "document_created_exchange";

        IModel _channel;
        IModel channel => _channel ?? (_channel = GetChannel());

        

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(connection == null || !connection.IsOpen)
                connection = GetConnection();

            btnCreateDocument.Enabled = true;

            channel.ExchangeDeclare(documentCreateExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreateExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreateExchange, documentCreated);

            AddLog("Connection is open now");
        }

        private void btnCreateDocument_Click(object sender, EventArgs e)
        {
            var model = new CreateDocumentModel()
            {
                UserId = 1,
                DocumentType = DocumentType.Pdf
            };

            WriteQueue(createDocument, model);

            var consumerEvent = new EventingBasicConsumer(channel);
            
            consumerEvent.Received += (ch, ea) =>
            {
                var modelReceived = JsonConvert.DeserializeObject<CreateDocumentModel>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                AddLog($"Received Data Url: {modelReceived.Url}");
            };

            channel.BasicConsume(documentCreated, true, consumerEvent);
        }
        private void WriteQueue(string queueName, CreateDocumentModel model)
        {
            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            channel.BasicPublish(documentCreateExchange, queueName, null, messageArray);

            AddLog("Message published");
        }
        private IModel GetChannel()
        {
            return connection.CreateModel();
        }
        private IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text)
            };

            return connectionFactory.CreateConnection();
        }
        private void AddLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AddLog(message)));
                return;
            }

            txtLog.AppendText(message);
            txtLog.AppendText("\n");
        }
    }
}
