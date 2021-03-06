﻿using System;

namespace OpenCI.Business.Models
{
    public class PlanModel
    {
        public Guid Guid { get; set; }

        public Guid ProjectGuid { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime ModificationTime { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}