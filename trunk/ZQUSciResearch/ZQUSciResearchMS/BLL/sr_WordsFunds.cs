using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
    /// <summary>
    /// ҵ���߼���sr_WordsFunds ��ժҪ˵����
    /// </summary>
    public class sr_WordsFunds
    {
        private readonly ZQUSR.DAL.sr_WordsFunds dal = new ZQUSR.DAL.sr_WordsFunds();
        public sr_WordsFunds()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int PK_WFID)
        {
            return dal.Exists(PK_WFID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZQUSR.Model.sr_WordsFunds model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZQUSR.Model.sr_WordsFunds model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int PK_WFID)
        {

            dal.Delete(PK_WFID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZQUSR.Model.sr_WordsFunds GetModel(int PK_WFID)
        {

            return dal.GetModel(PK_WFID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public ZQUSR.Model.sr_WordsFunds GetModelByCache(int PK_WFID)
        {

            string CacheKey = "sr_WordsFundsModel-" + PK_WFID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PK_WFID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZQUSR.Model.sr_WordsFunds)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZQUSR.Model.sr_WordsFunds> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZQUSR.Model.sr_WordsFunds> DataTableToList(DataTable dt)
        {
            List<ZQUSR.Model.sr_WordsFunds> modelList = new List<ZQUSR.Model.sr_WordsFunds>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZQUSR.Model.sr_WordsFunds model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZQUSR.Model.sr_WordsFunds();
                    if (dt.Rows[n]["PK_WFID"].ToString() != "")
                    {
                        model.PK_WFID = int.Parse(dt.Rows[n]["PK_WFID"].ToString());
                    }
                    model.Sort = dt.Rows[n]["Sort"].ToString();
                    model.Type = dt.Rows[n]["Type"].ToString();
                    if (dt.Rows[n]["Digit1"].ToString() != "")
                    {
                        model.Digit1 = decimal.Parse(dt.Rows[n]["Digit1"].ToString());
                    }
                    if (dt.Rows[n]["Digit2"].ToString() != "")
                    {
                        model.Digit2 = decimal.Parse(dt.Rows[n]["Digit2"].ToString());
                    }
                    if (dt.Rows[n]["Digit3"].ToString() != "")
                    {
                        model.Digit3 = decimal.Parse(dt.Rows[n]["Digit3"].ToString());
                    }
                    if (dt.Rows[n]["Digit4"].ToString() != "")
                    {
                        model.Digit4 = decimal.Parse(dt.Rows[n]["Digit4"].ToString());
                    }
                    if (dt.Rows[n]["Digit5"].ToString() != "")
                    {
                        model.Digit5 = decimal.Parse(dt.Rows[n]["Digit5"].ToString());
                    }
                    if (dt.Rows[n]["Digit6"].ToString() != "")
                    {
                        model.Digit6 = decimal.Parse(dt.Rows[n]["Digit6"].ToString());
                    }
                    if (dt.Rows[n]["Digit7"].ToString() != "")
                    {
                        model.Digit7 = decimal.Parse(dt.Rows[n]["Digit7"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        #region ѧ��������������������
        /// <summary>
        /// ѧ��������������������   ����By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public ZQUSR.Model.sr_WordsFunds GetModel(string Sort)
        {
            return dal.GetModel(Sort);
        }
        #endregion

        #region ������Ŀ�����㾭�ѷ���
        /// <summary>
        ///  ������Ŀ�����㾭�ѷ���  ����By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public ZQUSR.Model.sr_WordsFunds GetModel(string Sort, string Type)
        {
            return dal.GetModel(Sort, Type);
        }
        #endregion

        #region ����ѧ������������������
        /// <summary>
        /// ����ѧ������������������ ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateZhuZuo(ZQUSR.Model.sr_WordsFunds model)
        {
            dal.UpdateZhuZuo(model);
        }
        #endregion

        #region ���¿�����Ŀ�ľ��ѷ�����
        /// <summary>
        /// ���¿�����Ŀ�ľ��ѷ����� ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateKeYan(ZQUSR.Model.sr_WordsFunds model)
        {
            dal.UpdateKeYan(model);
        }
        #endregion
	}
}

