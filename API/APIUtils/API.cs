﻿using API.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace API.APIUtils
{
    public class API
    {
        public static RestRequest request { get; private set; }

        private void AddingParameters(ParameterType type, params (string key, string value)[] header)
        {
            foreach ((string key, string value) in header)
            {
                request.AddParameter(key, value, type);
            }
        }

        public RestRequest CreateHeadRequest(string resource)
        {
            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            
            request = new RestRequest(resource, Method.Head);
            AddingParameters(ParameterType.HttpHeader, ("Accept", "application/json"));

            return request;
        }

        public RestRequest CreateGetRequest(string resource,
            params (string key, string value)[] headers)
        {
            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            
            request = new RestRequest(resource, Method.Get);
            if (headers != null)
                AddingParameters(ParameterType.HttpHeader, headers);

            return request;
        }

        public RestRequest CreatePostRequest(string resource,
            params (string key, string value)[] headers)
        {
            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");
            request = new RestRequest(resource, Method.Post);
            if (headers != null)
                AddingParameters(ParameterType.HttpHeader, headers);

            return request;
        }

        public RestRequest CreatePostRequest<TModel>(string resource, TModel model,
            params (string key, string value)[] headers) where TModel : class
        {
            if (resource.Length < 1)
                throw new CreateRequestException("The resource is invalid");

            request = new RestRequest(resource, Method.Post);
            if (model != null)
                request.AddJsonBody<TModel>(model);
            if (headers != null)
                AddingParameters(ParameterType.HttpHeader, headers);

            return request;
        }

        public RestResponse GetResponse(RestRequest request)
        {
            return Client.GetClient.Execute(request);
        }

        public T DeserializeToClass<T>(RestResponse response) where T : class, new()
        {
            if (response != null)
                return JsonConvert.DeserializeObject<T>(response.Content);
            throw new NullReferenceException("The response is null");
        }

        public static void CloseRequest()
        {
            request = null;
        }
    }
}
