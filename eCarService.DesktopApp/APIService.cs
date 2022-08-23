using eCarService.DesktopApp.Properties;
using eCarService.Model;
using eCarService.Model.Helpers;
using eCarService.Model.Requests;
using eCarService.WinUI.Properties;
using Flurl.Http;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCarService.WinUI
{
    public class APIService
    {
        private string _resource;
        //public string endpoint = $"{Resources.localhost}";
        public string endpoint = $"{Resources.dev}";

        public static string Username = null;
        public static string Password = null;

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search = null)
        {
            try
            {
                var query = "";

                if (search != null)
                {
                    query = await search?.ToQueryString();
                }

                var result = await $"{endpoint}{_resource}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();

                var errors = errorResponse.First(x => x.Key == "errors");

                string errorsJsonString = String.Join(",", errors.Value);

                Dictionary<string, string[]> errorsMap = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsJsonString);

                var stringBuilder = new StringBuilder();
                foreach (var error in errorsMap)
                {
                    stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }



        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var result = await $"{endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();

                var errors = errorResponse.First(x => x.Key == "errors");

                string errorsJsonString = String.Join(",", errors.Value);

                Dictionary<string, string[]> errorsMap = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsJsonString);

                var stringBuilder = new StringBuilder();
                foreach (var error in errorsMap)
                {
                    stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Post<T>(object request, bool register = false)
        {
            try
            {
                T result;

                if (register)
                {
                     result = await $"{endpoint}{_resource}".PostJsonAsync(request).ReceiveJson<T>();
                }
                else
                {
                     result = await $"{endpoint}{_resource}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

                }
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();

                var errors = errorResponse.First(x => x.Key == "errors");

                string errorsJsonString = String.Join(",", errors.Value);

                Dictionary<string, string[]> errorsMap = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsJsonString);

                var stringBuilder = new StringBuilder();
                foreach (var error in errorsMap)
                {
                    stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Put<T>(object id, object request)
        {
            try
            {
                var result = await $"{endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();

                var errors = errorResponse.First(x => x.Key == "errors");

                string errorsJsonString = String.Join(",", errors.Value);

                Dictionary<string, string[]> errorsMap = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsJsonString);

                var stringBuilder = new StringBuilder();
                foreach (var error in errorsMap)
                {
                    stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var result = await $"{endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errorResponse = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();

                var errors = errorResponse.First(x => x.Key == "errors");

                string errorsJsonString = String.Join(",", errors.Value);

                Dictionary<string, string[]> errorsMap = JsonSerializer.Deserialize<Dictionary<string, string[]>>(errorsJsonString);

                var stringBuilder = new StringBuilder();
                foreach (var error in errorsMap)
                {
                    stringBuilder.AppendLine($"{error.Key}:\n{string.Join("\n", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
