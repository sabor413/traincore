using System;
namespace Training.Utilities.BaseCore.Pipelines
{
    public interface IHolidayBookingPipeline
    {
        void Process(HolidayBookingPipelineArgs args);
    }
}
