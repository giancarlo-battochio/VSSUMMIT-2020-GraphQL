﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace VSSUMMIT.Demo.GraphQL.Settings
{
    public class GraphQLSettings
    {
        public PathString GraphQLPath { get; set; }
        public Func<HttpContext, IDictionary<string, object>> BuildUserContext { get; set; }
        public bool EnableMetrics { get; set; }
        public bool ExposeExceptions { get; set; }
    }
}