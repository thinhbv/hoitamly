using System;
		private string _GroupNewsId;
		private string _GroupTagNews;
		private string _Active;
		private string _Language;
		public string GroupNewsId { get { return _GroupNewsId; } set { _GroupNewsId = value; } }
		public string GroupTagNews { get { return _GroupTagNews; } set { _GroupTagNews = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		public string Language { get { return _Language; } set { _Language = value; } }
			obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();
			obj.GroupNewsId = (dr["GroupNewsId"] is DBNull) ? string.Empty : dr["GroupNewsId"].ToString();
			obj.GroupTagNews = (dr["GroupTagNews"] is DBNull) ? string.Empty : dr["GroupTagNews"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Language = (dr["Language"] is DBNull) ? string.Empty : dr["Language"].ToString();