﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion_UMS.NotionDB
{
    
    internal class Writer
    {
        private Dao m_Dao;
        public Writer(string strDatabaseAccessToken, string strDatabaseId)
        {
            m_Dao = new Dao(strDatabaseAccessToken, strDatabaseId);
            m_Dao.Connect();
        }
    }
}
