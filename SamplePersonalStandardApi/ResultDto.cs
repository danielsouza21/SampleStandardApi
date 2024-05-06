namespace SamplePersonalStandard.Api
{
    public class ResultDto<TResult>
    {
        public TResult Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
