﻿namespace Protobuild.Tests
{
    using Prototest.Library.Version1;

    public class QueryFeaturesTest : ProtobuildTest
    {
        private readonly IAssert _assert;

        public QueryFeaturesTest(IAssert assert) : base(assert)
        {
            _assert = assert;
        }

        public void GenerationIsCorrect()
        {
            this.SetupTest("QueryFeatures");

            var featureList = this.OtherMode("query-features", capture: true).Item1.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            var expectedFeatureList = new[] {
                "query-features",
                "no-resolve",
                "list-packages",
                "skip-invocation-on-no-standard-projects",
                "skip-synchronisation-on-no-standard-projects",
                "skip-resolution-on-no-packages-or-submodules",
                "inline-invocation-if-identical-hashed-executables",
                "no-host-generate",
                "propagate-features",
                "task-parallelisation",
            };

            _assert.Equal(expectedFeatureList, featureList);
        }
    }
}