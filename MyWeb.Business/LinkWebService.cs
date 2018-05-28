using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MyWeb.Data;

namespace MyWeb.Business
{
	public class LinkWebService
	{
		private static LinkWebDAL db = new LinkWebDAL();

		#region[LinkWeb_GetByTop]
		public static DataTable LinkWeb_GetByTop(string Top, string Where, string Order)
		{
			return db.LinkWeb_GetByTop(Top, Where, Order);
		}
		#endregion

		#region[LinkWeb_Insert]
		public static bool LinkWeb_Insert(LinkWeb data)
		{
			return db.LinkWeb_Insert(data);
		}
		#endregion

		#region[LinkWeb_Update]
		public static bool LinkWeb_Update(LinkWeb data)
		{
			return db.LinkWeb_Update(data);
		}
		#endregion

		#region[LinkWeb_Delete]
		public static bool LinkWeb_Delete(string Id)
		{
			return db.LinkWeb_Delete(Id);
		}
		#endregion
	}
}
