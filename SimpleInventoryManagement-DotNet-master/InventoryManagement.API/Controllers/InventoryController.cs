using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace InventoryManagement.API.Controllers
{
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("Inventory/GetInventoryInAll")]
        public HttpResponseMessage GetInventoryInAll()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = @"Select 
                               II.*
                               ,C.CategoryName
                               ,U.UnitName
                               from InventoryIn II
                               Left Join Category C On C.Id = II.CategoryId
                               Left Join UnitOfMeasurement U On U.Id = II.UnitId";

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<InventoryIn> obj = new List<InventoryIn>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        InventoryIn u = new InventoryIn()
                        {
                            Id = (int)dt.Rows[i][nameof(Models.InventoryIn.Id)],
                            Qty = (int)dt.Rows[i][nameof(Models.InventoryIn.Qty)],
                            ItemName = (string)dt.Rows[i][nameof(Models.InventoryIn.ItemName)],
                            ItemInDate = (DateTime)dt.Rows[i][nameof(Models.InventoryIn.ItemInDate)],
                            CategoryId = (int)dt.Rows[i][nameof(Models.InventoryIn.CategoryId)],
                            CategoryName = (string)dt.Rows[i][nameof(Models.InventoryIn.CategoryName)],
                            UnitId = (int)dt.Rows[i][nameof(Models.InventoryIn.UnitId)],
                            UnitName = (string)dt.Rows[i][nameof(Models.InventoryIn.UnitName)],
                        };

                        obj.Add(u);
                    }
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, obj);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpGet]
        [Route("Inventory/GetInventoryIn/{id}")]
        public HttpResponseMessage GetInventoryIn(int id)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                InventoryIn u = null;
                string sql = string.Format("Select * from InventoryIn where {0} = {1}", nameof(Models.InventoryIn.Id), id);

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new InventoryIn()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.InventoryIn.Id)],
                        ItemName = (string)dt.Rows[i][nameof(Models.InventoryIn.ItemName)],
                        ItemInDate = (DateTime)dt.Rows[i][nameof(Models.InventoryIn.ItemInDate)],
                        CategoryId = (int)dt.Rows[i][nameof(Models.InventoryIn.CategoryId)],
                        CategoryName = (string)dt.Rows[i][nameof(Models.InventoryIn.CategoryName)],
                        UnitId = (int)dt.Rows[i][nameof(Models.InventoryIn.UnitId)],
                        UnitName = (string)dt.Rows[i][nameof(Models.InventoryIn.UnitName)],
                    };
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, u);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpPost]
        [Route("Inventory/SaveInventoryIn")]
        public HttpResponseMessage SaveInventoryIn([FromBody] InventoryIn inv)
        {
            try
            {
                if (inv == null)
                {
                    throw new System.Exception("InventoryIn cannot be null");
                }

                string query = string.Empty;
                int responsecode = -1;

                if (inv.Id == 0)
                {
                    //add new user

                    query = string.Format("Insert into InventoryIn({0},{1},{2},{3}) values ('{4}',{5},{6},{7})"
                                        , nameof(Models.InventoryIn.ItemName)
                                        , nameof(Models.InventoryIn.Qty)
                                        , nameof(Models.InventoryIn.UnitId)
                                        , nameof(Models.InventoryIn.CategoryId)
                                        , inv.ItemName
                                        , inv.Qty
                                        , inv.UnitId
                                        , inv.CategoryId
                                        );
                }
                else
                {
                    // update user

                    query = string.Format("Update InventoryIn SET {0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}' WHERE {8} = {9}"
                                        , nameof(Models.InventoryIn.ItemName)
                                        , inv.ItemName
                                        , nameof(Models.InventoryIn.Qty)
                                        , inv.Qty
                                        , nameof(Models.InventoryIn.UnitId)
                                        , inv.UnitId
                                        , nameof(Models.InventoryIn.CategoryId)
                                        , inv.CategoryId
                                        , nameof(Models.InventoryIn.Id)
                                        , inv.Id
                                        );
                }

                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                responsecode = sQLConnectionClient.ExecuteSQLQuery(query);

                var response = Request.CreateResponse(HttpStatusCode.OK, responsecode);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpDelete]
        [Route("Inventory/DeleteSaveInventoryIn/{id}")]
        public HttpResponseMessage DeleteSaveInventoryIn(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new System.Exception("id cannot be null");
                }

                string query = string.Format("DELETE from InventoryIn where {0} = {1}"
                                        , nameof(Models.InventoryIn.Id)
                                        , id
                                        );

                int responsecode = -1;

                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                responsecode = sQLConnectionClient.ExecuteSQLQuery(query);

                var response = Request.CreateResponse(HttpStatusCode.OK, responsecode);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }


        [HttpGet]
        [Route("Inventory/GetInventoryOutAll")]
        public HttpResponseMessage GetInventoryOutAll()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = @"Select 
                               IO.*
                               ,C.CategoryName
                               ,U.UnitName
                               from InventoryOut IO
                               Left Join Category C On C.Id = IO.CategoryId
                               Left Join UnitOfMeasurement U On U.Id = IO.UnitId";

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<InventoryOut> obj = new List<InventoryOut>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        InventoryOut u = new InventoryOut()
                        {
                            Id = (int)dt.Rows[i][nameof(Models.InventoryOut.Id)],
                            Qty = (int)dt.Rows[i][nameof(Models.InventoryOut.Qty)],
                            ItemName = (string)dt.Rows[i][nameof(Models.InventoryOut.ItemName)],
                            ItemOutDate = (DateTime)dt.Rows[i][nameof(Models.InventoryOut.ItemOutDate)],
                            CategoryId = (int)dt.Rows[i][nameof(Models.InventoryOut.CategoryId)],
                            CategoryName = dt.Rows[i][nameof(Models.InventoryOut.CategoryName)] == DBNull.Value ? string.Empty : (string)dt.Rows[i][nameof(Models.InventoryOut.CategoryName)],
                            UnitId = (int)dt.Rows[i][nameof(Models.InventoryOut.UnitId)],
                            UnitName = dt.Rows[i][nameof(Models.InventoryOut.UnitName)] == DBNull.Value ? string.Empty : (string)dt.Rows[i][nameof(Models.InventoryOut.UnitName)],
                        };

                        obj.Add(u);
                    }
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, obj);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpGet]
        [Route("Inventory/GetInventoryOut/{id}")]
        public HttpResponseMessage GetInventoryOut(int id)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                InventoryOut u = null;
                string sql = string.Format("Select * from InventoryOut where {0} = {1}", nameof(Models.InventoryOut.Id), id);

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new InventoryOut()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.InventoryOut.Id)],
                        ItemName = (string)dt.Rows[i][nameof(Models.InventoryOut.ItemName)],
                        ItemOutDate = (DateTime)dt.Rows[i][nameof(Models.InventoryOut.ItemOutDate)],
                        CategoryId = (int)dt.Rows[i][nameof(Models.InventoryOut.CategoryId)],
                        CategoryName = (string)dt.Rows[i][nameof(Models.InventoryOut.CategoryName)],
                        UnitId = (int)dt.Rows[i][nameof(Models.InventoryOut.UnitId)],
                        UnitName = (string)dt.Rows[i][nameof(Models.InventoryOut.UnitName)],
                    };
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, u);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpPost]
        [Route("Inventory/SaveInventoryOut")]
        public HttpResponseMessage SaveInventoryOut([FromBody] InventoryIn inv)
        {
            try
            {
                if (inv == null)
                {
                    throw new System.Exception("InventoryOut cannot be null");
                }

                string query = string.Empty;
                int responsecode = -1;

                if (inv.Id == 0)
                {
                    //add new user

                    query = string.Format("Insert into InventoryOut({0},{1},{2},{3}) values ('{4}',{5},{6},{7})"
                                        , nameof(Models.InventoryOut.ItemName)
                                        , nameof(Models.InventoryOut.Qty)
                                        , nameof(Models.InventoryOut.UnitId)
                                        , nameof(Models.InventoryOut.CategoryId)
                                        , inv.ItemName
                                        , inv.Qty
                                        , inv.UnitId
                                        , inv.CategoryId
                                        );
                }
                else
                {
                    // update user

                    query = string.Format("Update InventoryOut SET {0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}' WHERE {8} = {9}"
                                        , nameof(Models.InventoryOut.ItemName)
                                        , inv.ItemName
                                        , nameof(Models.InventoryOut.Qty)
                                        , inv.Qty
                                        , nameof(Models.InventoryOut.UnitId)
                                        , inv.UnitId
                                        , nameof(Models.InventoryOut.CategoryId)
                                        , inv.CategoryId
                                        , nameof(Models.InventoryOut.Id)
                                        , inv.Id
                                        );
                }

                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                responsecode = sQLConnectionClient.ExecuteSQLQuery(query);

                var response = Request.CreateResponse(HttpStatusCode.OK, responsecode);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpDelete]
        [Route("Inventory/DeleteInventoryOut/{id}")]
        public HttpResponseMessage DeleteInventoryOut(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new System.Exception("id cannot be null");
                }

                string query = string.Format("DELETE from InventoryOut where {0} = {1}"
                                        , nameof(Models.InventoryOut.Id)
                                        , id
                                        );

                int responsecode = -1;

                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                responsecode = sQLConnectionClient.ExecuteSQLQuery(query);

                var response = Request.CreateResponse(HttpStatusCode.OK, responsecode);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpGet]
        [Route("Inventory/GetInventoryStatus")]
        public HttpResponseMessage GetInventoryStatus()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = string.Format(@"select
                                            I.ItemName {0}
                                            ,(SUM(I.Qty) - ISNULL((select SUM(O.Qty) from InventoryOut O where O.ItemName = I.ItemName 
                                            group by O.ItemName),0))[{1}]
                                            From InventoryIn I
                                            Group by I.ItemName
                                            "
                              , nameof(Models.Inventory.ItemName)
                              , nameof(Models.Inventory.StockQty)
                              );

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<Inventory> obj = new List<Inventory>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Inventory u = new Inventory()
                        {
                            ItemName = (string)dt.Rows[i][nameof(Models.Inventory.ItemName)],
                            StockQty = dt.Rows[i][nameof(Models.Inventory.StockQty)] == DBNull.Value ? 0 : (int)dt.Rows[i][nameof(Models.Inventory.StockQty)],
                        };

                        obj.Add(u);
                    }
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, obj);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
    }
}