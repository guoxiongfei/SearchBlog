namespace GuoXiongfei.MsSQLDAL
{
    using GuoXiongfei.Components;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;


    public class TopicCategoryDAL : ITopicCategory
    {

        /*******************  以下自动生成代码   *****************/

        #region 自动生成DAL层Insert、Update、Read、Delete接口


        public const string singleFields = "ID,FatherID,CateName,CateCName,TopicCount,Keywords,Description,OrderID";


        #region Insert:插入数据 +Insert(TopicCategoryInfo info)
        /// <summary>插入实体数据
        /// 插入实体数据
        /// </summary>
        /// <param name="info">表实体模型</param>
        public void Insert(TopicCategoryInfo info)
        {
            string sql = "INSERT INTO TopicCategory(FatherID,CateName,CateCName,TopicCount,Keywords,Description,OrderID) values(@FatherID,@CateName,@CateCName,@TopicCount,@Keywords,@Description,@OrderID)";
            SqlParameter[] paras = {
                                 new SqlParameter("@FatherID", SqlDbType.Int),
                                 new SqlParameter("@CateName", SqlDbType.NVarChar),
                                 new SqlParameter("@CateCName", SqlDbType.NVarChar),
                                 new SqlParameter("@TopicCount", SqlDbType.Int),
                                 new SqlParameter("@Keywords", SqlDbType.NVarChar),
                                 new SqlParameter("@Description", SqlDbType.NVarChar),
                                 new SqlParameter("@OrderID", SqlDbType.Int)
                                   };
            paras[0].Value = info.FatherID;
            paras[1].Value = info.CateName;
            paras[2].Value = info.CateCName;
            paras[3].Value = info.TopicCount;
            paras[4].Value = info.Keywords;
            paras[5].Value = info.Description;
            paras[6].Value = info.OrderID;
            MssqlHandler.ExecuteNonQuery(sql, paras);
        }
        #endregion


        #region Update:根据主键更新实体模型数据 +Update(TopicCategoryInfo info)
        /// <summary>更新实体数据
        /// 更新实体数据
        /// </summary>
        /// <param name="info">表实体模型</param>
        public void Update(TopicCategoryInfo info)
        {
            string sql = string.Format("UPDATE TopicCategory SET FatherID=@FatherID,CateName=@CateName,CateCName=@CateCName,TopicCount=@TopicCount,Keywords=@Keywords,Description=@Description,OrderID=@OrderID where ID={0}", info.ID);
            SqlParameter[] paras = {
                                 new SqlParameter("@FatherID", SqlDbType.Int),
                                 new SqlParameter("@CateName", SqlDbType.NVarChar),
                                 new SqlParameter("@CateCName", SqlDbType.NVarChar),
                                 new SqlParameter("@TopicCount", SqlDbType.Int),
                                 new SqlParameter("@Keywords", SqlDbType.NVarChar),
                                 new SqlParameter("@Description", SqlDbType.NVarChar),
                                 new SqlParameter("@OrderID", SqlDbType.Int)
                                   };
            paras[0].Value = info.FatherID;
            paras[1].Value = info.CateName;
            paras[2].Value = info.CateCName;
            paras[3].Value = info.TopicCount;
            paras[4].Value = info.Keywords;
            paras[5].Value = info.Description;
            paras[6].Value = info.OrderID;
            MssqlHandler.ExecuteNonQuery(sql, paras);
        }
        #endregion


        #region Read:根据主键ID读取记录 +Read(int id)
        /// <summary>根据主键ID读取记录
        /// 根据主键ID读取记录
        /// </summary>
        /// <param name="id">表主键</param>
        /// <returns>话题类别实体对象</returns>
        public TopicCategoryInfo Read(int id)
        {
            string sql = string.Format("SELECT ID,FatherID,CateName,CateCName,TopicCount,Keywords,Description,OrderID FROM TopicCategory WHERE ID ={0}", id);
            TopicCategoryInfo info = new TopicCategoryInfo();
            using (SqlDataReader dr = MssqlHandler.ExecuteReader(sql))
            {
                PrepareSingleModel(dr, info);
            }
            return info;
        }
        public void PrepareSingleModel(SqlDataReader dr, TopicCategoryInfo info)
        {
            while (dr.Read())
            {
                info.ID = dr.GetInt32(0);
                info.FatherID = dr.GetInt32(1);
                info.CateName = dr[2].ToString();
                info.CateCName = dr[3].ToString();
                info.TopicCount = dr.GetInt32(4);
                info.Keywords = dr[5].ToString();
                info.Description = dr[6].ToString();
                info.OrderID = dr.GetInt32(7);
            }
        }
        #endregion


        #region Delete:根据主键Delete实体指定字段数据 +Delete(string ids)
        /// <summary>删除多条指定ID的数据
        /// 删除多条指定ID的数据
        /// </summary>
        /// <param name="ids">用户表的主键值,以,号分隔</param>
        public void Delete(string ids)
        {
            string sql = "Update TopicCategory SET IsDelete=1,UpdateTime=getdate() WHERE [ID] IN(" + ids + ")";
            MssqlHandler.ExecuteNonQuery(sql);
        }
        #endregion

        #endregion

        /*******************  以上自动生成代码   *****************/


        public List<TopicCategoryInfo> ReadList(string where, string orderBy, int pageNum, int pageSize, ref int totalCount)
        {
            throw new NotImplementedException();
        }
    }
}
