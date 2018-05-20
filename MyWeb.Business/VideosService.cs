using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class VideosService
	{
		private static VideosDAL db = new VideosDAL();

		#region[Videos_GetByTop]
		public static DataTable Videos_GetByTop(string Top, string Where, string Order)
		{
			return db.Videos_GetByTop(Top, Where, Order);
		}
		#endregion

		#region[Videos_Insert]
		public static bool Videos_Insert(Videos data)
		{
			return db.Videos_Insert(data);
		}
		#endregion

		#region[Videos_Update]
		public static bool Videos_Update(Videos data)
		{
			return db.Videos_Update(data);
		}
		#endregion

		#region[Videos_Delete]
		public static bool Videos_Delete(string Id)
		{
			return db.Videos_Delete(Id);
		}
		#endregion
	}
}
