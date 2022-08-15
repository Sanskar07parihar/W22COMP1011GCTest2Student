using InventoryManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.API.Controllers
{
    public class UnitController : ApiController
    {
        [HttpGet]
        [Route("Unit/GetAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = "Select * from UnitOfMeasurement";

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<UnitOfMeasurement> users = new List<UnitOfMeasurement>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UnitOfMeasurement u = new UnitOfMeasurement()
                        {
                            Id = (int)dt.Rows[i][nameof(Models.UnitOfMeasurement.Id)],
                            UnitName = (string)dt.Rows[i][nameof(Models.UnitOfMeasurement.UnitName)],
                        };

                        users.Add(u);
                    }
                }

                var response = Request.CreateResponse(HttpStatusCode.OK, users);
                return response;
            }
            catch (System.Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        [HttpGet]
        [Route("Unit/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                UnitOfMeasurement u = null;
                string sql = string.Format("Select * from UnitOfMeasurement where {0} = {1}", nameof(Models.UnitOfMeasurement.Id), id);

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new UnitOfMeasurement()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.UnitOfMeasurement.Id)],
                        UnitName = (string)dt.Rows[i][nameof(Models.UnitOfMeasurement.UnitName)],
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
        [Route("Unit/SaveUnit")]
        public HttpResponseMessage SaveUnit([FromBody] UnitOfMeasurement uom)
        {
            try
            {
                if (uom == null)
                {
                    throw new System.Exception("Unit Of Measurement cannot be null");
                }

                string query = string.Empty;
                int responsecode = -1;

                if (uom.Id == 0)
                {
                    //add new user

                    query = string.Format("Insert into UnitOfMeasurement({0}) values ('{1}')"
                                        , nameof(Models.UnitOfMeasurement.UnitName)
                                        , uom.UnitName
                                        );
                }
                else
                {
                    // update user

                    query = string.Format("Update UnitOfMeasurement SET {0} = '{1}' WHERE {2} = {3}"
                                        , nameof(Models.UnitOfMeasurement.UnitName)
                                        , uom.UnitName
                                        , nameof(Models.UnitOfMeasurement.Id)
                                        , uom.Id
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
        [Route("User/DeleteUnit/{id}")]
        public HttpResponseMessage DeleteUnit(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new System.Exception("id cannot be null");
                }

                string query = string.Format("DELETE from UnitOfMeasurement where {0} = {1}"
                                        , nameof(Models.UnitOfMeasurement.Id)
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
    }
}