using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using GuoXiongfei.Components;

namespace GuoXiongfei.MsSQLDAL
{
    public class TableDAL : ITableBase
    {


        /*******************  以下自动生成代码   *****************/

        #region 自动生成DAL层Insert、Update、Read、Delete接口


        public const string singleFields = "ID,TableName,TableDescription,Fields,UserID,UserName,Status,AddTime,UpdateTime,MySysTableID";


        #region Insert:插入数据 +Insert(TableBaseInfo info)
        /// <summary>插入实体数据
        /// 插入实体数据
        /// </summary>
        /// <param name="info">表实体模型</param>
        public void Insert(TableBaseInfo info)
        {
            string sql = "INSERT INTO TableBase(TableName,TableDescription,Fields,UserID,UserName,Status,AddTime,UpdateTime,MySysTableID) values(@TableName,@TableDescription,@Fields,@UserID,@UserName,@Status,@AddTime,@UpdateTime,@MySysTableID)";
            SqlParameter[] paras = {
                                 new SqlParameter("@TableName", SqlDbType.NVarChar),
                                 new SqlParameter("@TableDescription", SqlDbType.NVarChar),
                                 new SqlParameter("@Fields", SqlDbType.NText),
                                 new SqlParameter("@UserID", SqlDbType.Int),
                                 new SqlParameter("@UserName", SqlDbType.NVarChar),
                                 new SqlParameter("@Status", SqlDbType.Int),
                                 new SqlParameter("@AddTime", SqlDbType.DateTime),
                                 new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                                 new SqlParameter("@MySysTableID", SqlDbType.Int)
                                   };
            paras[0].Value = info.TableName;
            paras[1].Value = info.TableDescription;
            paras[2].Value = info.Fields;
            paras[3].Value = info.UserID;
            paras[4].Value = info.UserName;
            paras[5].Value = info.Status;
            paras[6].Value = info.AddTime;
            paras[7].Value = info.UpdateTime;
            paras[8].Value = info.MySysTableID;
            MssqlHandler.ExecuteNonQuery(sql, paras);
        }
        #endregion


        #region Update:根据主键更新实体模型数据 +Update(TableBaseInfo info)
        /// <summary>更新实体数据
        /// 更新实体数据
        /// </summary>
        /// <param name="info">表实体模型</param>
        public void Update(TableBaseInfo info)
        {
            string sql = string.Format("UPDATE TableBase SET TableName=@TableName,TableDescription=@TableDescription,Fields=@Fields,UserID=@UserID,UserName=@UserName,Status=@Status,AddTime=@AddTime,UpdateTime=@UpdateTime,MySysTableID=@MySysTableID where ID={0}", info.ID);
            SqlParameter[] paras = {
                                 new SqlParameter("@TableName", SqlDbType.NVarChar),
                                 new SqlParameter("@TableDescription", SqlDbType.NVarChar),
                                 new SqlParameter("@Fields", SqlDbType.NText),
                                 new SqlParameter("@UserID", SqlDbType.Int),
                                 new SqlParameter("@UserName", SqlDbType.NVarChar),
                                 new SqlParameter("@Status", SqlDbType.Int),
                                 new SqlParameter("@AddTime", SqlDbType.DateTime),
                                 new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                                 new SqlParameter("@MySysTableID", SqlDbType.Int)
                                   };
            paras[0].Value = info.TableName;
            paras[1].Value = info.TableDescription;
            paras[2].Value = info.Fields;
            paras[3].Value = info.UserID;
            paras[4].Value = info.UserName;
            paras[5].Value = info.Status;
            paras[6].Value = info.AddTime;
            paras[7].Value = info.UpdateTime;
            paras[8].Value = info.MySysTableID;
            MssqlHandler.ExecuteNonQuery(sql, paras);
        }
        #endregion


        #region Read:根据主键ID读取记录 +Read(int id)
        /// <summary>根据主键ID读取记录
        /// 根据主键ID读取记录
        /// </summary>
        /// <param name="id">表主键</param>
        /// <returns>自助建表基本信息实体对象</returns>
        public TableBaseInfo Read(int id)
        {
            string sql = string.Format("SELECT ID,TableName,TableDescription,Fields,UserID,UserName,Status,AddTime,UpdateTime,MySysTableID FROM TableBase WHERE ID ={0}", id);
            TableBaseInfo info = new TableBaseInfo();
            using (SqlDataReader dr = MssqlHandler.ExecuteReader(sql))
            {
                PrepareSingleModel(dr, info);
            }
            return info;
        }
        public void PrepareSingleModel(SqlDataReader dr, TableBaseInfo info)
        {
            while (dr.Read())
            {
                info.ID = dr.GetInt32(0);
                info.TableName = dr[1].ToString();
                info.TableDescription = dr[2].ToString();
                info.Fields = dr[3].ToString();
                info.UserID = dr.GetInt32(4);
                info.UserName = dr[5].ToString();
                info.Status = dr.GetInt32(6);
                info.AddTime = dr.GetDateTime(7);
                info.UpdateTime = dr.GetDateTime(8);
                info.MySysTableID = dr.GetInt32(9);
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
            string sql = "Update TableBase SET IsDelete=1,UpdateTime=getdate() WHERE [ID] IN(" + ids + ")";
            MssqlHandler.ExecuteNonQuery(sql);
        }
        #endregion

        #endregion

        /*******************  以上自动生成代码   *****************/



        public TableBaseInfo Read(int userid, string tableName)
        {
            string sql = string.Format("SELECT ID,TableName,TableDescription,Fields,UserID,UserName,Status,AddTime,UpdateTime,MySysTableID FROM TableBase WHERE UserID={0} and TableName='{1}'", userid, tableName.Replace(" ", ""));
            TableBaseInfo info = new TableBaseInfo();
            using (SqlDataReader dr = MssqlHandler.ExecuteReader(sql))
            {
                PrepareSingleModel(dr, info);
            }
            return info;

        }



        #region ReadList:根据搜索条件、排序、页码、每页数和返回总记录参数 读取模型列表

        /// <summary>
        /// 根据搜索条件、排序、页码、每页数和返回总记录参数 读取模型列表
        /// </summary>
        /// <param name="where">带where的查询条件</param>
        /// <param name="orderBy">排序字段+排序方式</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="pageSize">每页页数</param>
        /// <param name="totalCount">返回的总记录数</param>
        /// <returns></returns>
        public List<TableBaseInfo> ReadList(string where, string orderBy, int pageNum, int pageSize, ref int totalCount)
        {
            string sql = string.Format("SELECT ID,TableName,TableDescription,Fields,UserID,UserName,Status,AddTime,UpdateTime,MySysTableID FROM TableBase {0} {1}", where, orderBy, (pageNum - 1) * pageSize, pageSize);
            List<TableBaseInfo> infolist = new List<TableBaseInfo>();
            using (SqlDataReader dr = MssqlHandler.ExecuteReader(sql))
            {
                PrepareListModel(dr, infolist);
            }
            if (totalCount > -1)
            {
                sql = string.Format("SELECT count(0) FROM TableBase {0}", where);
                totalCount = Convert.ToInt32(MssqlHandler.ExecuteScalar(sql));
            }
            return infolist;
        }
        public void PrepareListModel(SqlDataReader dr, List<TableBaseInfo> infoList)
        {
            while (dr.Read())
            {
                TableBaseInfo info = new TableBaseInfo();
                info.ID = dr.GetInt32(0);
                info.TableName = dr[1].ToString();
                info.TableDescription = dr[2].ToString();
                info.Fields = dr[3].ToString();
                info.UserID = dr.GetInt32(4);
                info.UserName = dr[5].ToString();
                info.Status = dr.GetInt32(6);
                info.AddTime = dr.GetDateTime(7);
                info.UpdateTime = (dr[8] == DBNull.Value ? info.AddTime : dr.GetDateTime(8));
                info.MySysTableID = dr.GetInt32(9);
                infoList.Add(info);
            }
        }
        #endregion


    }
}