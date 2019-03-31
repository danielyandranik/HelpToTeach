﻿using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using HelpToTeach.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpToTeach.Core.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IBucket bucket;
        public GroupRepository(INamedBucketProvider provider)
        {
            this.bucket = provider.GetBucket();
        }

        public async Task<Group> Create(Group group)
        {
            group.Id = Guid.NewGuid().ToString();
            var result = await this.bucket.InsertAsync<Group>($"group::{group.Id}", group);
            return result.Value;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            var query = new QueryRequest("SELECT HelpToTeachBucket.* FROM HelpToTeachBucket WHERE type = 'group'");
            var result = await bucket.QueryAsync<Group>(query);
            return result.Rows;
        }

        public Task<IEnumerable<Group>> GetByLecturer(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Upsert(Group group)
        {
            throw new NotImplementedException();
        }
    }
}