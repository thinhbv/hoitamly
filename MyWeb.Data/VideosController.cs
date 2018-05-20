using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyWeb.Data
{
	public class VideosDAL : SqlDataProvider
	{
		static SqlCommand dbCmd;
		#region[Videos_GetByTop]
		public DataTable Videos_GetByTop(string Top, string Where, string Order)
		{
			dbCmd = new SqlCommand("sp_Videos_GetByTop");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
			dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
			dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
			return GetData(dbCmd);
		}
		#endregion
		#region[Videos_Insert]
		public bool Videos_Insert(Videos data)
		{
			dbCmd = new SqlCommand("sp_Videos_Insert");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			dbCmd.Parameters.Add(new SqlParameter("@Language", data.Language));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Videos");
			return true;
		}
		#endregion
		#region[Videos_Update]
		public bool Videos_Update(Videos data)
		{
			dbCmd = new SqlCommand("sp_Videos_Update");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
			dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
			dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
			dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
			dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
			dbCmd.Parameters.Add(new SqlParameter("@Language", data.Language));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Videos");
			return true;
		}
		#endregion
		#region[Videos_Delete]
		public bool Videos_Delete(string Id)
		{
			dbCmd = new SqlCommand("sp_Videos_Delete");
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
			ExecuteNonQuery(dbCmd);
			//Clear cache
			System.Web.HttpContext.Current.Cache.Remove("Videos");
			return true;
		}
		#endregion
	}
}
