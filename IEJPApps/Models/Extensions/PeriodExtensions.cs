using System;
using IEJPApps.Extensions;
using IEJPApps.ViewModels;

namespace IEJPApps.Models.Extensions
{
    public static class PeriodExtensions
    {
        public static PayPeriodViewModel ToViewModel(this Period period, DayOfWeek dayOfWeek = DayOfWeek.Monday)
        {
            if (period == null) return null;

            return new PayPeriodViewModel
            {
                Id = period.Id,
                StartDate = period.StartDate,
                EndDate = period.EndDate,
                OpenedDate = period.OpenedDate,
                ClosedDate = period.ClosedDate,
                WeekNumber = period.StartDate.GetISOWeekOfYear(dayOfWeek),
                IsCurrent = period.StartDate.IsInCurrentPeriod(dayOfWeek),
                IsActive = period.Active,
                IsVisible = period.Visible
            };
        }

        public static Period ToModel(this PayPeriodViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new Period
            {
                Id = viewModel.Id.GetValueOrDefault(),
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                OpenedDate = viewModel.OpenedDate,
                ClosedDate = viewModel.ClosedDate,
                Active = viewModel.IsActive,
                Visible = viewModel.IsVisible
            };
        }
    }
}