using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libNotionUMSCore.NotionDatabase
{
    public class Reader
    {
        private Dao m_Dao;
        public Reader(string strDatabaseAccessToken, string strDatabaseId) 
        { 
            m_Dao = new Dao(strDatabaseAccessToken, strDatabaseId);
            m_Dao.Connect();
        }
    }
}
