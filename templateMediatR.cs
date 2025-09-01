using System;

public class templateMediatR
{
	public static class templateMediatRApi
		{
			public static void MapTemplateMediatRApi(this WebApplication app)
			{
				app.MapGet("/templateMediatR", () => "Hello World! from templateMediatR");
        }
    }
}
