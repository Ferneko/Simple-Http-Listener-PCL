﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpMachine;
using ISimpleHttpServer.Model;

namespace SimpleHttpServer.Parser
{
    internal class HttpParserHandler : IHttpRequestParserDelegate, IHttpRequest
    {
        public string Method { get; private set; }
        public string RequstUri { get; private set; }
        public string Path { get; private set; }
        public string QueryString { get; private set; }

        public string Fragment { get; private set; }

        public IDictionary<string, string> Headers { get; private set; } = new Dictionary<string, string>();

        public MemoryStream Body { get; private set; } = new MemoryStream();

        public bool IsEndOfRequest { get; private set; }


        public void OnMessageBegin(HttpParser parser)
        {
            
            //throw new NotImplementedException();
        }

        public void OnMethod(HttpParser parser, string method)
        {
            Method = method;
        }

        public void OnRequestUri(HttpParser parser, string requestUri)
        {
            RequstUri = requestUri;
        }

        public void OnPath(HttpParser parser, string path)
        {
            Path = path;
        }

        public void OnFragment(HttpParser parser, string fragment)
        {
            Fragment = fragment;
        }

        public void OnQueryString(HttpParser parser, string queryString)
        {
            QueryString = queryString;
        }

        private string _headerName = null; 
        public void OnHeaderName(HttpParser parser, string name)
        {
            _headerName = name;
        }

        public void OnHeaderValue(HttpParser parser, string value)
        {
            Headers[_headerName] = value;
        }

        public void OnHeadersEnd(HttpParser parser)
        {
            //throw new NotImplementedException();
        }

        public void OnBody(HttpParser parser, ArraySegment<byte> data)
        {
            Body.Write(data.Array, 0, data.Array.Length);
        }

        public void OnMessageEnd(HttpParser parser)
        {
            IsEndOfRequest = true;
        }
    }
}