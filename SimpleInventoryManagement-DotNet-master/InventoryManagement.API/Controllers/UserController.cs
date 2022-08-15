using InventoryManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagement.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("User/GetAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                string sql = "Select * from Users";

                DataTable dt = sQLConnectionClient.ReadData(sql);
                List<User> users = new List<User>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        User u = new User()
                        {
                            Id = (int)dt.Rows[i][nameof(Models.User.Id)],
                            UserName = (string)dt.Rows[i][nameof(Models.User.UserName)],
                            Password = (string)dt.Rows[i][nameof(Models.User.Password)],
                            FirstName = (string)dt.Rows[i][nameof(Models.User.FirstName)],
                            LastName = (string)dt.Rows[i][nameof(Models.User.LastName)],
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
        [Route("User/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                User u = null;
                string sql = string.Format("Select * from Users where {0} = {1}", nameof(Models.User.Id), id);

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new User()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.User.Id)],
                        UserName = (string)dt.Rows[i][nameof(Models.User.UserName)],
                        Password = (string)dt.Rows[i][nameof(Models.User.Password)],
                        FirstName = (string)dt.Rows[i][nameof(Models.User.FirstName)],
                        LastName = (string)dt.Rows[i][nameof(Models.User.LastName)],
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


        [HttpGet]
        [Route("User/AuthenticateUser/{UserName}/{Password}")]
        public HttpResponseMessage AuthenticateUser(string UserName, string Password)
        {
            try
            {
                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();

                User u = null;
                string sql = string.Format("Select TOP 1 * from Users where {0} = '{1}' and {2} = '{3}'"
                                           , nameof(Models.User.UserName)
                                           , UserName
                                           , nameof(Models.User.Password)
                                           , Password
                                           );

                DataTable dt = sQLConnectionClient.ReadData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;

                    u = new User()
                    {
                        Id = (int)dt.Rows[i][nameof(Models.User.Id)],
                        UserName = (string)dt.Rows[i][nameof(Models.User.UserName)],
                        Password = (string)dt.Rows[i][nameof(Models.User.Password)],
                        FirstName = (string)dt.Rows[i][nameof(Models.User.FirstName)],
                        LastName = (string)dt.Rows[i][nameof(Models.User.LastName)],
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
        [Route("User/SaveUser")]
        public HttpResponseMessage SaveUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    throw new System.Exception("user cannot be null");
                }

                string query = string.Empty;
                int responsecode = -1;

                if (user.Id == 0)
                {
                    //add new user

                    query = string.Format("Insert into users({0},{1},{2},{3}) values ('{4}','{5}','{6}','{7}')"
                                        , nameof(Models.User.UserName)
                                        , nameof(Models.User.Password)
                                        , nameof(Models.User.FirstName)
                                        , nameof(Models.User.LastName)
                                        , user.UserName
                                        , user.Password
                                        , user.FirstName
                                        , user.LastName
                                        );
                }
                else
                {
                    // update user

                    query = string.Format("Update users SET {0} = '{4}' ,{1} = '{5}', {2} = '{6}', {3} = '{7}' WHERE {8} = {9}"
                                        , nameof(Models.User.UserName)
                                        , nameof(Models.User.Password)
                                        , nameof(Models.User.FirstName)
                                        , nameof(Models.User.LastName)
                                        , user.UserName
                                        , user.Password
                                        , user.FirstName
                                        , user.LastName
                                        , nameof(Models.User.Id)
                                        , user.Id
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


        [HttpPost]
        [Route("User/DeleteSaveAllUser")]
        public HttpResponseMessage DeleteSaveAllUser([FromBody] List<User> users)
        {
            try
            {
                if (users == null)
                {
                    throw new System.Exception("user cannot be null");
                }

                SQLConnectionClient sQLConnectionClient = new SQLConnectionClient();
                string query = "Delete from users";
                int responsecode = -1;

                responsecode = sQLConnectionClient.ExecuteSQLQuery(query);

                for (int i = 0; i < users.Count; i++)
                {
                    query = string.Format("Insert into users({0},{1},{2},{3}) values ('{4}','{5}','{6}','{7}')"
                                       , nameof(Models.User.UserName)
                                       , nameof(Models.User.Password)
                                       , nameof(Models.User.FirstName)
                                       , nameof(Models.User.LastName)
                                       , users[i].UserName
                                       , users[i].Password
                                       , users[i].FirstName
                                       , users[i].LastName
                                       );

                    responsecode = sQLConnectionClient.ExecuteSQLQuery(query);
                }

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
        [Route("User/DeleteUser/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new System.Exception("id cannot be null");
                }

                string query = string.Format("DELETE from users where {0} = {1}"
                                        , nameof(Models.User.Id)
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