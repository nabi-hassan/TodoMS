﻿using System.Net;

namespace Applicaton.Helpers
{
    public class ApiResponseBuilder
    {
        public static ApiResponse GenerateOK(object data, string message, string description)
        {
            return new ApiResponse(data, (int)HttpStatusCode.OK, "OK", message, description);
        }
        public static ApiResponse GenerateBadRequest(string message, string description)
        {
            return new ApiResponse(null, (int)HttpStatusCode.BadRequest, "Bad Request", message, description);
        }
        public static ApiResponse GenerateUnauthorized(string message, string description)
        {
            return new ApiResponse(null, (int)HttpStatusCode.Unauthorized, "Unauthorized", message, description);
        }
        public static ApiResponse GenerateForbidden(string message, string description)
        {
            return new ApiResponse(null, (int)HttpStatusCode.Forbidden, "Forbidden", message, description);
        }
        public static ApiResponse GenerateNotFound(string message, string description)
        {
            return new ApiResponse(null, (int)HttpStatusCode.NotFound, "Not Found", message, description);
        }
        public static ApiResponse InternalServerError(object data, string message, string description)
        {
            return new ApiResponse(data, (int)HttpStatusCode.InternalServerError, "Internal Server Error", message, description);
        }
    }
}
