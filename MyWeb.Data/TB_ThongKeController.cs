using System;
        static SqlCommand dbCmd;
        #region[spThongKe_Edit]
        public DataTable spThongKe_Edit()
        {
            dbCmd = new SqlCommand("spThongKe_Edit");
            dbCmd.CommandType = CommandType.StoredProcedure;
            return GetData(dbCmd);
        }
        #endregion