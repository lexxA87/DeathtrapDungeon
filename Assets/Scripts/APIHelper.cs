using Assets.Scripts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class APIHelper
{
    public async Task<Card> GetCardAsync(string id)
    {
        var url = $"https://deathtrapdungeonapiver1.azurewebsites.net/api/card/{id}";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operarion = www.SendWebRequest();

        while (!operarion.isDone)
            await Task.Yield();

        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log($"Failed: {www.error}");

        try
        {
            var result = JsonConvert.DeserializeObject<Card>(jsonResponse);
            Debug.Log($"Succes: {www.downloadHandler.text}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{this}: Could nor parse response {jsonResponse}. {ex.Message}");
            return null;
        }
    }
}