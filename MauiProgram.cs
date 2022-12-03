namespace Calculator;

public static class MauiProgram
{
    public static string dbPath = FileAccessHelpers.GetLocalFilePath("history2.db3");

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<HistoryViewModel>(s => ActivatorUtilities.CreateInstance<HistoryViewModel>(s, dbPath));

        return builder.Build();

	}
}
