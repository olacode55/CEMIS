using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using CEMIS.Data;
using CEMIS.Utility;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Web.Utilities
{
    class TimeoutableStream : System.IO.Stream
    {
        // implement unnecessary properties
        public override int ReadTimeout
        {
            get { try { return _innerStream.ReadTimeout; } catch (InvalidOperationException) { return int.MaxValue; } }
            set { try { _innerStream.ReadTimeout = value; } catch (InvalidOperationException) { } }
        }
        public override int WriteTimeout
        {
            get { try { return _innerStream.WriteTimeout; } catch (InvalidOperationException) { return int.MaxValue; } }
            set { try { _innerStream.WriteTimeout = value; } catch (InvalidOperationException) { } }
        }

        private System.IO.Stream _innerStream;
        public TimeoutableStream(System.IO.Stream innerStream)
        {
            _innerStream = innerStream;
        }

        #region wrapper
        public override bool CanRead => _innerStream.CanRead;

        public override bool CanSeek => _innerStream.CanSeek;

        public override bool CanWrite => _innerStream.CanWrite;

        public override long Length => _innerStream.Length;

        public override long Position { get => _innerStream.Position; set => _innerStream.Position = value; }

        public override void Flush()
        {
            _innerStream.Flush();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            return _innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _innerStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _innerStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _innerStream.Write(buffer, offset, count);
        }
        #endregion
    }


    /// <summary>
    /// A generic wrapper class to REST API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class HTTPClientWrapper<T> where T : class
    {
        /// <summary>
        /// For getting the resources from a web api
        /// </summary>
        /// <param name="url">API Url</param>
        /// <returns>A Task with result object of type T</returns>
        public static async Task<T> Get(string url)
        {
            T result = null;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;

                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<T>(x.Result);
                });
            }

            return result;
        }

        /// <summary>
        /// For creating a new item over a web api using POST
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="postObject">The object to be created</param>
        /// <returns>A Task with created item</returns>
        public static async Task<ResponseBaseModel> PostRequest(string apiUrl, T postObject)
        {
            ResponseBaseModel result = null;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(true);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<ResponseBaseModel>(x.Result);

                });
            }

            return result;
        }

        public static async Task<ResponseBaseModel> PostStudentRequest(string apiUrl, StudentViewModel postObject, FileStream fileStream, string fileName)
        {
            ResponseBaseModel result = null;

            using (var client = new HttpClient())
            {

                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                //HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                //{
                //    Content = new StringContent((JsonConvert.SerializeObject(postObject)), Encoding.UTF8, "application/json")
                //        };
                var formContent = new MultipartFormDataContent
                        {
                             {new StringContent(postObject.OtherNames), "OtherNames"},
                             {new StringContent(postObject.AppRefNumber), "AppRefNumber"  },
                             {new StringContent(postObject.ContactAddress), "ContactAddress"  },
                             {new  StringContent(postObject.CreatedBy.ToString()), "CreatedBy"  },
                             {new StringContent(postObject.DateCreated.ToString("dd/MM/yyyy HH:mm:ss")), "DateCreated"  },
                             //{new StringContent(postObject.DateUpdated == null ? string.Empty : postObject.DateUpdated.ToString("dd/MM/yyyy HH:mm:ss")), "DateUpdated"  },
                             {new StringContent(postObject.Disability == null ? string.Empty : postObject.Disability), "Disability"  },
                             {new StringContent(postObject.District == null ? string.Empty : postObject.District), "District"  },
                             {new StringContent(postObject.DOB.ToString("dd/MM/yyyy HH:mm:ss")), "DOB"  },
                             {new StringContent(postObject.FirstChoiceCollege == null ? string.Empty : postObject.FirstChoiceCollege), "FirstChoiceCollege"  },
                             {new StringContent(postObject.FirstChoiceProgram == null ? string.Empty : postObject.FirstChoiceProgram), "FirstChoiceProgram"  },
                             {new StringContent(postObject.Gender.ToString()), "Gender"  },
                             {new StringContent(postObject.HomeTown == null ? string.Empty : postObject.HomeTown.ToString()), "HomeTown"  },
                             {new StringContent(postObject.Id.ToString()), "Id"  },
                             {new StringContent(postObject.IsActive.ToString()), "IsActive"  },
                             {new StringContent(postObject.IsDeleted.ToString()), "IsDeleted"  },
                             {new StringContent(postObject.LanguagesSpoken == null ? string.Empty : postObject.LanguagesSpoken.ToString()), "LanguagesSpoken"  },
                             {new StringContent(postObject.MaritalStatus.ToString()), "MaritalStatus"  },
                             {new StringContent(postObject.ParentParticulars == null ? string.Empty : postObject.ParentParticulars.ToString()), "ParentParticulars"  },
                             {new StringContent(postObject.Passport == null ? string.Empty : postObject.Passport.ToString()), "Passport"  },
                             {new StringContent(postObject.POB == null ? string.Empty : postObject.POB.ToString()), "POB"  },
                             {new StringContent(JsonConvert.SerializeObject(postObject.previousEducations)), "previousEducations"  },
                             {new StringContent(postObject.Region == null ? string.Empty : postObject.Region), "Region"  },
                             {new StringContent(postObject.Religion == null ? string.Empty : postObject.Religion), "Religion"},
                             {new StringContent(postObject.Result == null ? string.Empty :postObject.Result), "Result"  },
                             {new StringContent(postObject.SecondChoiceCollege == null ? string.Empty : postObject.SecondChoiceCollege), "SecondChoiceCollege"  },
                             {new StringContent(postObject.SecondChoiceProgram == null ? string.Empty : postObject.SecondChoiceProgram), "SecondChoiceProgram"  },
                             {new StringContent(postObject.Surname == null ? string.Empty : postObject.Surname), "Surname"  },
                             {new StringContent(postObject.TelephoneNumber == null ? string.Empty :postObject.TelephoneNumber), "TelephoneNumber"  },
                             {new StringContent(postObject.DateUpdated == null ? string.Empty : postObject.ThirdChoiceCollege), "ThirdChoiceCollege"  },
                             {new StringContent(postObject.ThreeChoiceProgram == null ? string.Empty :postObject.ThreeChoiceProgram), "ThreeChoiceProgram"  },
                             {new StringContent(postObject.StudentId == null ? string.Empty :postObject.StudentId), "StudentId"  },
                             {new StringContent(postObject.RegistrationPin == null ? string.Empty :postObject.RegistrationPin), "RegistrationPin"  },
                             {new StringContent(postObject.DropOutComment == null ? string.Empty :postObject.DropOutComment), "DropOutComment"  },
                             {new StringContent(postObject.ProgramId.ToString()), "ProgramId"  },

                               //{new StringContent(postObject.UpdatedBy, "UpdatedBy" ) },
                             {new StreamContent(fileStream), "File", fileName}

                            //{new StreamContent(new FileStream("C:\\Vatebra Projects\\CEMIS\\CEMIS.Web\\wwwroot\\StudentPhotos\\bgCopy.jpg", FileMode.Open)), "File", "filename.jpeg"}
                        };



                var response = await client.PostAsync(apiUrl, formContent).ConfigureAwait(true);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<ResponseBaseModel>(x.Result);

                });
            }

            return result;
        }


        public static async Task<ResponseBaseModel> Postrequest(string apiUrl, T postObject)
        {
            ResponseBaseModel result = null;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(true);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<ResponseBaseModel>(x.Result);

                });
            }

            return result;
        }

        /// <summary>
        /// For updating an existing item over a web api using PUT
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="putObject">The object to be edited</param>
        public static async Task<ResponseBaseModel> PutRequest(string apiUrl, T putObject)
        {
            ResponseBaseModel result = null;
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(apiUrl, putObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<ResponseBaseModel>(x.Result);

                });
            }
            return result;
        }


        public static async Task DeleteRequest(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(apiUrl);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
