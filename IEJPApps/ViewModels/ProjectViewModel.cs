﻿using System;

namespace IEJPApps.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public bool Visible { get; set; }
        public string ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public int TimeCount { get; set; }
        public decimal TimeTotal { get; set; }
        public int ExpenditureCount { get; set; }
        public decimal ExpenditureTotal { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }
    }

    public class ProjectLookupViewModel
    {
        public Guid Id { get; set; }
        public string ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
    }
}