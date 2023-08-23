using libNotionUMSCore.NotionDatabase;
using libNotionUMSCore.NotionPage;
using Notion.Client;
using System.Globalization;

namespace Notion_UMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // �б� ������ �����ϴ� ��ū�� �̸��� �ۼ��մϴ�.
            const string strAccessToken = "secret_9xdmwha3nDmrvt9Y510wqZMYZPNtObp4FSnxFvXvYkh";
            // �б� ������ �ο��� �����ͺ��̽��� ID ������ �ۼ��մϴ�.
            const string strDatabaseId = "1edebcf8be0349138afd5457d6729e47";

            Dao dao = new Dao(strAccessToken, strDatabaseId);
            dao.Connect();
            var items = await dao.Read();
            foreach (var item in items)
            {
                string value = (string)dao.GetValue(item.Properties["�±�"]);
                MessageBox.Show(value, item.Id);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string strTitle = tbDbWriteTitle.Text;

            // ���� ������ �����ϴ� ��ū�� �̸��� �ۼ��մϴ�.
            const string strAccessToken = "secret_47vpvOh5Je5UX9ateIiuUAQOGzZyJcFVzBz1vXAflLy";
            // ���� ������ �ο��� �����ͺ��̽��� ID ������ �ۼ��մϴ�.
            const string strDatabaseId = "eb31dbd4a4c4418185d015b7b84119ea";

            Dao dao = new Dao(strAccessToken, strDatabaseId);
            dao.Connect();

            var item = new Dictionary<string, PropertyValue>
            {
                { "�̸�", new TitlePropertyValue { Title = new List<RichTextBase> { new RichTextText { Text = new Text { Content = strTitle } } } } }
            };

            await dao.Create(item);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // https://www.notion.so/5e6ff2f01bce4ecbacf88d5e9aabe9b9?pvs=4
            PageReader reader = new PageReader("secret_9xdmwha3nDmrvt9Y510wqZMYZPNtObp4FSnxFvXvYkh", "5e6ff2f01bce4ecbacf88d5e9aabe9b9");
            reader.Connect();
            string strContent = await reader.ReadPageContent();
            MessageBox.Show(strContent);
        }
    }
}