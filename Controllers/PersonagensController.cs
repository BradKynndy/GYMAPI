using System.Text.Json.Serialization;
using GymApi.Models.Enuns

using Microsoft.AspNetCore.Mvc


namespace ApiGym.Controllers
{

    [ApiController]
    [Route("[Controller]")]

public class MembersConreoller : Controller
{
    public string uriBase = "Gym/Members/";
    //xyz = nome da api 
};

[HttpGet]
public async Task<ActionResult> IndexAync()
{
    try
    {
        string uriComplementar = "GetAll";
        HttpClient httpClient = new HttpClient()
        string token = HttpClient.Session.GetStrig("SessionTokenUsuario");
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        HttpResponseMessage response = await httpClient.GetAsync(uribase + uriComplementar);
        string serialized = await response.Content.ReadAsStringAsync();
    
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            List<MembersConreoller> listaPersonagens await Task. Run(() =>
                JsonConvert.DeserializeObject<List<MembersConreoller>>(serialized));

            return View(listaMembers);
        }
        else
        {
           throw new System.Exception(serialized);
        }
        catch (System. Exception ex)
        {
            TempData["MensagemErro"] ex.Message; 
            return RedirectToAction("Index");
        }
    
    }
}
