using Business.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Hosting;
using Serilog.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookStore.BLL.Extensions;

namespace Business.Middlewares
{
    public class BaseRequestHandler
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public BaseRequestHandler(RequestDelegate next, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            _next = next;
            _env = env;

            appLifetime.ApplicationStopped.Register(() =>
            {
                Log.Information("Uygulama durduruldu {StopDate}", DateTime.Now);
            });
            appLifetime.ApplicationStarted.Register(() =>
            {
                Log.Information("Uygulama başlatıldı {StartDate}", DateTime.Now);
            });
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await MonitorResponse(context);
            }
            catch (Exception ex)
            {
                string exMessage = "İşlem sırasında bir hata ile karşılaşıldı. ";
                await HandleExceptionAsync(context, ex);


                Log.Fatal(ex, "HTTPStatusCode: {HTTPStatusCode}", context.Response.StatusCode);
            }
        }

        public async Task MonitorResponse(HttpContext httpContext)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            var logContext = LogContext.Push();
            LogContext.PushProperty("IPAddress", GetUserIP(httpContext));
            LogContext.PushProperty("TraceId", Activity.Current?.TraceId.ToString() ?? httpContext.TraceIdentifier);
            {
                try
                {
                    string requestBody = "";
                    httpContext.Request.EnableBuffering(httpContext.Request.ContentLength.GetValueOrDefault());
                    var readerReqBody = new StreamReader(httpContext.Request.Body);
                    requestBody = await FormatRequest(httpContext.Request, readerReqBody);//body lazım olursa 
                    LogContext.PushProperty("RequestBody", requestBody, false);
                    LogContext.PushProperty("RequestQueryString", httpContext.Request.QueryString, false);
                    string formJson = null;
                    //if (httpContext.Request.HasFormContentType)
                    //{
                    //    var form = await httpContext.Request.ReadFormAsync();
                    //    //formJson = JsonConvert.SerializeObject(form, Formatting.None);
                    //    formJson = System.Text.Json.JsonSerializer.Serialize(form, null, new JsonSerializerOptions { });
                    //}
                    LogContext.PushProperty("RequestForm", formJson, false);
                    LogContext.PushProperty("RequestMethod", httpContext.Request.Method);
                    LogContext.PushProperty("RequestPath", httpContext.Request.Path);

                    string controllerName = "";
                    string actionName = "";
                    var endpoint = httpContext.GetEndpoint();
                    //bool isAPI = false;
                    if (endpoint != null)
                    {
                        var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                        //isAPI = controllerActionDescriptor.ControllerTypeInfo.CustomAttributes.Count(x => x.AttributeType.Name == "ApiControllerAttribute") > 0;
                        if (controllerActionDescriptor != null)
                        {
                            controllerName = controllerActionDescriptor.ControllerName;
                            actionName = controllerActionDescriptor.ActionName;
                            LogContext.PushProperty("Controller", controllerName);
                            LogContext.PushProperty("Action", actionName);
                        }
                    }
                    try
                    {
                        await _next(httpContext);
                        if (controllerName != "" && actionName != "")
                        {
                            Log.Information("HTTPStatusCode: {HTTPStatusCode} Duration: {Duration} ms", httpContext.Response.StatusCode, st.Elapsed.TotalMilliseconds);
                        }
                    }
                    catch (Exception ex)
                    {
                        await HandleExceptionAsync(httpContext, ex);
                        //buradaki log.fatal 302 dönüyor çünkü handleexceptionda contexti redirect yaptık.
                        Log.Fatal(ex, "HTTPStatusCode: {HTTPStatusCode} Duration: {Duration} ms", httpContext.Response.StatusCode, st.Elapsed.TotalMilliseconds);
                    }
                    finally
                    {
                        readerReqBody.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Response monitor hatası.");
                    await _next(httpContext);
                }
            }
            logContext.Dispose();
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            bool isAPI = false; //api endpoint eklenirse lazım olabiir
            bool isAjaxRequest = context.Request.IsAjaxRequest(); // ajax isteklerinin hata yönetimi için farklı bir sonuç döneceksek lazım.

            string controllerName = string.Empty;
            string actionName = string.Empty;
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if (controllerActionDescriptor != null)
                {
                    isAPI = controllerActionDescriptor.ControllerTypeInfo.CustomAttributes.Any(x => x.AttributeType.Name == "ApiControllerAttribute");
                    controllerName = controllerActionDescriptor.ControllerName;
                    actionName = controllerActionDescriptor.ActionName;
                }
            }

            LogDetailWithException logDetailWithException = new LogDetailWithException
            {
                UserName = context.User.Identity?.Name,
                RequestMethod = context.Request.Method,
                Exception = JsonConvert.SerializeObject(exception, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
                RequestPath = context.Request.Path,
                Action = actionName,
                Controller = controllerName,
                RequestQueryString = context.Request.QueryString,
                IpAddress = GetUserIP(context)
            };

            logDetailWithException.PushProperty();
            Log.Error(exception, "Error: {@ErrorCode} - Status Code {StatusCode})", exception.Message, context.Response.StatusCode);


            return CreateInternalException(context, exception);
        }
        private Task CreateInternalException(HttpContext context, Exception exception)
        {
            context.Response.Redirect("/Home/Error");
            return Task.CompletedTask;
        }
        private async Task<string> FormatRequest(HttpRequest request, StreamReader reader)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            string text = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
        private string GetUserIP(HttpContext httpContext)
        {
            if (!string.IsNullOrEmpty(httpContext.Request.Headers["HTTP_X_FORWARDED_FOR"]))
            {
                return httpContext.Request.Headers["HTTP_X_FORWARDED_FOR"].FirstOrDefault();
            }
            else if (!string.IsNullOrEmpty(httpContext.Request.Headers["X-Forwarded-For"]))
            {
                return httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            }
            else
            {
                return httpContext.Connection.RemoteIpAddress.ToString();
            }
        }


    }
}
