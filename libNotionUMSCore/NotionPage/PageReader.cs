using Notion.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libNotionUMSCore.NotionPage
{
    public class PageReader
    {
        private string m_strPageId;
        private string m_strDatabaseAccessToken;
        private NotionClient m_connector;

        public PageReader(string strDatabaseAccessToken , string strPageId)
        {
            m_strPageId = strPageId;
            m_strDatabaseAccessToken = strDatabaseAccessToken;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return bResult;
        }

        private string GetPropertyValueAsString(IDictionary<string, PropertyValue> properties, string propertyName)
        {
            if (properties.ContainsKey(propertyName))
            {
                var propertyValue = properties[propertyName];
                if (propertyValue is TitlePropertyValue titleProperty)
                {
                    return titleProperty.Title[0].PlainText;
                }
                else if (propertyValue is RichTextPropertyValue richTextProperty)
                {
                    return richTextProperty.RichText[0].PlainText;
                }
                // 다른 속성 형식에 대한 처리 추가 가능
            }

            return "";
        }

        public async Task<string> ReadPageContent()
        {
            Page page = await GetPage();
            PaginatedList<IBlock> blocks = await GetBlockList(page);

            // 페이지의 제목 가져오기
            var pageTitle = GetPropertyValueAsString(page.Properties, "title");

            // 페이지의 내용 가져오기
            // `BlockList`에서 각 `Block` 객체의 `Type` 속성을 확인하여 해당 block의 내용을 가져옵니다.
            var content = "";
            foreach (var block in blocks.Results)
            {
                switch (block.Type)
                {
                    case BlockType.Paragraph:
                        var paragraphBlock = block as ParagraphBlock;
                        var text = paragraphBlock.Paragraph.RichText.First().PlainText;
                        content += text;
                        content += Environment.NewLine;
                        break;
                    // 다른 block 타입에 대한 처리 추가 가능
                    default:
                        break;
                }

            }

            return content;
        }

        private async Task<Page> GetPage()
        {
            var page = await m_connector.Pages.RetrieveAsync(m_strPageId);
            return page;
        }

        private async Task<PaginatedList<IBlock>> GetBlockList(Page page)
        {
            var blockList = await m_connector.Blocks.RetrieveChildrenAsync(page.Id);
            return blockList;
        }
    }
}
