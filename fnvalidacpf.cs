using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace httpvalidarCpf
{
    public static class fnvalidacpf
    {
        [FunctionName("fnvalidacpf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciado validação do CPF");

      
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            if(data == null){
                return new BadRequestObjectResult("Por favor, informe o CPF");
            }
            string cpf =  data?.cpf;

            if(!ValidaCPF(cpf)){
                return new BadRequestObjectResult("CPF inválido");
            }
       
            var responseMessage = "CPF válido";
       
            return new OkObjectResult(responseMessage);
        }

        public static bool ValidaCPF(string cpf)
        {
            int[] cpfArray = new int[11];
            int[] cpfArray2 = new int[11];
            int soma = 0;
            int resto = 0;
            int peso = 10;
            int peso2 = 11;
            int digito1 = 0;
            int digito2 = 0;
            string digitoVerificador = "";
            string digitoVerificador2 = "";
            string cpfSemDigito = "";
            string cpfComDigito = "";
            bool cpfValido = false;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            cpfSemDigito = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
            {
                cpfArray[i] = int.Parse(cpfSemDigito[i].ToString());
                soma += cpfArray[i] * peso;
                peso--;
            }

            resto = soma % 11;

            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            cpfComDigito = cpfSemDigito + digito1.ToString();

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                cpfArray2[i] = int.Parse(cpfComDigito[i].ToString());
                soma += cpfArray2[i] * peso2;
                peso2--;
            }

            resto = soma % 11;

            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            digitoVerificador = digito1.ToString();
            digitoVerificador2 = digito2.ToString();

            if (digitoVerificador == cpf[9].ToString() && digitoVerificador2 == cpf[10].ToString())
            {
                cpfValido = true;
            }

            return cpfValido;
        }

    }
    
}
