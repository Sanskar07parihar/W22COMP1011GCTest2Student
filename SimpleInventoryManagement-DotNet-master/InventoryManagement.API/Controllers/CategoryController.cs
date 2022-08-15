using InventoryManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.API.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("Category/GetAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = "Select * from Category";

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<Category> users = new List<Category>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Category u = new Category()
                        {
                            Id = (int)dt.Rows[i][nameof(Models.Category.Id)],
                            CategoryName = (string)dt.Rows[i][nameof(Models.Category.CategoryName)],
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
        [Route("Category/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                Category u = null;
                string sql = string.Format("Select * from Category where {0} = {1}", nameof(Models.Category.Id), id);

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new Category()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.Category.Id)],
                        CategoryName = (string)dt.Rows[i][nameof(Models.Category.CategoryName)],
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
        [Route("Category/SaveCategory")]
        public HttpResponseMessage SaveCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new System.Exception("Category cannot be null");
                }

                string query = string.Empty;
                int responsecode = -1;

                if (category.Id == 0)
                {
                    //add new user

                    query = string.Format("Insert into Category({0}) values ('{1}')"
                                        , nameof(Models.Category.CategoryName)
                                        , category.CategoryName
                                        );
                }
                else
                {
                    // update user

                    query = string.Format("Update Category SET {0} = '{1}' WHERE {2} = {3}"
                                        , nameof(Models.Category.CategoryName)
                                        , category.CategoryName
                                        , nameof(Models.Category.Id)
                                        , category.Id
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
        [Route("User/DeleteCategory/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new System.Exception("id cannot be null");
                }

                string query = string.Format("DELETE from Category where {0} = {1}"
                                        , nameof(Models.Category.Id)
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