using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Lab_3.Models;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Lab_3.Controllers
{
    public class StudentsController : ApiController
    {
        StudentContext context = new StudentContext();

        [HttpGet]
        public object Get(HttpRequestMessage request)
        {
            Uri uri = request.RequestUri;
            string format = HttpUtility.ParseQueryString(uri.Query).Get("format");
            try
            {
                int limit, sort, offset, minid, maxid;
                //limit
                if (HttpUtility.ParseQueryString(uri.Query).Get("limit") == null)
                {
                    limit = 999999;
                }
                else
                {
                    limit = Int32.Parse(HttpUtility.ParseQueryString(uri.Query).Get("limit"));
                }
                //sort
                if (HttpUtility.ParseQueryString(uri.Query).Get("sort") == null)
                {
                    sort = 0;
                }
                else if (HttpUtility.ParseQueryString(uri.Query).Get("sort") == "asc")
                {
                    sort = 1;
                }
                else if (HttpUtility.ParseQueryString(uri.Query).Get("sort") == "desc")
                {
                    sort = 2;
                }
                else
                {
                    throw new Exception();
                }
                //offset
                if (HttpUtility.ParseQueryString(uri.Query).Get("offset") == null)
                {
                    offset = 0;
                }
                else
                {
                    offset = Int32.Parse(HttpUtility.ParseQueryString(uri.Query).Get("offset"));
                }
                //minid
                if (HttpUtility.ParseQueryString(uri.Query).Get("minid") == null)
                {
                    minid = 0;
                }
                else
                {
                    minid = Int32.Parse(HttpUtility.ParseQueryString(uri.Query).Get("minid"));
                }
                //maxid
                if (HttpUtility.ParseQueryString(uri.Query).Get("maxid") == null)
                {
                    maxid = 999999;
                }
                else
                {
                    maxid = Int32.Parse(HttpUtility.ParseQueryString(uri.Query).Get("maxid"));
                }
                string like = HttpUtility.ParseQueryString(uri.Query).Get("like");
                string columns = HttpUtility.ParseQueryString(uri.Query).Get("columns");
                string globalike = HttpUtility.ParseQueryString(uri.Query).Get("globalike");
                List<Student> students = context.GetList(limit, sort, offset, minid, maxid, like, columns, globalike);
                Status status = new Status(200, 1, "Студент успешно получен");
                foreach (Student student in students)
                {
                    Link[] links = new Link[]
                    {
                        new Link("localhost:4413/api/students/" + student.Id, "GET", "Получить студента"),
                        new Link("localhost:4413/api/students/" + student.Id, "PUT", "Изменить студента"),
                        new Link("localhost:4413/api/students/" + student.Id, "DELETE", "Удалить студента")
                    };
                    student.Status = status;
                    student.Links = links;
                }

                bool isId = false, isName = false, isNumber = false;
                if (columns != null)
                {
                    if (columns.ToLower().Contains("id"))
                    {
                        isId = true;
                    }
                    if (columns.ToLower().Contains("name"))
                    {
                        isName = true;
                    }
                    if (columns.ToLower().Contains("number"))
                    {
                        isNumber = true;
                    }
                }

                List<object> list = new List<object>();
                if ((columns == null) || (isId == true && isName == true && isNumber == true))
                {
                    foreach (Student student in students)
                    {
                        var studentNumber = student;
                        list.Add(student);
                    }
                }
                else if (isId == true && isName == true && isNumber == false)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Id = student.Id, Name = student.Name, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else if (isId == true && isName == false && isNumber == true)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Id = student.Id, Number = student.Number, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else if (isId == true && isName == false && isNumber == false)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Id = student.Id, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else if (isId == false && isName == true && isNumber == true)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Name = student.Name, Number = student.Number, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else if (isId == false && isName == true && isNumber == false)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Name = student.Name, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else if (isId == false && isName == false && isNumber == true)
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Number = student.Number, Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }
                else
                {
                    foreach (Student student in students)
                    {
                        var varStudent = new { Links = student.Links, Status = student.Status };
                        list.Add(varStudent);
                    }
                }

                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return list;
                }
                else
                {
                    string status_400 = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(status_400, Encoding.UTF8, "application/json")
                    };
                }
            }
            catch
            {
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 0, "Ошибка в передаваемых параметрах")), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var status = new Status(400, 0, "Ошибка в передаваемых параметрах");
                            var serializer = new XmlSerializer(status.GetType());
                            serializer.Serialize(stringwriter, status);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string incorrectParams = JsonConvert.SerializeObject(new Status(400, 0, "Ошибка в передаваемых параметрах"));
                        string incorrectFormat = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(incorrectParams + ",\n" + incorrectFormat, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
        }
        
        [HttpGet]
        public object Get(int id, HttpRequestMessage request)
        {
            Uri uri = request.RequestUri;
            string format = HttpUtility.ParseQueryString(uri.Query).Get("format");
            try
            {
                Student student = context.GetOne(id);
                Link[] links = new Link[]
                {
                    new Link("localhost:4413/api/students/" + id, "PUT", "Изменить студента"),
                    new Link("localhost:4413/api/students/" + id, "DELETE", "Удалить студента")
                };
                Status status = new Status(200, 1, "Студент успешно получен");
                student.Status = status;
                student.Links = links;
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return student;
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var serializer = new XmlSerializer(student.GetType());
                            serializer.Serialize(stringwriter, student);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат")), Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
            catch
            {
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 1, "Указанный студент не найден")), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var status = new Status(400, 1, "Указанный студент не найден");
                            var serializer = new XmlSerializer(status.GetType());
                            serializer.Serialize(stringwriter, status);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string studentNotFound = JsonConvert.SerializeObject(new Status(400, 1, "Указанный студент не найден"));
                        string incorrectFormat = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(studentNotFound + ",\n" + incorrectFormat, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
        }
        
        [HttpPost]
        public object Post(HttpRequestMessage request)
        {
            Uri uri = request.RequestUri;
            string format = HttpUtility.ParseQueryString(uri.Query).Get("format");
            var body = request.Content;
            string json = body.ReadAsStringAsync().Result;
            dynamic data = JObject.Parse(json);
            try
            {
                Student student = context.Post(Convert.ToString(data.name), Convert.ToInt32(data.number));
                Link[] links = new Link[]
                {
                    new Link("localhost:4413/api/students" , "GET", "Получить список студентов"),
                };
                Status status = new Status(200, 2, "Студент успешно добавлен");
                student.Status = status;
                student.Links = links;

                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return student;
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var serializer = new XmlSerializer(student.GetType());
                            serializer.Serialize(stringwriter, student);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string status_400 = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(status_400, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
            catch
            {
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 2, "Ошибка добавления студента")), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var status = new Status(400, 2, "Ошибка добавления студента");
                            var serializer = new XmlSerializer(status.GetType());
                            serializer.Serialize(stringwriter, status);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string studentNotAdd = JsonConvert.SerializeObject(new Status(400, 2, "Ошибка добавления студента"));
                        string incorrectFormat = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(studentNotAdd + ",\n" + incorrectFormat, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
        }
        
        [HttpPut]
        public object Put(int id, HttpRequestMessage request)
        {
            Uri uri = request.RequestUri;
            string format = HttpUtility.ParseQueryString(uri.Query).Get("format");
            var body = request.Content;
            string json = body.ReadAsStringAsync().Result;
            dynamic data = JObject.Parse(json);
            try
            {
                Student student = context.Put(id, Convert.ToString(data.name), Convert.ToInt32(data.number));
                Link[] links = new Link[]
                {
                    new Link("localhost:4413/api/students/" + id, "GET", "Получить студента"),
                    new Link("localhost:4413/api/students/" + id, "DELETE", "Удалить студента")
                };
                Status status = new Status(200, 3, "Студент успешно изменен");
                student.Status = status;
                student.Links = links;

                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return student;
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var serializer = new XmlSerializer(student.GetType());
                            serializer.Serialize(stringwriter, student);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string status_400 = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(status_400, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
            catch
            {
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 3, "Ошибка изменения студента")), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var status = new Status(400, 3, "Ошибка изменения студента");
                            var serializer = new XmlSerializer(status.GetType());
                            serializer.Serialize(stringwriter, status);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string studentNotUpdate = JsonConvert.SerializeObject(new Status(400, 3, "Ошибка изменения студента"));
                        string incorrectFormat = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(studentNotUpdate + ",\n" + incorrectFormat, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
        }
        
        [HttpDelete]
        public object Delete(int id, HttpRequestMessage request)
        {
            Uri uri = request.RequestUri;
            string format = HttpUtility.ParseQueryString(uri.Query).Get("format");
            var body = request.Content;
            string json = body.ReadAsStringAsync().Result;
            dynamic data = JObject.Parse(json);
            try
            {
                Student student = context.Delete(id);
                Link[] links = new Link[]
                {
                    new Link("localhost:4413/api/students/" + id, "GET", "Получить студента"),
                    new Link("localhost:4413/api/students/" + id, "PUT", "Изменить студента")
                };
                Status status = new Status(200, 4, "Студент успешно удален");
                student.Status = status;
                student.Links = links;

                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return student;
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var serializer = new XmlSerializer(student.GetType());
                            serializer.Serialize(stringwriter, student);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string status_400 = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(status_400, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
            catch
            {
                if (format == "undefined" || format == null || format.ToLower() == "json")
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent(JsonConvert.SerializeObject(new Status(400, 4, "Ошибка удаления студента")), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    if (format.ToLower() == "xml")
                    {
                        using (var stringwriter = new System.IO.StringWriter())
                        {
                            var status = new Status(400, 4, "Ошибка удаления студента");
                            var serializer = new XmlSerializer(status.GetType());
                            serializer.Serialize(stringwriter, status);
                            string xml = stringwriter.ToString();
                            return new HttpResponseMessage()
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Content = new StringContent(xml, Encoding.UTF8, "application/xml")
                            };
                        }
                    }
                    else
                    {
                        string studentNotDelete = JsonConvert.SerializeObject(new Status(400, 4, "Ошибка удаления студента"));
                        string incorrectFormat = JsonConvert.SerializeObject(new Status(400, 6, "Неизвестный формат"));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Content = new StringContent(studentNotDelete + ",\n" + incorrectFormat, Encoding.UTF8, "application/json")
                        };
                    }
                }
            }
        }
    }
}