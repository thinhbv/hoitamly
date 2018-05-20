using System;
		private string _Date;
		private string _Language;
		public string Date { get { return _Date; } set { _Date = value; } }
		public string Language { get { return _Language; } set { _Language = value; } }
        #region[Contact IDataReader]
        public Contact ContactIDataReader(IDataReader dr)
        {
            Data.Contact obj = new Data.Contact();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Company = (dr["Company"] is DBNull) ? string.Empty : dr["Company"].ToString();
            obj.Email = (dr["Email"] is DBNull) ? string.Empty : dr["Email"].ToString();
            obj.Phone = (dr["Phone"] is DBNull) ? string.Empty : dr["Phone"].ToString();
            obj.Website = (dr["Website"] is DBNull) ? string.Empty : dr["Website"].ToString();
            obj.Title = (dr["Title"] is DBNull) ? string.Empty : dr["Title"].ToString();
            obj.Detail = (dr["Detail"] is DBNull) ? string.Empty : dr["Detail"].ToString();
			obj.Date = (dr["Date"] is DBNull) ? string.Empty : dr["Date"].ToString();
			obj.Language = (dr["Language"] is DBNull) ? string.Empty : dr["Language"].ToString();
            return obj;
        }
        #endregion