using Notion.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Notion_UMS.NotionDB
{
    internal class Dao
    {
        private string m_strDatabaseAccessToken; // 데잍처베이스 접근(읽기/쓰기) 권한이 있는 토큰
        private string m_strDatabaseId;          // 연결될 DB ID
        private NotionClient m_connector;

        public Dao(string strDatabaseAccessToken, string strDatabaseId)
        {
            m_strDatabaseAccessToken = strDatabaseAccessToken;
            m_strDatabaseId = strDatabaseId;
        }

        public bool Connect()
        {
            bool bResult = false;
            try
            {
                m_connector = NotionClientFactory.Create(new ClientOptions
                {
                    AuthToken = m_strDatabaseAccessToken
                });

                if (null != m_connector)
                {
                    bResult = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return bResult;
        }

        public bool IsConnected()
        {
            bool bResult = false;
            if (null != m_connector)
                bResult = true;

            return bResult;
        }

        public async Task<Page> Create(Dictionary<string, PropertyValue> parameters)
        {
            var newPage = new PagesCreateParameters();
            newPage.Parent = new DatabaseParentInput
            {
                DatabaseId = m_strDatabaseId
            };
            newPage.Properties = parameters;
            Page createdPage = await m_connector.Pages.CreateAsync(newPage);

            return createdPage;
        }

        public async Task<List<Page>> Read()
        {
            var queryParams = new DatabasesQueryParameters();
            var pages = await m_connector.Databases.QueryAsync(m_strDatabaseId, queryParams);
            return pages.Results;
        }

        public object GetValue(PropertyValue p)
        {
            switch (p)
            {
                case RichTextPropertyValue richTextPropertyValue:
                    return richTextPropertyValue.RichText.FirstOrDefault()?.PlainText;
                default:
                    return null;
            }
        }


    }
}
