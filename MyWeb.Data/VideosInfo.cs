﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MyWeb.Data
{
	public class Videos
	{
		#region[Declare variables]
		private string _Id;
		private string _Name;
		private string _Link;
		private string _Ord;
		private string _Active;
		private string _Language;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string Link { get { return _Link; } set { _Link = value; } }
		public string Ord { get { return _Ord; } set { _Ord = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		public string Language { get { return _Language; } set { _Language = value; } }
		#endregion
		#region[Advertise IDataReader]
		public Videos AdvertiseIDataReader(IDataReader dr)
		{
			Data.Videos obj = new Data.Videos();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Language = (dr["Language"] is DBNull) ? string.Empty : dr["Language"].ToString();
			return obj;
		}
		#endregion
	}
}