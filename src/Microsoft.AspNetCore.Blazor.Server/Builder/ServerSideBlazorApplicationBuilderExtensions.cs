// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Blazor.Server.Circuits;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to configure an <see cref="IApplicationBuilder"/> for Server-Side Blazor.
    /// These are just shorthand for combining UseSignalR with UseBlazor.
    /// </summary>
    public static class ServerSideBlazorApplicationBuilderExtensions
    {
        /// <summary>
        /// Registers Server-Side Blazor in the pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/>.</param>
        /// <typeparam name="TStartup">A Blazor startup type.</typeparam>
        /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseServerSideBlazor<TStartup>(
            this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // TODO: Also allow configuring the endpoint path.
            return UseSignalR(builder, BlazorHub.DefaultPath)
                .UseBlazor<TStartup>();
        }

        /// <summary>
        /// Registers Server-Side Blazor in the pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="options">A <see cref="BlazorOptions"/> instance used to configure the Blazor file provider.</param>
        /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseServerSideBlazor(
            this IApplicationBuilder builder,
            BlazorOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            // TODO: Also allow configuring the endpoint path.
            return UseSignalR(builder, BlazorHub.DefaultPath)
                .UseBlazor(options);
        }

        private static IApplicationBuilder UseSignalR(
            IApplicationBuilder builder,
            PathString path)
        {
            return builder.UseSignalR(route => route.MapHub<BlazorHub>(BlazorHub.DefaultPath));
        }
    }
}
