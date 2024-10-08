﻿using FastBase.Shared.Interface;
using FastBase.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Shared.Service
{
    public class ResponseGeneratorService : IResponseGeneratorService
    {
        /// <summary>
        /// Generates a response asynchronously without additional data.
        /// </summary>
        /// <param name="status">The status indicating the success or failure of the operation.</param>
        /// <param name="statusCode">The HTTP status code to be included in the response.</param>
        /// <param name="message">The message to be included in the response.</param>
        /// <returns>A <see cref="ReturnResponse"/> containing the generated response.</returns>
        public async Task<ReturnResponse> GenerateResponseAsync(bool status, int statusCode, string message)
        {
            return new ReturnResponse
            {
                Status = status,
                StatusCode = statusCode,
                Message = message
            };
        }

        /// <summary>
        /// Generates a response asynchronously with additional data.
        /// </summary>
        /// <typeparam name="T">The type of additional data to be included in the response.</typeparam>
        /// <param name="status">The status indicating the success or failure of the operation.</param>
        /// <param name="statusCode">The HTTP status code to be included in the response.</param>
        /// <param name="message">The message to be included in the response.</param>
        /// <param name="data">The additional data to be included in the response.</param>
        /// <returns>A <see cref="ReturnResponse{T}"/> containing the generated response with additional data.</returns>
        public async Task<ReturnResponse<T>> GenerateResponseAsync<T>(bool status, int statusCode, string message, T data)
        {
            return new ReturnResponse<T>
            {
                Status = status,
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }
    }
}
