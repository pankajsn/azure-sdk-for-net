// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// The Service Bus Management API is a REST API for managing Service Bus
    /// queues, topics, rules and subscriptions.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780776.aspx for
    /// more information)
    /// </summary>
    public static partial class NotificationHubOperationsExtensions
    {
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='notificationHubName'>
        /// The notification hub name.
        /// </param>
        /// <returns>
        /// A standard storage response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static ServiceBusNotificationHubResponse Get(this INotificationHubOperations operations, string namespaceName, string notificationHubName)
        {
            try
            {
                return operations.GetAsync(namespaceName, notificationHubName).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }
        
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='notificationHubName'>
        /// The notification hub name.
        /// </param>
        /// <returns>
        /// A standard storage response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<ServiceBusNotificationHubResponse> GetAsync(this INotificationHubOperations operations, string namespaceName, string notificationHubName)
        {
            return operations.GetAsync(namespaceName, notificationHubName, CancellationToken.None);
        }
        
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='notificationHubName'>
        /// The notification hub name.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static ServiceBusConnectionDetailsResponse GetConnectionDetails(this INotificationHubOperations operations, string namespaceName, string notificationHubName)
        {
            try
            {
                return operations.GetConnectionDetailsAsync(namespaceName, notificationHubName).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }
        
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <param name='notificationHubName'>
        /// The notification hub name.
        /// </param>
        /// <returns>
        /// The set of connection details for a service bus entity.
        /// </returns>
        public static Task<ServiceBusConnectionDetailsResponse> GetConnectionDetailsAsync(this INotificationHubOperations operations, string namespaceName, string notificationHubName)
        {
            return operations.GetConnectionDetailsAsync(namespaceName, notificationHubName, CancellationToken.None);
        }
        
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <returns>
        /// A standard storage response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static ServiceBusNotificationHubsResponse List(this INotificationHubOperations operations, string namespaceName)
        {
            try
            {
                return operations.ListAsync(namespaceName).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }
        
        /// <summary>
        /// Lists the notification hubs associated with a namespace.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.ServiceBus.INotificationHubOperations.
        /// </param>
        /// <param name='namespaceName'>
        /// The namespace name.
        /// </param>
        /// <returns>
        /// A standard storage response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<ServiceBusNotificationHubsResponse> ListAsync(this INotificationHubOperations operations, string namespaceName)
        {
            return operations.ListAsync(namespaceName, CancellationToken.None);
        }
    }
}