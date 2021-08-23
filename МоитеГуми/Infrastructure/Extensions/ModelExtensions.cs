namespace МоитеГуми.Infrastructure.Extensions
{

    using МоитеГуми.Services.Obqwi;
    public static class ModelExtensions
    {
        public static string GetInformation(this IObqwaModel obqwa)
            => obqwa.Marka + "-" + obqwa.Size;
    }
}
