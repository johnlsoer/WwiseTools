﻿// See https://aka.ms/new-console-template for more information
using Examples;
using WwiseTools.Objects;
using WwiseTools.Utils;

try
{
    WaapiLog.AddCustomLogger(ExampleFunctions.CustomLogger);

    if (await WwiseUtility.Instance.TryConnectWaapiAsync())
    {
        //await SoundBankExamples.RemoveSoundBankInclusion(); // 尝试不同的方法

        var selection = await WwiseUtility.Instance.GetWwiseObjectsBySelectionAsync();

        var sound = selection[0];
        var note = await WwiseUtility.Instance.GetNotesAsync(sound);
        Console.WriteLine(note);
    }
    else
    {
        WaapiLog.Log("Waapi Connection Failed!");
    }

    await WwiseUtility.Instance.DisconnectAsync();

    await Task.Delay(3000);
}
catch (Exception e)
{
    WaapiLog.Log($"Exception: {e.Message}");
}


