using MelonLoader;
using System.Reflection;

[assembly: AssemblyTitle(ExtraResetButtons.BuildInfo.Description)]
[assembly: AssemblyDescription(ExtraResetButtons.BuildInfo.Description)]
[assembly: AssemblyCompany(ExtraResetButtons.BuildInfo.Company)]
[assembly: AssemblyProduct(ExtraResetButtons.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ExtraResetButtons.BuildInfo.Author)]
[assembly: AssemblyTrademark(ExtraResetButtons.BuildInfo.Company)]
[assembly: AssemblyVersion(ExtraResetButtons.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ExtraResetButtons.BuildInfo.Version)]
[assembly: MelonInfo(typeof(ExtraResetButtons.ExtraResetButtons), ExtraResetButtons.BuildInfo.Name, ExtraResetButtons.BuildInfo.Version, ExtraResetButtons.BuildInfo.Author, ExtraResetButtons.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]