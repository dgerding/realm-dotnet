﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2019 Realm Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using Realms.Server;

namespace Realms.Tests.Server
{
    public class ProxyingHandler : INotificationHandler
    {
        private readonly Func<string, bool> _shouldHandle;
        private readonly Func<IChangeDetails, Task> _handleChanges;

        public ProxyingHandler(Func<string, bool> shouldHandle, Func<IChangeDetails, Task> handleChanges)
        {
            _shouldHandle = shouldHandle ?? (_ => false);
            _handleChanges = handleChanges ?? (_ => Task.CompletedTask);
        }

        public Task HandleChangeAsync(IChangeDetails details) => _handleChanges(details);

        public bool ShouldHandle(string path) => _shouldHandle(path);
    }
}
