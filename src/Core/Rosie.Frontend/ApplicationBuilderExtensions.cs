﻿using System;
using Microsoft.AspNetCore.Builder;
using Ooui;
using Xamarin.Forms;

namespace Rosie.Frontend
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseRosieFrontend(this IApplicationBuilder app, int port = 5001)
		{
			Xamarin.Forms.Forms.Init();
			UI.Port = port;
			UI.Publish("/", (new OverviewPage()).GetOouiElement());
		}
	}
}
