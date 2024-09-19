using Chms.Domain.ViewModels.Widgets;

namespace Chms.Application.Common.Interface
{
    public interface IWidgetService
    {
        public Task<SummaryVm> GetSummaryData();
    }
}
