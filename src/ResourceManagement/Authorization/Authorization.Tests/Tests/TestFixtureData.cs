﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest;

namespace Authorization.Tests
{
    public class TestExecutionContext : TestBase, IDisposable
    {
        private List<Guid> createdUsers;

        private List<string> createdGroups;

        private bool disposed = false;

        private GraphManagementClient GraphClient { get; set; }
        
        public IReadOnlyCollection<Guid> Users
        {
            get 
            {
                return this.createdUsers.AsReadOnly();
            }
        }

        public IReadOnlyCollection<string> Groups
        {
            get
            {
                return this.createdGroups.AsReadOnly();
            }
        }

        public TestExecutionContext()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
            this.createdUsers = new List<Guid>();
            this.createdGroups = new List<string>();

            if(HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record )
            {
                this.GraphClient = (new GraphManagementClient(TestEnvironmentFactory.GetTestEnvironment()));
                this.CleanupTestData();
            }

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {                
                this.GraphClient = (new GraphManagementClient(TestEnvironmentFactory.GetTestEnvironment(), HttpMockServer.CreateInstance()));

                this.CreateGroups(10);
                this.CreateUsers(10);

                TestUtilities.Wait(1000*10);
            }
        }

        public ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        public AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    Cleanup();
                }
            }
            finally
            {
                disposed = true;
            }
        }

        private void Cleanup()
        {
        }

        private void CreateUsers(int number)
        {
            for (int i = 0; i < number; i++)
            {
                var objectId = this.GraphClient.CreateUser("testUser" + i);
                this.createdUsers.Add(objectId);
            }
        }

        private void CreateGroups(int number)
        {
            for (int i = 0; i < number; i++)
            {
                var objectId = this.GraphClient.CreateGroup("testGroup" + i);
                this.createdGroups.Add(objectId);
            }
        }

        internal void AddMemberToGroup(string groupId, string memberObjectId)
        {
            this.GraphClient.AddMemberToGroup(groupId, memberObjectId);
        }

        private void CleanupTestData()
        {
            foreach (var user in this.createdUsers)
            {
                this.GraphClient.DeleteUser(user);
            }

            createdUsers.Clear();

            foreach (var group in this.createdGroups)
            {
                this.GraphClient.DeleteGroup(group);
            }

            createdGroups.Clear();

            foreach(var user in this.GraphClient.ListUsers("testUser"))
            {
                this.GraphClient.DeleteUser(user);
            }
            
            foreach (var group in this.GraphClient.ListGroups("testGroup"))
            {
                this.GraphClient.DeleteGroup(group);
            }

            var env = TestEnvironmentFactory.GetTestEnvironment();
            var cred = env.TokenInfo[TokenAudience.Management];
            var authorizationClient = new AuthorizationManagementClient(
                TestEnvironmentFactory.GetTestEnvironment().BaseUri,
                cred);
            foreach (var assignment in authorizationClient.RoleAssignments.List(null))
            {
                authorizationClient.RoleAssignments.DeleteById(assignment.Id);
            }
        }
    }
}
