using CommonLibrary.Business;
using CommonLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.TratamentoDados.Business
{
    public class TratamentoDadosBusiness
    {
        public TratamentoDadosBusiness()
        {

        }
        public List<MassaDadosModel> GetListMassaDadosModelFull() 
        {
            try 
            { 
                RequestBusiness _RequestBusiness = new RequestBusiness();
                var json = _RequestBusiness.RunRequest("https://localhost:44370/GetFullDados");
                var _ListReturn = JsonConvert.DeserializeObject<List<MassaDadosModel>>(json);
                return _ListReturn;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

    }

    


}