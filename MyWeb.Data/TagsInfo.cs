using System;
		private string _Active;
		private string _Language;
		public string Active { get { return _Active; } set { _Active = value; } }
		public string Language { get { return _Language; } set { _Language = value; } }
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Language = (dr["Language"] is DBNull) ? string.Empty : dr["Language"].ToString();