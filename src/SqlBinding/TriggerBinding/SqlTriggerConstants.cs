﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Extensions.Sql
{
    internal static class SqlTriggerConstants
    {
        public const string WhereCheck = "whereCheck";

        public const string PrimaryKeysSelectList = "primaryKeysSelectList";

        public const string UserTableColumnsSelectList = "userTableColumnsSelectList";

        public const string LeftOuterJoinUserTable = "leftOuterJoinUserTable";

        public const string LeftOuterJoinWorkerTable = "leftOuterJoinWorkerTable";

        public const string PrimaryKeyValues = "primaryKeyValues";

        // Unit of time is seconds
        public const string LeaseUnits = "s";

        public const string Schema = "az_func";

        public const int BatchSize = 10;

        public const int MaxDequeueCount = 5;

        public const int LeaseTime = 30;

        public const int PollingInterval = 10;

    }
}