using System;
		private string _Keyword;
		private string _Language;
		public string Keyword { get { return _Keyword; } set { _Keyword = value; } }
		public string Language { get { return _Language; } set { _Language = value; } }
			obj.Keyword = (dr["Keyword"] is DBNull) ? string.Empty : dr["Keyword"].ToString();
			obj.Language = (dr["Language"] is DBNull) ? string.Empty : dr["Language"].ToString();