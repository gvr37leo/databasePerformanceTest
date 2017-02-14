using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace couchDBCsharp{
    enum Method {GET, POST, PUT, DELETE}
    delegate void responseHandler(string res);

    

    class Request{

        public Method method = Method.GET;
        public HttpClient httpClient = new HttpClient();
        public string url;
        public object json = new { };
        //private static Dictionary<Method, responseHandler> resHandlers = new Dictionary<Method, responseHandler>();
        

        public Request(string url) {
            this.url = url;
            //resHandlers.Add(Method.GET, (err, res) => {

            //});
            //resHandlers.Add(Method.POST, (err, res) => {

            //});
            //resHandlers.Add(Method.PUT, (err, res) => {

            //});
            //resHandlers.Add(Method.DELETE, (err, res) => {

            //});
        }

        public Request type(Method m) {
            method = m;
            return this;
        }

        public Request send(object json) {
            this.json = json;
            return this;
        }

        public Request set(string name, string value) {
            httpClient.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        public async void end(responseHandler callback) {
            HttpResponseMessage res = null;
            StringContent sc = new StringContent(JsonConvert.SerializeObject(json));
            switch (method) {
                case Method.GET:
                    res = await httpClient.GetAsync(url);
                    break;
                case Method.POST:
                    res = await httpClient.PostAsync(url, sc);
                    break;
                case Method.PUT:
                    res = await httpClient.PutAsync(url, sc);
                    break;
                case Method.DELETE:
                    res = await httpClient.DeleteAsync(url);
                    break;
            }
            callback(await res.Content.ReadAsStringAsync());
        }
    }
}
