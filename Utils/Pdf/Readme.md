# PDF Generation

This application uses [QuestPDF]("https://www.questpdf.com/") for creating pdf. QuestPDF is dependent on [SkiaSharp]("https://github.com/mono/SkiaSharp"), which is used to render the final PDF file. This library has additional dependencies when used in the Linux environment.

 So, make sure that both `HarfBuzzSharp.NativeAssets.Linux` and `SkiaSharp.NativeAssets.Linux.NoDependencies` dependencies are present on the project if you're going to deploy on a Linux server.
