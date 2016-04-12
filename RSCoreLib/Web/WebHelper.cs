using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSCoreLib.Web
    {
    public static class WebHelper
        {
        public const string PLAIN_UTF8_CONTENT_TYPE = "text/plain; charset=UTF-8";
        public const string JSON_UTF8_CONTENT_TYPE = "application/json; charset=UTF-8";
        public static string GetContentType (string extension)
            {
            switch (extension.ToLower())
                {
                case ".avi":
                    return "video/x-msvideo";
                case ".css":
                    return "text/css";
                case ".doc":
                    return "application/msword";
                case ".gif":
                    return "image/gif";
                case ".htm":
                case ".html":
                    return "text/html; charset=UTF-8";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".js":
                    return "application/x-javascript";
                case ".mp3":
                    return "audio/mpeg";
                case ".png":
                    return "image/png";
                case ".pdf":
                    return "application/pdf";
                case ".ppt":
                    return "application/vnd.ms-powerpoint";
                case ".zip":
                    return "application/zip";
                case ".txt":
                    return PLAIN_UTF8_CONTENT_TYPE;
                case ".ico":
                    return "image/x-icon";
                case ".json":
                    return JSON_UTF8_CONTENT_TYPE;
                default:
                    return "application/octet-stream"; //some binary
                }
            }

        public static string GenerateETag(byte[] data)
            {
            using (SHA1 hasher = SHA1.Create())
                {
                byte[] hash = hasher.ComputeHash(data);
                return Convert.ToBase64String(hash);
                }
            }

        public static byte[] GZip (byte[] raw)
            {
            using (MemoryStream memory = new MemoryStream())
                {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
                    {
                    gzip.Write(raw, 0, raw.Length);
                    gzip.Flush();
                    }

                return memory.ToArray();
                }
            }
        }

    public static class HttpStatusCode
        {
        public const int OK = 200;
        public const int NO_CONTENT = 204;
        public const int MOVED_PERM = 301;
        public const int NOT_MODIFIED = 304; //for etag response
        public const int MOVED_TEMP = 307;
        public const int BAD_REQUEST = 400;
        public const int NOT_FOUND = 404;
        public const int FORBIDDEN = 403;
        public const int TOO_MANY_REQUESTS = 429;
        public const int INTERNAL_SERVER_ERROR = 500;
        }

    public static class HttpRequestHeader
        {
        public const string ACCEPT_ENCODING = "Accept-Encoding";
        public const string IF_NONE_MATCH = "If-None-Match";
        }

    public static class HttpResponseHeader
        {
        public const string VARY = "Vary";
        public const string CONTENT_ENCODING = "Content-Encoding";
        }

    public static class HttpMethod
        {
        public const string HEAD = "HEAD";
        public const string POST = "POST";
        }
    }
