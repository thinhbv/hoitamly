using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Data
{
	public class LinkWeb
	{
		#region[Declare variables]
		private string _Id;
		private string _Name;
		private string _Link;
		private string _Ord;
		private string _Active;
		private string _Lang;
		#endregion
		#region[Public Properties]
		public string Id { get { return _Id; } set { _Id = value; } }
		public string Name { get { return _Name; } set { _Name = value; } }
		public string Link { get { return _Link; } set { _Link = value; } }
		public string Ord { get { return _Ord; } set { _Ord = value; } }
		public string Active { get { return _Active; } set { _Active = value; } }
		public string Lang { get { return _Lang; } set { _Lang = value; } }
		#endregion
		#region[LinkWeb IDataReader]
		public LinkWeb AdvertiseIDataReader(IDataReader dr)
		{
			Data.LinkWeb obj = new Data.LinkWeb();
			obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
			obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
			obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
			obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
			obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
			obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
			return obj;
		}
		#endregion
	}
}
