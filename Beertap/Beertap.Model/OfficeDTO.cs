﻿using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    public class OfficeDTO: IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Location { get; set; }

    }
}
