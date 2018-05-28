using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MyWeb.Data
{
	public class LinkWebDAL : SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[LinkWeb_GetByTop]
		public DataTable LinkWeb_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_LinkWeb_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[LinkWeb_Insert]
		public bool LinkWeb_Insert(LinkWeb data)
		{
			dbCmd = new SqlCommand("sp_LinkWeb_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("LinkWeb");
			return true;
		}
		#endregion
		#region[LinkWeb_Update]
		public bool LinkWeb_Update(LinkWeb data)
		{
			dbCmd = new SqlCommand("sp_LinkWeb_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("LinkWeb");
			return true;
		}
		#endregion
		#region[LinkWeb_Delete]
		public bool LinkWeb_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_LinkWeb_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("LinkWeb");
			return true;
		}
		#endregion
	}
}
