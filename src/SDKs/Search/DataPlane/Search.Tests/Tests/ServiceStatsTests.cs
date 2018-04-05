﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using System;
    using Xunit;

    public sealed class ServiceStatsTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void GetServiceStatsReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                var expectedStats = new ServiceStatistics
                {
                    Counters = new ServiceCounters
                    {
                        DocumentCounter = new ResourceCounter(0, null),
                        IndexCounter = new ResourceCounter(0, 3),
                        IndexerCounter = new ResourceCounter(0, 3),
                        DataSourceCounter = new ResourceCounter(0, 3),
                        StorageSizeCounter = new ResourceCounter(0, 52428800),
                        SynonymMapCounter = new ResourceCounter(0, 3)
                    },
                    Limits = new ServiceLimits
                    {
                        MaxFieldsPerIndex = 1000,
                        MaxIndexerRunTime = TimeSpan.FromMinutes(1),
                        MaxFileExtractionSize = 16777216,
                        MaxFileContentCharactersToExtract = 32768,
                        MaxFieldNestingDepthPerIndex = 10,
                        MaxComplexCollectionFieldsPerIndex = 100
                    }
                };

                ServiceStatistics stats = searchClient.GetServiceStatistics();
                Assert.Equal(expectedStats, stats, new ModelComparer<ServiceStatistics>());
            });
        }
    }
}
