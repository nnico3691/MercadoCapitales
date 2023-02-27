﻿using System;

namespace Primary.Tests
{
    internal class TestWithApi
    {
        protected Api Api { get { return _lazyApi.Value; } }

        private static readonly Lazy<Api> _lazyApi = new Lazy<Api>(() => Build.AnApi().Result);
    }
}
