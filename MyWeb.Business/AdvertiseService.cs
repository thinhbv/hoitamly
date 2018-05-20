using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class AdvertiseService
	{
		private static AdvertiseDAL db = new AdvertiseDAL();
		#region[Advertise_GetById]
		public static DataTable Advertise_GetById(string Id)
		{
			return db.Advertise_GetById(Id);
		}
		#endregion
		#region[Advertise_GetByTop]
		public static DataTable Advertise_GetByTop(string Top, string Where, string Order)
		{
			return db.Advertise_GetByTop(Top, Where, Order);
		}
		#endregion
		#region[Advertise_GetByAll]
		public static DataTable Advertise_GetByAll()
		{
			return db.Advertise_GetByAll();
		}
		#endregion
		#region[Advertise_Insert]
		public static bool Advertise_Insert(Advertise data)
		{
			return db.Advertise_Insert(data);
		}
		#endregion
		#region[Advertise_Update]
		public static bool Advertise_Update(Advertise data)
		{
			return db.Advertise_Update(data);
		}
		#endregion
		#region[Advertise_Delete]
		public static bool Advertise_Delete(string Id)
		{
			return db.Advertise_Delete(Id);
		}
		#endregion
        #region[Advertise_GetByPosition]
		public static DataTable Advertise_GetByPosition(string position)
        {
			DataTable dt = new DataTable();
            dt = db.Advertise_GetByAll();
			if (dt.Select("position=" + position + " And Active=1") != null && dt.Select("position=" + position + " And Active=1").Length > 0)
			{
				return dt.Select("Position=" + position + " And Active=1").CopyToDataTable();
			}
			return dt;
        }
		public static DataTable Advertise_GetByPositionPage(string position, string page)
        {
			DataTable dt = new DataTable();
            dt = db.Advertise_GetByAll();
			DataRow[] dr = dt.Select("Position=" + position + " And PageId=" + page + " And Active=1");
			if (dr != null && dr.Length > 0)
			{
				dt = dr.CopyToDataTable();
			}
			return dt;
        }
        #endregion
	}
}